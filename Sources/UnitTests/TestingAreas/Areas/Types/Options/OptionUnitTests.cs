using FluentAssertions;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Options;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Options.Implementation;
using Xunit;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Types.Options
{
    public class OptionUnitTests
    {
        [Fact]
        public void CompaingApplicable_WithContentBeingEqualAndReferenceType_CompatesToTrue()
        {
            // Arrange
            var someObj = new object();
            var applicable = Option.CreateApplicable(someObj);

            // Act
            var areEqual = someObj == applicable;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void CompaingApplicable_WithContentBeingEqualAndValueType_CompatesToTrue()
        {
            // Arrange
            const int SomeInt = 123;
            var applicable = Option.CreateApplicable(SomeInt);

            // Act
            var areEqual = applicable == SomeInt;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void CompaingNotApplicable_WithTreatAsFalse_ComparesToFalse()
        {
            // Arrange
            var notApplicable = Option.CreateNotApplicable<int>(false);

            // Act
            var areEqual = notApplicable == 123;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void CompaingNotApplicable_WithTreatAsTrue_ComparesToTrue()
        {
            // Arrange
            var notApplicable = Option.CreateNotApplicable<int>(true);

            // Act
            var areEqual = notApplicable == 123;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void CreatingApplicable_CreatesApplicable()
        {
            // Act
            var actualApplicable = Option.CreateApplicable<object>(null!);

            // Assert
            actualApplicable.Should().BeOfType<ApplicableOption<object>>();
        }

        [Fact]
        public void CreatingNotApplicable_CreatesNotApplicable()
        {
            // Act
            var actualNotApplicable = Option.CreateNotApplicable<object>(true);

            // Assert
            actualNotApplicable.Should().BeOfType<NotApplicableOption<object>>();
        }
    }
}