using System;
using Mmu.Mlh.LanguageExtensions.Areas.Maybes;
using Mmu.Mlh.LanguageExtensions.Areas.Maybes.Implementation;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Maybes
{
    [TestFixture]
    public class MaybeUnitTests
    {
        [Test]
        public void CreatingNoneMaybe_CreatesNoneMaybe()
        {
            // Act
            var actualNoneMaybe = Maybe.CreateNone<object>();

            // Assert
            Assert.That(actualNoneMaybe, Is.TypeOf<NoneMaybe<object>>());
        }

        [Test]
        public void CreatingSomeMaybe_CreatesSomeMaybe()
        {
            // Act
            var actualSomeMaybe = Maybe.CreateSome(new object());

            // Assert
            Assert.That(actualSomeMaybe, Is.TypeOf<SomeMaybe<object>>());
        }

        public void CreatingSomeMaybe_WithNullObject_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => Maybe.CreateSome<object>(null));
        }

        [Test]
        public void EvaluatingMaybe_BeingNoneMaybe_EvaluatesToNoneAction()
        {
            // Arrange
            var noneMaybe = Maybe.CreateNone<object>();
            var noneMethodWasCalled = false;
            var someMethodWasCalled = false;

            void NoneCallback()
            {
                noneMethodWasCalled = true;
            }

            void SomeCallback(object obj)
            {
                someMethodWasCalled = true;
            }

            // Act
            noneMaybe.Evaluate(SomeCallback, NoneCallback);

            // Assert
            Assert.IsTrue(noneMethodWasCalled);
            Assert.IsFalse(someMethodWasCalled);
        }

        [Test]
        public void EvaluatingMaybe_BeingSomeMaybe_EvaluatesToSomeAction()
        {
            // Arrange
            var someMaybe = Maybe.CreateSome(new object());
            var noneMethodWasCalled = false;
            var someMethodWasCalled = false;

            void NoneCallback()
            {
                noneMethodWasCalled = true;
            }

            void SomeCallback(object obj)
            {
                someMethodWasCalled = true;
            }

            // Act
            someMaybe.Evaluate(SomeCallback, NoneCallback);

            // Assert
            Assert.IsFalse(noneMethodWasCalled);
            Assert.IsTrue(someMethodWasCalled);
        }
    }
}