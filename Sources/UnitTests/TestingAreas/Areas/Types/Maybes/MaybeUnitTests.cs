using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes.Implementation;
using Xunit;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Types.Maybes
{
    public class MaybeUnitTests
    {
        [Fact]
        public void Binding_MaybeBeingNone_ReturnsSameNone()
        {
            // Arrange
            var noneMaybe = Maybe.CreateNone<object>();

            // Act
            var actualMaybe = noneMaybe.Bind(f => f.ToString());

            // Assert
            actualMaybe.Should().BeOfType(typeof(None<string>));
        }

        [Fact]
        public void Binding_MaybeBeingSome_ReturnsSome_WithNewMappedValue()
        {
            // Arrange
            const string InitialValue = "1234";

            Maybe<string> someMaybe = InitialValue;

            // Act
            var actualMaybe = someMaybe.Bind(int.Parse);

            // Assert
            actualMaybe.Should().BeOfType(typeof(Some<int>));
            var actualValue = (int)(Some<int>)actualMaybe;

            var expectedValue = int.Parse(InitialValue);
            actualValue.Should().Be(expectedValue);
        }

        [Fact]
        public void CastingSome_CastsToValue()
        {
            // Arrange
            const string Str = "Test";
            var actualSome = new Some<string>(Str);

            // Act
            string actualString = actualSome;

            // Assert
            actualString.Should().Be(Str);
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
            var none = Maybe.CreateNone<string>();
            Maybe<string> some = "tra";

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

            Maybe<string> someMaybe = InitialValue;

            // Act
            var actualValue = someMaybe.Reduce(() => "tra");

            // Assert
            actualValue.Should().Be(InitialValue);
        }

        [Fact]
        public async Task ReducingAsync_MaybeBeingNone_ReturnsCallbackValue()
        {
            // Arrange
            const string CallbackValue = "1234";

            var someMaybe = Maybe.CreateNone<string>();

            // Act
            var actualValue = await someMaybe.ReduceAsync(() => Task.FromResult(CallbackValue));

            // Assert
            actualValue.Should().Be(CallbackValue);
        }

        [Fact]
        public async Task ReducingAsync_MaybeBeingSome_ReturnsValue()
        {
            // Arrange
            const string InitialValue = "1234";

            Maybe<string> someMaybe = InitialValue;

            // Act
            var actualValue = await someMaybe.ReduceAsync(() => Task.FromResult("tra"));

            // Assert
            actualValue.Should().Be(InitialValue);
        }

        [Fact]
        public void SelectingSome_SelectsValues()
        {
            // Arrange
            var strValues = new List<string>
            {
                "Tra1",
                "Tra2",
                "Tra3"
            };

            var somes = strValues.Select(f => new Some<string>(f)).ToList();

            var nones = new List<None<string>>
            {
                new(),
                new(),
                new()
            };

            var list = somes.Concat<Maybe<string>>(nones).ToList();

            // Act
            var actualSomeValues = list.SelectSome().ToList();

            // Assert
            actualSomeValues.Count().Should().Be(somes.Count);

            actualSomeValues.Should().BeEquivalentTo(strValues);
        }
    }
}