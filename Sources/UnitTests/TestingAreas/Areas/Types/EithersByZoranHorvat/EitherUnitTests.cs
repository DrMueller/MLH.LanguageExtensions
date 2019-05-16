using Mmu.Mlh.LanguageExtensions.Areas.Types.EithersByZoranHorvat;
using Mmu.Mlh.LanguageExtensions.Areas.Types.EithersByZoranHorvat.Implementation;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Types.EithersByZoranHorvat
{
    [TestFixture]
    public class EitherUnitTests
    {
        [Test]
        public void CreatingLeft_CreatesLeft()
        {
            // Act
            var leftEither = Either.CreateLeft<string, string>("Test");

            // Assert
            Assert.IsInstanceOf<Left<string, string>>(leftEither);
        }

        [Test]
        public void CreatingRight_CreatesRight()
        {
            // Act
            var rightEither = Either.CreateRight<string, string>("Test");

            // Assert
            Assert.IsInstanceOf<Right<string, string>>(rightEither);
        }

        [Test]
        public void MappingLeft_EitherBeingLeft_DoesApplyMapping()
        {
            // Arrange
            const string TestString = "Test";
            var either = Either.CreateLeft<string, string>(TestString);

            // Act
            var value = either.MapLeft(str => str + TestString).Reduce(str => str);

            // Assert
            Assert.AreEqual(TestString + TestString, value);
        }

        [Test]
        public void MappingLeft_EitherBeingRight_DoesNotApplyMapping()
        {
            // Arrange
            const string TestString = "Test";
            var either = Either.CreateRight<string, string>(TestString);

            // Act
            var value = either.MapLeft(str => str + TestString).Reduce(str => str);

            // Assert
            Assert.AreEqual(TestString, value);
        }

        [Test]
        public void MappingRight_EitherBeingLeft_DoesNotApplyMapping()
        {
            // Arrange
            const string TestString = "Test";
            var either = Either.CreateRight<string, string>(TestString);

            // Act
            var value = either.MapLeft(str => str + TestString).Reduce(str => str);

            // Assert
            Assert.AreEqual(TestString, value);
        }

        [Test]
        public void MappingRight_EitherBeingRight_DoesApplyMapping()
        {
            // Arrange
            const string TestString = "Test";
            var either = Either.CreateRight<string, string>(TestString);

            // Act
            var value = either.MapRight(str => str + TestString).Reduce(str => str);

            // Assert
            Assert.AreEqual(TestString + TestString, value);
        }

        [Test]
        public void Reducing_EitherBeingLeft_DoesNotApplyMapping()
        {
            // Arrange
            const long TestLong = 1;
            var either = Either.CreateLeft<long, string>(TestLong);

            // Act
            var value = either.Reduce(str => 1);

            // Assert
            Assert.AreEqual(TestLong, value);
        }

        [Test]
        public void Reducing_EitherBeinRight_DoesApplyMapping()
        {
            // Arrange
            const string TestString = "Test";
            const long TestLong = 1;
            var either = Either.CreateRight<long, string>(TestString);

            // Act
            var value = either.Reduce(str => TestLong);

            // Assert
            Assert.AreEqual(TestLong, value);
        }
    }
}