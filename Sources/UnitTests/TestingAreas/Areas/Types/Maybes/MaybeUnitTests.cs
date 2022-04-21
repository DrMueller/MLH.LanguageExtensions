using FluentAssertions;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes.Implementation;
using Xunit;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Types.Maybes
{
    public class MaybeUnitTests
    {
        [Fact]
        public void Casting_MaybeBeingSome_CastsToValue()
        {
            // Arrange
            const string Str = "Test";
            var actualSome = Maybe.CreateSome(Str);

            // Act
            string actualString = actualSome;

            // Assert
            actualString.Should().Be(Str);
        }

        [Fact]
        public void CastingNone_CastsToNull()
        {
            // Arrange
            var actualNoneMaybe = Maybe.CreateNone<object>();

            // Act
            var actualObject = Maybe<object>.ToT(actualNoneMaybe);

            // Assert
            actualObject.Should().BeNull();
        }

        [Fact]
        public void CastingValue_CastsToSome()
        {
            // Arrange
            const string Str = "Test";

            // Act
            Maybe<string> actualMaybe = Str;

            // Assert
            actualMaybe.Should().BeOfType<Some<string>>();
        }

        [Fact]
        public void ComparingMaybes_BothBeingNone_ReturnsTrue()
        {
            // Arrange
            var none1 = Maybe.CreateNone<object>();
            var none2 = Maybe.CreateNone<object>();

            // Act
            var areEqual = none1 == none2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void ComparingMaybes_OneBeingNoneOneBeingSome_ReturnsFalse()
        {
            // Arrange
            var none = Maybe.CreateNone<object>();
            var some = Maybe.CreateSome(new object());

            // Act
            var areEqual = none == some;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void CreatingMaybeFromNullable_WithExistingObjects_CreatesSome()
        {
            // Act
            var actualMaybe = Maybe.CreateFromNullable(new object());

            // Assert
            actualMaybe.Should().BeOfType<Some<object>>();
        }

        [Fact]
        public void CreatingMaybeFromNullable_WithNull_CreatesNone()
        {
            // Act
            var actualMaybe = Maybe.CreateFromNullable<object>(null!);

            // Assert
            actualMaybe.Should().BeOfType<None<object>>();
        }

        [Fact]
        public void CreatingNoneMaybe_CreatesNone()
        {
            // Act
            var actualNoneMaybe = Maybe.CreateNone<object>();

            // Assert
            actualNoneMaybe.Should().BeOfType<None<object>>();
        }

        [Fact]
        public void CreatingSomeMaybe_CreatesSomeMaybe()
        {
            // Act
            var actualSomeMaybe = Maybe.CreateSome(new object());

            // Assert
            actualSomeMaybe.Should().BeOfType<Some<object>>();
        }

        [Fact]
        public void Mapping_MaybeBeingNone_ReturnsSameNone()
        {
            // Arrange
            var noneMaybe = Maybe.CreateNone<object>();

            // Act
            var actualMaybe = noneMaybe.Map(f => f.ToString());

            // Assert
            actualMaybe.Should().BeOfType(typeof(None<string>));
        }

        [Fact]
        public void Mapping_MaybeBeingSome_ReturnsSome_WithNewMappedValue()
        {
            // Arrange
            const string InitialValue = "1234";

            var someMaybe = Maybe.CreateSome(InitialValue);

            // Act
            var actualMaybe = someMaybe.Map(int.Parse);

            // Assert
            actualMaybe.Should().BeOfType(typeof(Some<int>));
            var actualValue = (int)actualMaybe;

            var expectedValue = int.Parse(InitialValue);
            actualValue.Should().Be(expectedValue);
        }

        [Fact]
        public void Reducing_MaybeBeingNone_ReturnsCallbackValue()
        {
            // Arrange
            const string CallbackValue = "1234";

            var someMaybe = Maybe.CreateNone<string>();

            // Act
            var actualValue = someMaybe.Reduce(() => CallbackValue);

            // Assert
            actualValue.Should().Be(CallbackValue);
        }

        [Fact]
        public void Reducing_MaybeBeingSome_ReturnsValue()
        {
            // Arrange
            const string InitialValue = "1234";

            var someMaybe = Maybe.CreateSome(InitialValue);

            // Act
            var actualValue = someMaybe.Reduce(() => "tra");

            // Assert
            actualValue.Should().Be(InitialValue);
        }
    }
}