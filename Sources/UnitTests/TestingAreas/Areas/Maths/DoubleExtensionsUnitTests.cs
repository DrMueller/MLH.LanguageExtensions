using System.Collections.Generic;
using FluentAssertions;
using Mmu.Mlh.LanguageExtensions.Areas.Maths;
using Xunit;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Maths
{
    public class DoubleExtensionsUnitTests
    {
        [Fact]
        public void AddingDoubles_AddsDoubles()
        {
            // Arrange
            var val1 = 0.1;
            var val2 = 0.2;

            // Act
            var actualVal = val1.Add(val2);
            var nativeVal = val1 + val2;

            // Assert
            actualVal.Should().NotBe(nativeVal);
            actualVal.Should().Be(0.3);
        }

        [Fact]
        public void AddingNullableDoubles_ValueBeingNull_DoesntAddValue()
        {
            // Arrange
            double? val1 = 86.25;

            // Act
            var actualVal = val1.Add(null);

            // Assert
            actualVal.Should().Be(val1);
        }

        [Fact]
        public void Aggregating_AggregatesValues()
        {
            // Arrange
            var vals = new List<double?>
            {
                5.555,
                4.333,
                null
            };

            // Act
            var actualVal = vals.Aggregate();

            // Assert
            actualVal.Should().Be(9.888);
        }

        [Fact]
        public void DividingDoubles_DividesDoubles()
        {
            // Arrange
            var val1 = 0.3;
            var val2 = 0.1;

            // Act
            var actualVal = val1.Divide(val2);
            var nativeVal = val1 / val2;

            // Assert
            actualVal.Should().NotBe(nativeVal);
            actualVal.Should().Be(3);
        }

        [Fact]
        public void DividingNullableDoubles_ValueBeingNull_Returns0()
        {
            // Arrange
            double? val1 = 86.25;

            // Act
            var actualVal = val1.Divide(null);

            // Assert
            actualVal.Should().Be(0);
        }

        [Fact]
        public void MultiplyingDoubles_MultipliesDoubles()
        {
            // Arrange
            var val1 = 0.1;
            var val2 = 3;

            // Act
            var actualVal = val1.Multiply(val2);
            var nativeVal = val1 * val2;

            // Assert
            actualVal.Should().NotBe(nativeVal);
            actualVal.Should().Be(0.3);
        }

        [Fact]
        public void MultiplyingNullableDoubles_ValueBeingNull_Returns0()
        {
            // Arrange
            double? val1 = 0.1;

            // Act
            var actualVal = val1.Multiply(null);

            // Assert
            actualVal.Should().Be(0);
        }

        [Fact]
        public void RoundingWith3Digits_RoundsDown()
        {
            // Arrange
            var number = 2.5554;

            // Act
            var result = number.RoundWith3Digits();

            // Assert
            result.Should().Be(2.555);
        }

        [Fact]
        public void RoundingWith3Digits_RoundsUp()
        {
            // Arrange
            var number = 2.5555;

            // Act
            var result = number.RoundWith3Digits();

            // Assert
            result.Should().Be(2.556);
        }

        [Fact]
        public void SubtractingDoubles_SubtractsDoubles()
        {
            // Arrange
            var val1 = 86.25;
            var val2 = 86.24;

            // Act
            var actualVal = val1.Subtract(val2);
            var nativeVal = val1 - val2;

            // Assert
            actualVal.Should().NotBe(nativeVal);
            actualVal.Should().Be(0.01);
        }

        [Fact]
        public void SubtractingNullableDoubles_ValueBeingNull_DoesntSubtractValue()
        {
            // Arrange
            double? val1 = 86.25;

            // Act
            var actualVal = val1.Subtract(null);

            // Assert
            actualVal.Should().Be(val1);
        }
    }
}