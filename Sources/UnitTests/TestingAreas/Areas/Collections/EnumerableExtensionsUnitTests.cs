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

        public void HasSameElementsAs_OtherListHavingSameElements_ButOtherSorting_ReturnsTrue()
        {
            // Arrange
            var list1 = new List<string>
            {
                "Test1",
                "Test3",
                "Test2"
            };

            var list2 = new List<string>
            {
                "Test1",
                "Test2",
                "Test3"
            };

            // Act
            var actualResult = list1.HasSameElementsAs(list2);

            // Assert
            Assert.IsTrue(actualResult);
        }

        public void HasSameElementsAs_OtherListHavingMoreElements_ReturnsFalse()
        {
            // Arrange
            var list1 = new List<string>
            {
                "Test1",
                "Test3",
                "Test2"
            };

            var list2 = new List<string>
            {
                "Test1",
                "Test2",
                "Test3",
                "Test4"
            };

            // Act
            var actualResult = list1.HasSameElementsAs(list2);

            // Assert
            Assert.IsFalse(actualResult);
        }

        public void HasSameElementsAs_OtherListHavingLessElements_ReturnsFalse()
        {
            // Arrange
            var list1 = new List<string>
            {
                "Test1",
                "Test3",
                "Test2"
            };

            var list2 = new List<string>
            {
                "Test1",
                "Test2"
            };

            // Act
            var actualResult = list1.HasSameElementsAs(list2);

            // Assert
            Assert.IsFalse(actualResult);
        }
    }
}