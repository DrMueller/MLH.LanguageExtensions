﻿using System;
using System.Text;
using Mmu.Mlh.LanguageExtensions.Areas.StringBuilders;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.StringBuilders
{
    [TestFixture]
    public class StringBuilderExtensionsUnitTests
    {
        [Test]
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
            Assert.AreEqual(ExpectedString, actualString);
        }

        [Test]
        public void Appending_WithIndentationZero_DoesntIndent()
        {
            // Arrange
            const string TestString = "Test123";
            var sb = new StringBuilder();

            // Act
            sb.AppendWithIndentation(TestString, 0);

            // Assert
            var actualString = sb.ToString();
            Assert.AreEqual(TestString, actualString);
        }

        [Test]
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
            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
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
            Assert.AreEqual(expectedString, actualString);
        }
    }
}