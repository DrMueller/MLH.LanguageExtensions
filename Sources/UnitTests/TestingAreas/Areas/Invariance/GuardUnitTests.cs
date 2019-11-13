using System;
using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.LanguageExtensions.UnitTests.TestingInfrastructure.Areas.Invariance;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Invariance
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
            Assert.Throws<ArgumentException>(() => Guard.CollectionNotNullOrEmpty(() => modelWithEmptyCollection.TestCollection));
        }

        [TestCase(default(int))]
        [TestCase(default(long))]
        [TestCase(default(short))]
        public void CheckingValueNotDefault_WithValueDefault_ThrowsArgumentException<T>(T actualDefault)
            where T : struct
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => Guard.ValueNotDefault(() => actualDefault));
        }

        [Test]
        public void CheckingValueNotDefault_WithValueNotDefault_DoesNotThrowException()
        {
            // Arrange
            var actualGuid = Guid.NewGuid();

            // Act & Assert
            Assert.DoesNotThrow(() => Guard.ValueNotDefault(() => actualGuid));
        }

        [Test]
        public void CheckCollectionNullOrEmpty_WithFilledCollection_DoesNotThrowException()
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
            Assert.DoesNotThrow(
                () => Guard.CollectionNotNullOrEmpty(() => modelWithFilledCollection.TestCollection));
        }

        [Test]
        public void CheckCollectionNullOrEmpty_WithNullCollection_ThrowsArgumentException()
        {
            // Arrange
            var modelWithNullCollection = new GuardTestModel("Test", new object(), null);

            // Act & Assert
            Assert.Throws<ArgumentException>(
                () => Guard.CollectionNotNullOrEmpty(() => modelWithNullCollection.TestCollection));
        }

        [Test]
        public void CheckingObjectNull_WithNullObject_ThrowsArgumentException()
        {
            // Given
            var modelWithObjectNull = new GuardTestModel("Test", null, new List<object>());

            // Act & Assert
            Assert.Throws<ArgumentException>(
                () => Guard.ObjectNotNull(() => modelWithObjectNull.TestObject));
        }

        [Test]
        public void CheckingObjectNull_WithSetObject_DoesNotThrowException()
        {
            // Arrange
            var modelWithSetobject = new GuardTestModel("Test", new object(), new List<object>());

            // Act & Assert
            Assert.DoesNotThrow(() => Guard.ObjectNotNull(() => modelWithSetobject.TestObject));
        }

        [TestCase(null)]
        [TestCase("")]
        public void CheckingStringNullOrEmpty_WithNullOrEmptyString_ThrowsArgumentException(string actual)
        {
            // Arrange
            var modelWithNullString = new GuardTestModel(actual, new object(), new List<object>());

            // Act & Assert
            Assert.Throws<ArgumentException>(
                () => Guard.StringNotNullOrEmpty(() => modelWithNullString.TestString));
        }

        [Test]
        public void CheckStringNullOrEmpty_WithSetString_DoesNotThrowException()
        {
            // Arrange
            var modelWithSetString = new GuardTestModel("Test", new object(), new List<object>());

            // Act & Assert
            Assert.DoesNotThrow(() => Guard.StringNotNullOrEmpty(() => modelWithSetString.TestString));
        }

        [Test]
        public void CheckThat_WithThatBeingFalse_DoesThrowArgumentException_WithPassedMessage()
        {
            // Arrange
            var modelWithoutString = new GuardTestModel(string.Empty, null, new List<object>());
            var passedMessage = Guid.NewGuid() + "String must not be null or empty.";

            // Act & Assert
            Assert.That(() => Guard.That(() => !string.IsNullOrEmpty(modelWithoutString.TestString), passedMessage), Throws.ArgumentException.And.Message.EqualTo(passedMessage));
        }

        [Test]
        public void CheckThat_WithThatBeingTrue_DoesNotThrowException()
        {
            // Arrange
            var modelWithoutString = new GuardTestModel(string.Empty, null, new List<object>());
            var passedMessage = Guid.NewGuid() + "String must not be null or empty.";

            // Act & Assert
            Assert.DoesNotThrow(() => Guard.That(() => string.IsNullOrEmpty(modelWithoutString.TestString), passedMessage));
        }
    }
}