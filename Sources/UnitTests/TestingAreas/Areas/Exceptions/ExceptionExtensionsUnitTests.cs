using System;
using FluentAssertions;
using Mmu.Mlh.LanguageExtensions.Areas.Exceptions;
using Xunit;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Exceptions
{
    public class ExceptionExtensionsUnitTests
    {
        [Fact]
        public void GettingMostInnerException_WithInnerExceptions_ReturnsMostInnerOne()
        {
            // Arrange
            var mostInnerException = new Exception();
            var exceptionLevel2 = new Exception("Test Level 2", mostInnerException);
            var topLevelException = new Exception("Test Top Level", exceptionLevel2);

            // Act
            var actualMostInnerException = topLevelException.GetMostInnerException();

            // Assert
            actualMostInnerException.Should().Be(mostInnerException);
        }

        [Fact]
        public void GettingMostInnerException_WithoutInnerExceptions_ReturnsException()
        {
            // Arrange
            var exceptionWithoutInners = new Exception();

            // Act
            var actualMostInnerException = exceptionWithoutInners.GetMostInnerException();

            // Assert
            actualMostInnerException.Should().Be(exceptionWithoutInners);
        }
    }
}