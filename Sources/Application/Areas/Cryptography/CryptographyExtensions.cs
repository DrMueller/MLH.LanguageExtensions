using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.LanguageExtensions.Areas.Cryptography
{
    public static class CryptographyExtensions
    {
        public static byte[] Decrypt<T>(this byte[] value, T algo, string password, string salt)
            where T : SymmetricAlgorithm
        {
            Guard.ObjectNotNull(() => value);
            Guard.StringNotNullOrEmpty(() => password);
            Guard.StringNotNullOrEmpty(() => salt);

            return Perform(
                algo,
                value,
                password,
                salt,
                (alg, rgbKey, rgbIv) => alg.CreateDecryptor(rgbKey, rgbIv));
        }

        public static byte[] Encrypt<T>(this byte[] value, T algo, string password, string salt)
            where T : SymmetricAlgorithm
        {
            Guard.ObjectNotNull(() => value);
            Guard.StringNotNullOrEmpty(() => password);
            Guard.StringNotNullOrEmpty(() => salt);

            return Perform(
                algo,
                value,
                password,
                salt,
                (alg, rgbKey, rgbIv) => alg.CreateEncryptor(rgbKey, rgbIv));
        }

        private static byte[] Perform<T>(
            T algo,
            byte[] value,
            string password,
            string salt,
            Func<T, byte[], byte[], ICryptoTransform> createCryptoCallback)
            where T : SymmetricAlgorithm
        {
#pragma warning disable CA5379 // Do Not Use Weak Key Derivation Function Algorithm
            var rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));
#pragma warning restore CA5379 // Do Not Use Weak Key Derivation Function Algorithm

            var rgbKey = rgb.GetBytes(algo.KeySize >> 3);
            var rgbIv = rgb.GetBytes(algo.BlockSize >> 3);
            var transform = createCryptoCallback(algo, rgbKey, rgbIv);

            using var buffer = new MemoryStream();

            using (var stream = new CryptoStream(buffer, transform, CryptoStreamMode.Write))
            {
                stream.Write(value, 0, value.Length);
            }

            return buffer.ToArray();
        }
    }
}