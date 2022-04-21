using System;
using System.Text;
using FluentAssertions;
using Mmu.Mlh.LanguageExtensions.Areas.StringBuilders;
using Xunit;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.StringBuilders
{
    public class StringBuilderExtensionsUnitTests
    {
        [Fact]
        public void Appending_WithIndentationThree_IndentsWithThreeEmptyCharacters()
        {
            // Arrange
            const string TestString = "Test123";
            const string ExpectedString = "   " + TestString;
            var sb = new StringBuilder();

            // Act
            sb.AppendWithIndentation(TestString, 3);

            // Assert
            var actualString = sb.ToString();
            actualString.Should().Be(ExpectedString);
        }

        [Fact]
        public void Appending_WithIndentationZero_DoesntIndent()
        {
            // Arrange
            const string TestString = "Test123";
            var sb = new StringBuilder();

            // Act
            sb.AppendWithIndentation(TestString, 0);

            // Assert
            var actualString = sb.ToString();
            actualString.Should().Be(TestString);
        }

        [Fact]
        public void AppendingLine_WithIndentationThree_IndentsWithThreeEmptyCharacters()
        {
            // Arrange
            const string TestString = "Test123";
            var expectedString = "   " + TestString + Environment.NewLine;
            var sb = new StringBuilder();

            // Act
            sb.AppendLineWithIndentation(TestString, 3);

            // Assert
            var actualString = sb.ToString();
            actualString.Should().Be(expectedString);
        }

        [Fact]
        public void AppendingLine_WithIndentationZero_DoesntIndent()
        {
            // Arrange
            const string TestString = "Test123";
            var expectedString = TestString + Environment.NewLine;
            var sb = new StringBuilder();

            // Act
            sb.AppendLineWithIndentation(TestString, 0);

            // Assert
            var actualString = sb.ToString();
            actualString.Should().Be(expectedString);
        }

        [Fact]
        public void AppendingWithSeperator_AppendsSeperator_ExceptLast()
        {
            // Arrange
            var sb = new StringBuilder();
            const string Seperator = ",";
            var collectionToAdd = new[]
            {
                "test1",
                "test2",
                "test3"
            };

            const string ExpectedString = "test1,test2,test3";

            // Act
            sb.AppendWithSeperatorExceptLast(collectionToAdd, Seperator);

            // Assert
            var actualString = sb.ToString();
            actualString.Should().Be(ExpectedString);
        }
    }
}