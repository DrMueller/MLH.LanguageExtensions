using System;
using FluentAssertions;
using Mmu.Mlh.LanguageExtensions.Areas.Strings.StringCutting.Services.Implementation;
using Xunit;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Strings.StringCutting.Services
{
    public class StringCutterFactoryUnitTests
    {
        private readonly StringCutterFactory? _sut;

        public StringCutterFactoryUnitTests()
        {
            _sut = new StringCutterFactory();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CreatingStringCutter_PassedStringBeingNurOrEmpty_ThrowsArgumentExceptiob(string str)
        {
            // Arrange
            var act = () => _sut!.CreateFor(str);

            // Act & Assert
            act.Should().ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void CreatingStringCutter_WithPassedString_PassesStringToCutter()
        {
            // Arrange
            const string PassedString = "HelloTest";

            // Act
            var actualCutter = _sut!.CreateFor(PassedString);
            actualCutter.Cut(PassedString.Length, out var actualString);

            // Assert
            actualString.Should().Be(PassedString);
        }
    }
}