using System;
using Mmu.Mlh.LanguageExtensions.Areas.Maybes;
using Mmu.Mlh.LanguageExtensions.Areas.Maybes.Implementation;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.Areas.Maybes
{
    [TestFixture]
    public class MaybeUnitTests
    {
        [Test]
        public void CreatingNoneMaybe_CreatesNoneMaybe()
        {
            // Act
            var actualNoneMaybe = Maybe<object>.CreateNone();

            // Assert
            Assert.That(actualNoneMaybe, Is.TypeOf<NoneMaybe<object>>());
        }

        [Test]
        public void CreatingSomeMaybe_CreatesSomeMaybe()
        {
            // Act
            var actualSomeMaybe = Maybe<object>.CreateSome(new object());

            // Assert
            Assert.That(actualSomeMaybe, Is.TypeOf<SomeMaybe<object>>());
        }

        public void CreatingSomeMaybe_WithNullObject_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.That(
                () => Maybe<object>.CreateSome(null),
                Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void EvaluatingMaybe_BeingNoneMaybe_EvaluatesToNoneAction()
        {
            // Arrange
            var noneMaybe = Maybe<object>.CreateNone();
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
            Assert.That(noneMethodWasCalled, Is.True);
            Assert.That(someMethodWasCalled, Is.False);
        }

        [Test]
        public void EvaluatingMaybe_BeingSomeMaybe_EvaluatesToSomeAction()
        {
            // Arrange
            var someMaybe = Maybe<object>.CreateSome(new object());
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
            Assert.That(noneMethodWasCalled, Is.False);
            Assert.That(someMethodWasCalled, Is.False);
        }
    }
}