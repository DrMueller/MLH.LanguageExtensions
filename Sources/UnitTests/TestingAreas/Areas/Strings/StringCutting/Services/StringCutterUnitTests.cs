using FluentAssertions;
using Mmu.Mlh.LanguageExtensions.Areas.Strings.StringCutting.Services.Implementation;
using Xunit;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Strings.StringCutting.Services
{
    public class StringCutterUnitTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Cutting_StringBeingNullOrEmpty_ReturnsEmpty(string str)
        {
            // Arrange
            var cutter = new StringCutter(str);

            // Act
            cutter.Cut(1, out var actualCutString);

            // Assert
            actualCutString.Should().BeEmpty();
        }

        [Fact]
        public void Cutting_RemaingStringBeingSmallerThanCutSize_ReturnsRemainingString_RestBeingEmpty()
        {
            // Arrange
            const string Str = "Hello World";
            var sut = new StringCutter(Str);

            // Act
            sut.Cut(Str.Length + 1, out var actualCutString);
            sut.Cut(1, out var actualRemainingString);

            // Assert
            actualCutString.Should().Be(Str);
            actualRemainingString.Should().BeEmpty();
        }

        [Fact]
        public void Cutting_RemaingStringBingLargerThanCutSize_ReturnsCutSizeString_AndKeepsRestOfString()
        {
            // Arrange
            const string Str = "Hello World";
            var sut = new StringCutter(Str);

            // Act
            sut.Cut(Str.Length - 1, out var actualCutString);
            sut.Cut(1, out var actualRemainingString);

            // Assert
            actualCutString.Should().Be(Str.Substring(0, Str.Length - 1));
            actualRemainingString.Should().Be(Str.Substring(Str.Length - 1));
        }
    }
}