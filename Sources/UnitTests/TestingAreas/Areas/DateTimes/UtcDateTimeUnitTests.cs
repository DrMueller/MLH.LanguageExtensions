using System;
using System.Diagnostics.CodeAnalysis;
using Mmu.Mlh.LanguageExtensions.Areas.DateTimes;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.DateTimes
{
    [TestFixture]
    public class UtcDateTimeUnitTests
    {
        [Test]
        public void CreateingEmpty_CreatesEmpty()
        {
            // Act
            var actualUtcDateTime = UtcDateTime.CreateEmpty();

            // Assert
            Assert.IsFalse(actualUtcDateTime.HasValue);
        }

        [Test]
        public void CreatingFromDateTime_DateTimeBeingLocalKind_DoesConvert()
        {
            // Arrange
            var localDateTime = DateTime.Now;

            // Act
            var actualUtcDateTime = UtcDateTime.CreateFromDateTime(localDateTime);

            // Assert
            Assert.IsTrue(actualUtcDateTime.HasValue);
            Assert.AreNotEqual(localDateTime.Kind, actualUtcDateTime.Value.Kind);
            Assert.AreEqual(localDateTime.ToUniversalTime().Ticks, actualUtcDateTime.Value.Ticks);
        }

        [Test]
        public void CreatingFromDateTime_DateTimeBeingNull_CreatesEmpty()
        {
            // Act
            var actualUtcDateTime = UtcDateTime.CreateFromDateTime(null);

            // Assert
            Assert.IsFalse(actualUtcDateTime.HasValue);
        }

        [SuppressMessage(
            "Microsoft.Design",
            "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "Expected Exception for test")]
        [Test]
        public void CreatingFromDateTime_DateTimeBeingUnspecified_ThrowsException()
        {
            // Arrange
            var unspecifiedDateTime = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);

            // Act
            Exception? actualException = null;

            try
            {
                UtcDateTime.CreateFromDateTime(unspecifiedDateTime);
            }
            catch (Exception ex)
            {
                actualException = ex;
            }

            // Assert
            Assert.IsNotNull(actualException);
            Assert.IsAssignableFrom<InvalidOperationException>(actualException);
        }

        [Test]
        public void CreatingFromDateTime_DateTimeBeingUtcKind_DoesNotConvert()
        {
            // Arrange
            var utcDateTime = DateTime.UtcNow;

            // Act
            var actualUtcDateTime = UtcDateTime.CreateFromDateTime(utcDateTime);

            // Assert
            Assert.IsTrue(actualUtcDateTime.HasValue);
            Assert.AreEqual(utcDateTime, actualUtcDateTime.Value);
        }

        [Test]
        public void CreatingNow_CreatesUtcNow()
        {
            // Act
            var actualUtcDateTime = UtcDateTime.CreateNow();

            // Assert
            Assert.IsTrue(actualUtcDateTime.HasValue);
            Assert.AreEqual(DateTimeKind.Utc, actualUtcDateTime.Value.Kind);
        }

        [SuppressMessage(
            "Microsoft.Design",
            "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification =
                "Expected Exception for test")]
        [Test]
        public void GettingValue_BeingEmpty_ThrowsException()
        {
            // Arrange
            var emptyUtcDateTime = UtcDateTime.CreateFromDateTime(null);

            // Act
            Exception? actualException = null;

            try
            {
                // ReSharper disable once UnusedVariable
                var value = emptyUtcDateTime.Value;
            }
            catch (Exception ex)
            {
                actualException = ex;
            }

            // Assert
            Assert.IsNotNull(actualException);
            Assert.IsAssignableFrom<InvalidOperationException>(actualException);
        }

        [Test]
        public void GettingValue_DateTimeBeingSet_ReturnsValue()
        {
            // Arrange
            var localDateTime = DateTime.Now;

            // Act
            var actualUtcDateTime = UtcDateTime.CreateFromDateTime(localDateTime);

            // Assert
            Assert.AreEqual(localDateTime.ToUniversalTime(), actualUtcDateTime.Value);
        }
    }
}