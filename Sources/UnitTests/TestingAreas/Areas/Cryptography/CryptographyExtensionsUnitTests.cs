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
            var actualEncryptedBytes = bytes.Encrypt<RijndaelManaged>(Password, Salt);
            Assert.Throws<CryptographicException>(() => actualEncryptedBytes.Decrypt<RijndaelManaged>(Password + "tra", Salt));
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
            var actualEncryptedBytes = bytes.Encrypt<RijndaelManaged>(Password, Salt);
            Assert.Throws<CryptographicException>(() => actualEncryptedBytes.Decrypt<RijndaelManaged>(Password, Salt + "tra"));
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
            var actualEncryptedBytes = bytes.Encrypt<RijndaelManaged>(Password, Salt);
            var actualDecryptedBytes = actualEncryptedBytes.Decrypt<RijndaelManaged>(Password, Salt);

            // Assert
            var actualString = Encoding.ASCII.GetString(actualDecryptedBytes);
            Assert.AreEqual(String, actualString);
        }
    }
}