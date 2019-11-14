using Mmu.Mlh.LanguageExtensions.Areas.Strings.StringCutting.Services.Implementation;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Strings.StringCutting.Services
{
    [TestFixture]
    public class StringCutterUnitTests
    {
        [TestCase(null)]
        [TestCase("")]
        public void Cutting_StringBeingNullOrEmpty_ReturnsEmpty(string str)
        {
            // Arrange
            var cutter = new StringCutter(str);

            // Act
            cutter.Cut(1, out var actualCutString);

            // Assert
            Assert.IsEmpty(actualCutString);
        }

        [Test]
        public void Cutting_RemaingStringBeingSmallerThanCutSize_ReturnsRemainingString_RestBeingEmpty()
        {
            // Arrange
            const string Str = "Hello World";
            var sut = new StringCutter(Str);

            // Act
            sut.Cut(Str.Length + 1, out var actualCutString);
            sut.Cut(1, out var actualRemainingString);

            // Assert
            Assert.AreEqual(Str, actualCutString);
            Assert.IsEmpty(actualRemainingString);
        }

        [Test]
        public void Cutting_RemaingStringBingLargerThanCutSize_ReturnsCutSizeString_AndKeepsRestOfString()
        {
            // Arrange
            const string Str = "Hello World";
            var sut = new StringCutter(Str);

            // Act
            sut.Cut(Str.Length - 1, out var actualCutString);
            sut.Cut(1, out var actualRemainingString);

            // Assert
            Assert.AreEqual(Str.Substring(0, Str.Length - 1), actualCutString);
            Assert.AreEqual(Str.Substring(Str.Length - 1), actualRemainingString);
        }
    }
}