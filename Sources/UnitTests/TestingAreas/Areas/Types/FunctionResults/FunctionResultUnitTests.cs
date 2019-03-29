using System.Diagnostics;
using Mmu.Mlh.LanguageExtensions.Areas.Types.FunctionsResults;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Types.FunctionResults
{
    [TestFixture]
    public class FunctionResultUnitTests
    {
        [Test]
        public void Creating_BeingFailure_MapsToSuccessFalse()
        {
            // Act
            var sut = FunctionResult.CreateFailure<object>();

            // Assert
            Assert.IsFalse(sut.IsSuccess);
        }

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

        [Test]
        public void Creating_BeingSuccess_MapsToSuccessTrue()
        {
            // Act
            var sut = FunctionResult.CreateSuccess(new object());

            // Assert
            Assert.IsTrue(sut.IsSuccess);
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
    }
}