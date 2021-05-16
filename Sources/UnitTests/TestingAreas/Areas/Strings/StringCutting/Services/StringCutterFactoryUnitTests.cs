using System;
using Mmu.Mlh.LanguageExtensions.Areas.Strings.StringCutting.Services.Implementation;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Strings.StringCutting.Services
{
    [TestFixture]
    public class StringCutterFactoryUnitTests
    {
        private StringCutterFactory _sut;

        [TestCase(null)]
        [TestCase("")]
        public void CreatingStringCutter_PassedStringBeingNurOrEmpty_ThrowsArgumentExceptiob(string str)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(
                () =>
                {
                    _sut.CreateFor(str);
                });
        }

        [SetUp]
        public void Align()
        {
            _sut = new StringCutterFactory();
        }

        [Test]
        public void CreatingStringCutter_WithPassedString_PassesStringToCutter()
        {
            // Arrange
            const string PassedString = "HelloTest";

            // Act
            var actualCutter = _sut.CreateFor(PassedString);
            actualCutter.Cut(PassedString.Length, out var actualString);

            // Assert
            Assert.AreEqual(PassedString, actualString);
        }
    }
}