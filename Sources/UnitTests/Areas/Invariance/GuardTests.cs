using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.Areas.Invariance
{
    [TestClass]
    public class GuardUnitTests
    {
        [TestMethod]
        public void CheckStringNollOrEmpty_WithStringNullOrEmpty_CreatesError(string testString)
        {
            // Arrange
            Action action = () => Guard.StringNotNullOrEmpty(() => testString);
            var expectedExceptionMessage = string.Format(Guard.StringNullOrEmptyExceptionMessage, "testString");

            // Act & Assert
            action.Should().Throw<ArgumentException>().WithMessage(expectedExceptionMessage);
        }
    }
}