using System;
using FluentAssertions;
using Mmu.Mlh.LanguageExtensions.Areas.Objects;
using Xunit;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Objects
{
    public class ObjectExtensionsUnitTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CheckIfAllPropertiesAreSet_StringBeingNullOrEmpty_ReturnsFalse(string str)
        {
            // Arrange
            var obj = new TestObject1
            {
                TestInt = 1,
                TestLong = 1,
                TestString = str
            };

            // Act
            var actualAllFieldsAreSet = obj.CheckIfAllPropertiesAreSet();

            // Assert
            actualAllFieldsAreSet.Should().BeFalse();
        }

        [Fact]
        public void CheckIfAllPropertiesAreSet_IntBeing0_ReturnsFalse()
        {
            // Arrange
            var obj = new TestObject1
            {
                TestInt = 0,
                TestLong = 1,
                TestString = Guid.NewGuid().ToString()
            };

            // Act
            var actualAllFieldsAreSet = obj.CheckIfAllPropertiesAreSet();

            // Assert
            actualAllFieldsAreSet.Should().BeFalse();
        }

        [Fact]
        public void CheckIfAllPropertiesAreSet_IntNotBeing0_ReturnsTrue()
        {
            // Arrange
            var obj = new TestObject1
            {
                TestInt = 1,
                TestLong = 1,
                TestString = Guid.NewGuid().ToString()
            };

            // Act
            var actualAllFieldsAreSet = obj.CheckIfAllPropertiesAreSet();

            // Assert
            actualAllFieldsAreSet.Should().BeTrue();
        }

        [Fact]
        public void CheckIfAllPropertiesAreSet_NullableBeing0_ReturnsFalse()
        {
            // Arrange
            var obj = new TestObject1
            {
                TestInt = 1,
                TestLong = 0,
                TestString = Guid.NewGuid().ToString()
            };

            // Act
            var actualAllFieldsAreSet = obj.CheckIfAllPropertiesAreSet();

            // Assert
            actualAllFieldsAreSet.Should().BeFalse();
        }

        [Fact]
        public void CheckIfAllPropertiesAreSet_NullableBeing1_ReturnsTrue()
        {
            // Arrange
            var obj = new TestObject1
            {
                TestInt = 1,
                TestLong = 1,
                TestString = Guid.NewGuid().ToString()
            };

            // Act
            var actualAllFieldsAreSet = obj.CheckIfAllPropertiesAreSet();

            // Assert
            actualAllFieldsAreSet.Should().BeTrue();
        }

        [Fact]
        public void CheckIfAllPropertiesAreSet_NullableBeingNull_ReturnsFalse()
        {
            // Arrange
            var obj = new TestObject1
            {
                TestInt = 1,
                TestLong = null,
                TestString = Guid.NewGuid().ToString()
            };

            // Act
            var actualAllFieldsAreSet = obj.CheckIfAllPropertiesAreSet();

            // Assert
            actualAllFieldsAreSet.Should().BeFalse();
        }

        [Fact]
        public void CheckIfAllPropertiesAreSet_StringNotBeingNullOrEmpty_ReturnsTrue()
        {
            // Arrange
            var obj = new TestObject1
            {
                TestInt = 1,
                TestLong = 1,
                TestString = Guid.NewGuid().ToString()
            };

            // Act
            var actualAllFieldsAreSet = obj.CheckIfAllPropertiesAreSet();

            // Assert
            actualAllFieldsAreSet.Should().BeTrue();
        }
    }
}