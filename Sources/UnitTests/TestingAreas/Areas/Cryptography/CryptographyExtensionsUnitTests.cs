using System.Security.Cryptography;
using System.Text;
using Mmu.Mlh.LanguageExtensions.Areas.Cryptography;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Cryptography
{
    [TestFixture]
    public class CryptographyExtensionsUnitTests
    {
        [Test]
        public void Encrypting_and_decrypting_with_different_password_throws_Exception()
        {
            // Arrange
            const string String = "Plaintext";
            var bytes = Encoding.ASCII.GetBytes(String);

            const string Password = "Password";
            const string Salt = "Salt";

            // Act & Assert
            var aes = Aes.Create();

            var actualEncryptedBytes = bytes.Encrypt(aes, Password, Salt);
            Assert.Throws<CryptographicException>(() => actualEncryptedBytes.Decrypt(aes, Password + "tra", Salt));
        }

        [Test]
        public void Encrypting_and_decrypting_with_different_salt_throws_Exception()
        {
            // Arrange
            const string String = "Plaintext";
            var bytes = Encoding.ASCII.GetBytes(String);

            const string Password = "Password";
            const string Salt = "Salt";

            // Act & Assert
            var aes = Aes.Create();
            var actualEncryptedBytes = bytes.Encrypt(aes, Password, Salt);
            Assert.Throws<CryptographicException>(() => actualEncryptedBytes.Decrypt(aes, Password, Salt + "tra"));
        }

        [Test]
        public void Encrypting_and_decrypting_with_same_password_and_salt_returns_same_result()
        {
            // Arrange
            const string String = "Plaintext";
            var bytes = Encoding.ASCII.GetBytes(String);

            const string Password = "Password";
            const string Salt = "Salt";

            // Act
            var algo = Aes.Create();
            var actualEncryptedBytes = bytes.Encrypt(algo, Password, Salt);
            var actualDecryptedBytes = actualEncryptedBytes.Decrypt(algo, Password, Salt);

            // Assert
            var actualString = Encoding.ASCII.GetString(actualDecryptedBytes);
            Assert.AreEqual(String, actualString);
        }
    }
}