using System.Collections;
using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Reflection.Services.Implementation;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Reflection.Services
{
    [TestFixture]
    public class EnumerableTypeReflectionServiceUnitTests
    {
        private EnumerableTypeReflectionService _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new EnumerableTypeReflectionService();
        }

        [Test]
        public void GettingGenericTypeOfEnumerable_WithGenericList_GetsGenericType()
        {
            // Arrange
            var genericList = new List<string>();

            // Act
            var actualGenericType = _sut.GetGenericTypeOfIEnumerable(genericList);

            // Assert
            Assert.AreEqual(actualGenericType, typeof(string));
        }

        [Test]
        public void GettingGenericTypeOfEnumerable_WithNoNGenericList_ReturnsTypeOfObject()
        {
            // Arrange
            var nonGenericArrayList = new ArrayList();

            // Act
            var actualGenericType = _sut.GetGenericTypeOfIEnumerable(nonGenericArrayList);

            // Assert
            Assert.AreEqual(actualGenericType, typeof(object));
        }
    }
}