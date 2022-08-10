using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Mmu.Mlh.LanguageExtensions.Areas.DateTimes;
using Xunit;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.DateTimes
{
    public class UtcDateTimeUnitTests
    {
        [Fact]
        public void CreateingEmpty_CreatesEmpty()
        {
            // Act
            var actualUtcDateTime = UtcDateTime.CreateEmpty();

            // Assert
            actualUtcDateTime.HasValue.Should().BeFalse();
        }

        [Fact]
        public void CreatingFromDateTime_DateTimeBeingLocalKind_DoesConvert()
        {
            // Arrange
            var localDateTime = DateTime.Now;

            // Act
            var actualUtcDateTime = UtcDateTime.CreateFromDateTime(localDateTime);

            // Assert
            actualUtcDateTime.HasValue.Should().BeTrue();
            actualUtcDateTime.Value.Kind.Should().NotBe(localDateTime.Kind);
            actualUtcDateTime.Value.Ticks.Should().Be(localDateTime.ToUniversalTime().Ticks);
        }

        [Fact]
        public void CreatingFromDateTime_DateTimeBeingNull_CreatesEmpty()
        {
            // Act
            var actualUtcDateTime = UtcDateTime.CreateFromDateTime(null);

            // Assert
            actualUtcDateTime.HasValue.Should().BeFalse();
        }

        [SuppressMessage(
            "Microsoft.Design",
            "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "Expected Exception for test")]
        [Fact]
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
            actualException.Should().NotBeNull();
            actualException.Should().BeAssignableTo<InvalidOperationException>();
        }

        [Fact]
        public void CreatingFromDateTime_DateTimeBeingUtcKind_DoesNotConvert()
        {
            // Arrange
            var utcDateTime = DateTime.UtcNow;

            // Act
            var actualUtcDateTime = UtcDateTime.CreateFromDateTime(utcDateTime);

            // Assert
            actualUtcDateTime.HasValue.Should().BeTrue();
            actualUtcDateTime.Value.Should().Be(utcDateTime);
        }

        [Fact]
        public void CreatingNow_CreatesUtcNow()
        {
            // Act
            var actualUtcDateTime = UtcDateTime.CreateNow();

            // Assert
            actualUtcDateTime.HasValue.Should().BeTrue();
            actualUtcDateTime.Value.Kind.Should().Be(DateTimeKind.Utc);
        }

        [SuppressMessage(
            "Microsoft.Design",
            "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "Expected Exception for test")]
        [Fact]
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
            actualException.Should().NotBeNull();
            actualException.Should().BeAssignableTo<InvalidOperationException>();
        }

        [Fact]
        public void GettingValue_DateTimeBeingSet_ReturnsValue()
        {
            // Arrange
            var localDateTime = DateTime.Now;

            // Act
            var actualUtcDateTime = UtcDateTime.CreateFromDateTime(localDateTime);

            // Assert
            actualUtcDateTime.Value.Should().Be(localDateTime.ToUniversalTime());
        }
    }
}