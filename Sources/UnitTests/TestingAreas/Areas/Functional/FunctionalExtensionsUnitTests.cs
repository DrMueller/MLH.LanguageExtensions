using System;
using Mmu.Mlh.LanguageExtensions.Areas.Functional;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Functional
{
    [TestFixture]
    public class FunctionalExtensionsUnitTests
    {
        [Test]
        public void ApplyingOnePartial_AppliesPartial()
        {
            // Arrange
            Func<int, int> addMethod = a => a + 1;
            const int ExpectedAddResult = 2;

            // Act
            var actualPartiallyApplied = addMethod.ApplyPartial(1);

            // Assert
            var actualResult = actualPartiallyApplied();
            Assert.AreEqual(ExpectedAddResult, actualResult);
        }

        [Test]
        public void ApplyingTwoParamsPartial_AppliesPartial()
        {
            // Arrange
            Func<int, int, int> addMethod = (a, b) => a + b;
            const int ExpectedAddResult = 4;

            // Act
            var actualPartiallyApplied = addMethod.ApplyPartial(1);

            // Assert
            var actualResult = actualPartiallyApplied(3);
            Assert.AreEqual(ExpectedAddResult, actualResult);
        }

        [Test]
        public void Mapping_CallbackBeingNull_Throws()
        {
            // Arrange
            const int Number = 123;

            // Act & Assert
            Assert.Throws<ArgumentException>(
                () =>
                {
                    // ReSharper disable once UnusedVariable
                    var actualString = Number.Map<int, string>(null);
                });
        }

        [Test]
        public void Mapping_WithCallback_Maps()
        {
            // Arrange
            const int Number = 123;
            var stringNumber = Number.ToString();

            // Act
            var actualInt = stringNumber.Map(f => int.Parse(stringNumber));

            // Assert
            Assert.AreEqual(Number, actualInt);
        }

        [Test]
        public void Teeing_CallbackBeingNull_Throws()
        {
            // Arrange
            const int Number = 123;

            // Act & Assert
            Assert.Throws<ArgumentException>(
                () => { Number.Tee(null); });
        }

        [Test]
        public void Teeing_WithCallback_ExecutesCallback_WithpassedObject()
        {
            // Arrange
            const int Number = 123;
            var actualNumber = 0;

            // Act
            Number.Tee(num => actualNumber = num);

            // Assert
            Assert.AreEqual(Number, actualNumber);
        }

        [Test]
        public void Teeing_WithCallback_ReturnsSameObject()
        {
            // Arrange
            const int Number = 123;

            // Act
            var actualNumber = Number.Tee(f => { });

            // Assert
            Assert.AreEqual(Number, actualNumber);
        }
    }
}