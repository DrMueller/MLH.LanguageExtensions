using Mmu.Mlh.LanguageExtensions.Areas.Types.Eithers;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Eithers.Implementation;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Types.Eithers
{
    [TestFixture]
    public class EitherUnitTests
    {
        [Test]
        public void CreatingLeft_CreatesLeft()
        {
            // Act
            Either<string, int> left = "Test";

            // Assert
            Assert.IsInstanceOf<Left<string, int>>(left);
        }

        [Test]
        public void CreatingRight_CreatesRight()
        {
            // Act
            Either<string, int> right = 123;

            // Assert
            Assert.IsInstanceOf<Right<string, int>>(right);
        }

        [Test]
        public void MappingRight_EitherBeingLeft_ReturnsLeft()
        {
            // Arrange
            const string String = "Test";
            Either<string, int> right = String;

            // Act
            var actualLeft = right.MapRight(num => num + 123);

            // Assert
            Assert.IsInstanceOf<Left<string, int>>(actualLeft);
        }

        [Test]
        public void MappingRight_EitherBeingRight_ReturnsMappedValue()
        {
            // Arrange
            const int IntValue = 123;
            const int ExpectedIntValue = IntValue + IntValue;

            Either<string, int> right = IntValue;

            // Act
            var actualValue = right
                .MapRight(num => num + IntValue)
                .Reduce(_ => 1);

            // Assert
            Assert.AreEqual(ExpectedIntValue, actualValue);
        }

        [Test]
        public void MappingRight_EitherBeingRight_ReturnsNewRight()
        {
            // Arrange
            Either<string, int> right = 123;

            // Act
            var actualNewRight = right.MapRight(num => num.ToString());

            // Assert
            Assert.IsInstanceOf<Right<string, string>>(actualNewRight);
        }

        [Test]
        public void Reducing_EitherBeingLeft_ReturnLeftCallbackValue()
        {
            // Arrange
            const int ExpectedInt = 123;
            Either<string, int> left = ExpectedInt.ToString();

            // Act
            var actualValue = left.Reduce(int.Parse);

            // Assert
            Assert.AreEqual(ExpectedInt, actualValue);
        }

        [Test]
        public void Reducing_EitherBeingRight_ReturnsRightValue()
        {
            // Arrange
            const int IntValue = 123;
            Either<string, int> right = IntValue;

            // Act
            var valueValue = right.Reduce(_ => 1);

            // Assert
            Assert.AreEqual(IntValue, valueValue);
        }
    }
}