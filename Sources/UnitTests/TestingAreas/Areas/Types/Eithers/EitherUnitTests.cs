using FluentAssertions;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Eithers;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Eithers.Implementation;
using Xunit;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Types.Eithers
{
    public class EitherUnitTests
    {
        [Fact]
        public void CreatingLeft_CreatesLeft()
        {
            // Act
            Either<string, int> left = "Test";

            // Assert
            left.Should().BeOfType<Left<string, int>>();
        }

        [Fact]
        public void CreatingRight_CreatesRight()
        {
            // Act
            Either<string, int> right = 123;

            // Assert
            right.Should().BeOfType<Right<string, int>>();
        }

        [Fact]
        public void Mapping_EitherBeingLeft_ReturnsLeft()
        {
            // Arrange
            const string String = "Test";
            Either<string, int> right = String;

            // Act
            var actualLeft = right.Map(num => num + 123);

            // Assert
            actualLeft.Should().BeOfType<Left<string, int>>();
        }

        [Fact]
        public void Mapping_EitherBeingRight_ReturnsMappedValue()
        {
            // Arrange
            const int IntValue = 123;
            const int ExpectedIntValue = IntValue + IntValue;

            Either<string, int> right = IntValue;

            // Act
            var actualValue = right
                .Map(num => num + IntValue)
                .Reduce(_ => 1);

            // Assert
            actualValue.Should().Be(ExpectedIntValue);
        }

        [Fact]
        public void Mapping_EitherBeingRight_ReturnsNewRight()
        {
            // Arrange
            Either<string, int> right = 123;

            // Act
            var actualNewRight = right.Map(num => num.ToString());

            // Assert
            actualNewRight.Should().BeOfType<Right<string, string>>();
        }

        [Fact]
        public void Reducing_EitherBeingLeft_ReturnLeftCallbackValue()
        {
            // Arrange
            const int ExpectedInt = 123;
            Either<string, int> left = ExpectedInt.ToString();

            // Act
            var actualValue = left.Reduce(int.Parse);

            // Assert
            actualValue.Should().Be(ExpectedInt);
        }

        [Fact]
        public void Reducing_EitherBeingRight_ReturnsRightValue()
        {
            // Arrange
            const int IntValue = 123;
            Either<string, int> right = IntValue;

            // Act
            var actualValue = right.Reduce(_ => 1);

            // Assert
            actualValue.Should().Be(IntValue);
        }

        [Fact]
        public void ReducingLeftConditional_ChainingConditions_TakesOneAssertingToTrue()
        {
            // Arrange
            const int TrueValue = 3;
            Either<string, int> left = "123";

            // Act
            var actualReduced = left
                .Reduce(_ => 1, _ => false)
                .Reduce(_ => 2, _ => false)
                .Reduce(_ => TrueValue, _ => true)
                .Reduce(_ => 4, _ => false);

            // Assert
            actualReduced.Should().BeOfType<Right<string, int>>();
            var actualRightValue = (int)(Right<string, int>)actualReduced;
            actualRightValue.Should().Be(TrueValue);
        }

        [Fact]
        public void ReducingLeftConditional_ConditionMet_ReducesToRight()
        {
            // Arrange
            const int Value = 123;
            Either<string, int> left = Value.ToString();

            // Act
            var actualReduced = left.Reduce(int.Parse, _ => true);

            // Assert
            actualReduced.Should().BeOfType<Right<string, int>>();
            var actualRightValue = (int)(Right<string, int>)actualReduced;
            actualRightValue.Should().Be(Value);
        }

        [Fact]
        public void ReducingLeftConditional_ConditionNotMet_LeavesLeft()
        {
            // Arrange
            const string Value = "123";
            Either<string, int> left = Value;

            // Act
            var actualReduced = left.Reduce(int.Parse, _ => false);

            // Assert
            actualReduced.Should().BeOfType<Left<string, int>>();
            var actualLeftValue = (string)(Left<string, int>)actualReduced;
            actualLeftValue.Should().Be(Value);
        }

        [Fact]
        public void ReducingRightConditional_ConditionMet_LeavesRight()
        {
            // Arrange
            const int Value = 123;
            Either<string, int> right = Value;

            // Act
            var actualReduced = right.Reduce(int.Parse, _ => true);

            // Assert
            actualReduced.Should().Be(right);
        }
    }
}