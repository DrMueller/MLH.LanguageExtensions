using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Collections
{
    [TestFixture]
    public class EnumerableExtensionsUnitTests
    {
        [Test]
        public void ContainsAny_OtherListBeingNull_ReturnsFalse()
        {
            // Arrange
            var list1 = new List<long>
            {
                1,
                3,
                5
            };

            // Act
            var actualContainsAny = list1.ContainsAny(null);

            // Assert
            Assert.IsFalse(actualContainsAny);
        }

        [Test]
        public void ContainsAny_OtherListContainsEntry_ReturnsTrue()
        {
            // Arrange
            var list1 = new List<long>
            {
                1,
                3,
                5
            };

            var list2 = new List<long>
            {
                2,
                4,
                5
            };

            // Act
            var actualContainsAny = list1.ContainsAny(list2);

            // Assert
            Assert.IsTrue(actualContainsAny);
        }

        [Test]
        public void ContainsAny_OtherListDoesNotContainEntry_ReturnsFalse()
        {
            // Arrange
            var list1 = new List<long>
            {
                1,
                3,
                5
            };

            var list2 = new List<long>
            {
                2,
                4,
                6
            };

            // Act
            var actualContainsAny = list1.ContainsAny(list2);

            // Assert
            Assert.IsFalse(actualContainsAny);
        }
    }
}