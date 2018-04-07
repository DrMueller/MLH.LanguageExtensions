using System;
using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.LanguageExtensions.UnitTests.Infrastructure.Areas.Invariance;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.Areas.Invariance
{
    [TestFixture]
    public class GuardUnitTests
    {
        [Test]
        public void CheckCollectionNullOrEmpty_WithEmptyCollection_ThrowsArgumentException()
        {
            // Arrange
            var modelWithEmptyCollection = new GuardTestModel("Test", new object(), new List<object>());

            // Act & Assert
            Assert.That(
                () => Guard.CollectionNotNullOrEmpty(() => modelWithEmptyCollection.TestCollection),
                Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void CheckCollectionNullOrEmpty_WithFilledCollection_DoesNotThrowArgumentException()
        {
            // Arrange
            var modelWithFilledCollection = new GuardTestModel(
                "Test",
                new object(),
                new List<object>
                {
                    new object()
                });

            // Act & Assert
            Assert.That(
                () => Guard.CollectionNotNullOrEmpty(() => modelWithFilledCollection.TestCollection),
                Throws.Nothing);
        }

        [Test]
        public void CheckCollectionNullOrEmpty_WithNullCollection_ThrowsArgumentException()
        {
            // Arrange
            var modelWithNullCollection = new GuardTestModel("Test", new object(), null);

            // Act & Assert
            Assert.That(
                () => Guard.CollectionNotNullOrEmpty(() => modelWithNullCollection.TestCollection),
                Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void CheckingObjectNull_WithNullObject_ThrowsArgumentException()
        {
            // Given
            var modelWithObjectNull = new GuardTestModel("Test", null, new List<object>());

            // Act & Assert
            Assert.That(
                () => Guard.ObjectNotNull(() => modelWithObjectNull.TestObject),
                Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void CheckingObjectNull_WithSetObject_DoesNotThrowArgumentException()
        {
            // Arrange
            var modelWithSetobject = new GuardTestModel("Test", new object(), new List<object>());

            // Act & Assert
            Assert.That(() => Guard.ObjectNotNull(() => modelWithSetobject.TestObject), Throws.Nothing);
        }

        [Test]
        public void CheckStringNullOrEmpty_WithEmptyString_DoesNotThrowArgumentException()
        {
            // Given
            var modelWithEmptyString = new GuardTestModel(string.Empty, new object(), new List<object>());

            // When & Then
            Assert.That(
                () => Guard.StringNotNullOrEmpty(() => modelWithEmptyString.TestString),
                Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void CheckStringNullOrEmpty_WithNullString_DoesNotThrowArgumentException()
        {
            // Arrange
            var modelWithNullString = new GuardTestModel(null, new object(), new List<object>());

            // Act & Assert
            Assert.That(
                () => Guard.StringNotNullOrEmpty(() => modelWithNullString.TestString),
                Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void CheckStringNullOrEmpty_WithSetString_DoesNotThrowArgumentException()
        {
            // Arrange
            var modelWithSetString = new GuardTestModel("Test", new object(), new List<object>());

            // Act & Assert
            Assert.That(() => Guard.StringNotNullOrEmpty(() => modelWithSetString.TestString), Throws.Nothing);
        }
    }
}