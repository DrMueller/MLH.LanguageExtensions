using System;
using Mmu.Mlh.LanguageExtensions.Areas.Exceptions;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Exceptions
{
    [TestFixture]
    public class ExceptionExtensionsUnitTests
    {
        [Test]
        public void GettingMostInnerException_WithInnerExceptions_ReturnsMostInnerOne()
        {
            // Arrange
            var mostInnerException = new Exception();
            var exceptionLevel2 = new Exception("Test Level 2", mostInnerException);
            var topLevelException = new Exception("Test Top Level", exceptionLevel2);

            // Act
            var actualMostInnerException = topLevelException.GetMostInnerException();

            // Assert
            Assert.AreEqual(mostInnerException, actualMostInnerException);
        }

        [Test]
        public void GettingMostInnerException_WithoutInnerExceptions_ReturnsException()
        {
            // Arrange
            var exceptionWithoutInners = new Exception();

            // Act
            var actualMostInnerException = exceptionWithoutInners.GetMostInnerException();

            // Assert
            Assert.AreEqual(exceptionWithoutInners, actualMostInnerException);
        }
    }
}