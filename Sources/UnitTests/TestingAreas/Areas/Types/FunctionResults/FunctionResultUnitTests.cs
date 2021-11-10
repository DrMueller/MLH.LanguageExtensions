using System.Diagnostics;
using Mmu.Mlh.LanguageExtensions.Areas.Types.FunctionsResults;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Types.FunctionResults
{
    [TestFixture]
    public class FunctionResultUnitTests
    {
        [TestCase(42)]
        [TestCase("Hello Test")]
        [TestCase(double.Epsilon)]
        public void Creating_BeingFailure_MapsValueToDefaultObject<T>(T value)
        {
            // Act
            var sut = FunctionResult.CreateFailure<T>();
            Debug.WriteLine(value);

            // Assert
            Assert.AreEqual(default(T), sut.Value);
        }

        [TestCase(42)]
        [TestCase("Hello Test")]
        [TestCase(double.Epsilon)]
        public void Creating_BeingSuccess_MapsValueToPassedObjdect<T>(T value)
        {
            // Act
            var sut = FunctionResult.CreateSuccess(value);

            // Assert
            Assert.AreEqual(value, sut.Value);
        }

        [Test]
        public void Creating_BeingFailure_MapsToSuccessFalse()
        {
            // Act
            var sut = FunctionResult.CreateFailure<object>();

            // Assert
            Assert.IsFalse(sut.IsSuccess);
        }

        [Test]
        public void Creating_BeingSuccess_MapsToSuccessTrue()
        {
            // Act
            var sut = FunctionResult.CreateSuccess(new object());

            // Assert
            Assert.IsTrue(sut.IsSuccess);
        }

        [Test]
        public void CreatingFromDefault_ValueBeingDefault_CreatesSuccessFalse()
        {
            // Act
            var sut = FunctionResult.CreateFromDefault(0);

            // Assert
            Assert.IsFalse(sut.IsSuccess);
        }

        [TestCase(1)]
        [TestCase(" ")]
        public void CreatingFromDefault_ValueNotBeingDefault_CreatesSuccessTrue(object value)
        {
            // Act
            var sut = FunctionResult.CreateFromDefault(value);

            // Assert
            Assert.IsTrue(sut.IsSuccess);
        }

        [Test]
        public void CreatingFromDefault_ObjectNotBeingNull_CreatesSuccessTrue()
        {
            // Act
            var sut = FunctionResult.CreateFromDefault(new object());

            // Assert
            Assert.IsTrue(sut.IsSuccess);
        }

        [Test]
        public void CreatingFromDefault_ObjecBeingNull_CreatesSuccessFalse()
        {
            // Act
            var sut = FunctionResult.CreateFromDefault<object>(null!);

            // Assert
            Assert.False(sut.IsSuccess);
        }
    }
}