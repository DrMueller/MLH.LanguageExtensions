using System;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes.Implementation;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Types.Maybes
{
    [TestFixture]
    public class MaybeUnitTests
    {
        [Test]
        public void CastingNone_CastsToNull()
        {
            // Arrange
            var actualNoneMaybe = Maybe.CreateNone<object>();

            // Act
            var actualObject = Maybe<object>.ToT(actualNoneMaybe);

            // Assert
            Assert.IsNull(actualObject);
        }

        [Test]
        public void CastingSome_CastsToValue()
        {
            // Arrange
            const string Str = "Test";
            var actualSome = Maybe.CreateSome(Str);

            // Act
            string actualString = actualSome;

            // Assert
            Assert.AreEqual(Str, actualString);
        }

        [Test]
        public void CastingValue_CastsToSome()
        {
            // Arrange
            const string Str = "Test";

            // Act
            Maybe<string> actualMaybe = Str;

            // Assert
            Assert.IsInstanceOf<Some<string>>(actualMaybe);
        }

        [Test]
        public void ComparingMaybes_BothBeingNone_ReturnsTrue()
        {
            // Arrange
            var none1 = Maybe.CreateNone<object>();
            var none2 = Maybe.CreateNone<object>();

            // Act
            var areEqual = none1 == none2;

            // Assert
            Assert.IsTrue(areEqual);
        }

        [Test]
        public void ComparingMaybes_OneBeingNoneOneBeingSome_ReturnsFalse()
        {
            // Arrange
            var none = Maybe.CreateNone<object>();
            var some = Maybe.CreateSome(new object());

            // Act
            var areEqual = none == some;

            // Assert
            Assert.IsFalse(areEqual);
        }

        [Test]
        public void CreatingMaybeFromNullable_WithExistingObjects_CreatesSome()
        {
            // Act
            var maybe = Maybe.CreateFromNullable(new object());

            // Assert
            Assert.That(maybe, Is.TypeOf<Some<object>>());
        }

        [Test]
        public void CreatingMaybeFromNullable_WithNull_CreatesNone()
        {
            // Act
            var maybe = Maybe.CreateFromNullable<object>(null!);

            // Assert
            Assert.That(maybe, Is.TypeOf<None<object>>());
        }

        [Test]
        public void CreatingNoneMaybe_CreatesNone()
        {
            // Act
            var actualNoneMaybe = Maybe.CreateNone<object>();

            // Assert
            Assert.That(actualNoneMaybe, Is.TypeOf<None<object>>());
        }

        [Test]
        public void CreatingSomeMaybe_CreatesSomeMaybe()
        {
            // Act
            var actualSomeMaybe = Maybe.CreateSome(new object());

            // Assert
            Assert.That(actualSomeMaybe, Is.TypeOf<Some<object>>());
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