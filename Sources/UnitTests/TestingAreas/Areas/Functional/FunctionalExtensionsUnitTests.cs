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
            Func<int, int> addMethod = (a) => a + 1;
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
            var number = 123;

            // Act & Assert
            Assert.Throws<ArgumentException>(
                () =>
                {
                    var actualString = number.Map<int, string>(null);
                });
        }

        [Test]
        public void Mapping_WithCallback_Maps()
        {
            // Arrange
            var number = 123;
            var stringNumber = number.ToString();

            // Act
            var actualInt = stringNumber.Map(f => int.Parse(stringNumber));

            // Assert
            Assert.AreEqual(number, actualInt);
        }

        [Test]
        public void Teeing_CallbackBeingNull_Throws()
        {
            // Arrange
            var number = 123;

            // Act & Assert
            Assert.Throws<ArgumentException>(
                () =>
                {
                    number.Tee(null);
                });
        }

        [Test]
        public void Teeing_WithCallback_ExecutesCallback_WithpassedObject()
        {
            // Arrange
            var number = 123;
            var actualNumber = 0;

            // Act
            number.Tee(num => actualNumber = num);

            // Assert
            Assert.AreEqual(number, actualNumber);
        }

        [Test]
        public void Teeing_WithCallback_ReturnsSameObject()
        {
            // Arrange
            var number = 123;

            // Act
            var actualNumber = number.Tee(f => { });

            // Assert
            Assert.AreEqual(number, actualNumber);
        }

        private static Func<T1, Func<T2, Func<T3, TResult>>> Curry<T1, T2, T3, TResult>
            (Func<T1, T2, T3, TResult> function)
        {
            return a => b => c => function(a, b, c);
        }
    }
}