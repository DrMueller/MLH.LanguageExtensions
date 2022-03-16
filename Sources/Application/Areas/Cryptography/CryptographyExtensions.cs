using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.LanguageExtensions.Areas.Cryptography
{
    public static class CryptographyExtensions
    {
        public static byte[] Decrypt<T>(this byte[] value, string password, string salt)
            where T : SymmetricAlgorithm, new()
        {
            Guard.ObjectNotNull(() => value);
            Guard.StringNotNullOrEmpty(() => password);
            Guard.StringNotNullOrEmpty(() => salt);

            return Perform<T>(
                value,
                password,
                salt,
                (alg, rgbKey, rgbIv) => alg.CreateDecryptor(rgbKey, rgbIv));
        }

        public static byte[] Encrypt<T>(this byte[] value, string password, string salt)
            where T : SymmetricAlgorithm, new()
        {
            Guard.ObjectNotNull(() => value);
            Guard.StringNotNullOrEmpty(() => password);
            Guard.StringNotNullOrEmpty(() => salt);

            return Perform<T>(
                value,
                password,
                salt,
                (alg, rgbKey, rgbIv) => alg.CreateEncryptor(rgbKey, rgbIv));
        }

        private static byte[] Perform<T>(
            byte[] value,
            string password,
            string salt,
            Func<T, byte[], byte[], ICryptoTransform> createCryptoCallback)
            where T : SymmetricAlgorithm, new()
        {
#pragma warning disable CA5379 // Do Not Use Weak Key Derivation Function Algorithm
            var rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));
#pragma warning restore CA5379 // Do Not Use Weak Key Derivation Function Algorithm

            using var algorithm = new T();
            var rgbKey = rgb.GetBytes(algorithm.KeySize >> 3);
            var rgbIv = rgb.GetBytes(algorithm.BlockSize >> 3);
            var transform = createCryptoCallback(algorithm, rgbKey, rgbIv);

            using var buffer = new MemoryStream();
            using (var stream = new CryptoStream(buffer, transform, CryptoStreamMode.Write))
            {
                stream.Write(value, 0, value.Length);
            }

            return buffer.ToArray();
        }
    }
}