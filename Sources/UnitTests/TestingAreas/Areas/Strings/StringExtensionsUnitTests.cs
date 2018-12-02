using Mmu.Mlh.LanguageExtensions.Areas.Strings;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Strings
{
    [TestFixture]
    public class StringExtensionsUnitTests
    {
        [Test]
        public void AppendIfNotEndingWith_StringDoesEndWithPassed_DoesNotAppend()
        {
            // Arrange
            const string CurrentString = "Hello World";
            const string PassedString = "World";

            // Act
            var actual = CurrentString.AppendIfNotEndingWith(PassedString);

            // Assert
            Assert.AreEqual(CurrentString, actual);
        }

        [Test]
        public void AppendIfNotEndingWith_StringDoesNotEndWithPassed_DoesAppend()
        {
            // Arrange
            const string CurrentString = "Hello World";
            const string PassedString = " Matthias";

            // Act
            var actual = CurrentString.AppendIfNotEndingWith(PassedString);

            // Assert
            Assert.AreNotEqual(CurrentString, actual);
            Assert.AreEqual(CurrentString + PassedString, actual);
        }
    }
}