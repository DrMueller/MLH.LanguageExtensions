using FluentAssertions;
using Mmu.Mlh.LanguageExtensions.Areas.Strings.Extensions;
using Xunit;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Strings.Extensions
{
    public class StringExtensionsUnitTests
    {
        [Fact]
        public void AppendIfNotEndingWith_StringDoesEndWithPassed_DoesNotAppend()
        {
            // Arrange
            const string CurrentString = "Hello World";
            const string PassedString = "World";

            // Act
            var actual = CurrentString.AppendIfNotEndingWith(PassedString);

            // Assert
            actual.Should().Be(CurrentString);
        }

        [Fact]
        public void AppendIfNotEndingWith_StringDoesNotEndWithPassed_DoesAppend()
        {
            // Arrange
            const string CurrentString = "Hello World";
            const string PassedString = " Matthias";

            // Act
            var actual = CurrentString.AppendIfNotEndingWith(PassedString);

            // Assert
            actual.Should().NotBeEquivalentTo(CurrentString);
            actual.Should().Be(CurrentString + PassedString);
        }
    }
}