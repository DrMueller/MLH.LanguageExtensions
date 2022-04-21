using System.Diagnostics;
using FluentAssertions;
using Mmu.Mlh.LanguageExtensions.Areas.Types.FunctionsResults;
using Xunit;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Types.FunctionResults
{
    public class FunctionResultUnitTests
    {
        [Theory]
        [InlineData(42)]
        [InlineData("Hello Test")]
        [InlineData(double.Epsilon)]
        public void Creating_BeingFailure_MapsValueToDefaultObject<T>(T value)
        {
            // Act
            var sut = FunctionResult.CreateFailure<T>();
            Debug.WriteLine(value);

            // Assert
            sut.Value.Should().Be(default(T));
        }

        [Theory]
        [InlineData(42)]
        [InlineData("Hello Test")]
        [InlineData(double.Epsilon)]
        public void Creating_BeingSuccess_MapsValueToPassedObjdect<T>(T value)
        {
            // Act
            var sut = FunctionResult.CreateSuccess(value);

            // Assert
            sut.Value.Should().Be(value);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(" ")]
        public void CreatingFromDefault_ValueNotBeingDefault_CreatesSuccessTrue(object value)
        {
            // Act
            var sut = FunctionResult.CreateFromDefault(value);

            // Assert
            sut.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Creating_BeingFailure_MapsToSuccessFalse()
        {
            // Act
            var sut = FunctionResult.CreateFailure<object>();

            // Assert
            sut.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void Creating_BeingSuccess_MapsToSuccessTrue()
        {
            // Act
            var sut = FunctionResult.CreateSuccess(new object());

            // Assert
            sut.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void CreatingFromDefault_ObjecBeingNull_CreatesSuccessFalse()
        {
            // Act
            var sut = FunctionResult.CreateFromDefault<object>(null!);

            // Assert
            Assert.False(sut.IsSuccess);
        }

        [Fact]
        public void CreatingFromDefault_ObjectNotBeingNull_CreatesSuccessTrue()
        {
            // Act
            var sut = FunctionResult.CreateFromDefault(new object());

            // Assert
            sut.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void CreatingFromDefault_ValueBeingDefault_CreatesSuccessFalse()
        {
            // Act
            var sut = FunctionResult.CreateFromDefault(0);

            // Assert
            sut.IsSuccess.Should().BeFalse();
        }
    }
}