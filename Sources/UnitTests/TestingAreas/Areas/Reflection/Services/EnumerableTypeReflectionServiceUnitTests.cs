using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using Mmu.Mlh.LanguageExtensions.Areas.Reflection.Services.Implementation;
using Xunit;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Reflection.Services
{
    public class EnumerableTypeReflectionServiceUnitTests
    {
        private readonly EnumerableTypeReflectionService? _sut;

        public EnumerableTypeReflectionServiceUnitTests()
        {
            _sut = new EnumerableTypeReflectionService();
        }

        [Fact]
        public void GettingGenericTypeOfEnumerable_WithGenericList_GetsGenericType()
        {
            // Arrange
            var genericList = new List<string>();

            // Act
            var actualGenericType = _sut!.GetGenericTypeOfIEnumerable(genericList);

            // Assert
            actualGenericType.Should().Be(typeof(string));
        }

        [Fact]
        public void GettingGenericTypeOfEnumerable_WithNoNGenericList_ReturnsTypeOfObject()
        {
            // Arrange
            var nonGenericArrayList = new ArrayList();

            // Act
            var actualGenericType = _sut!.GetGenericTypeOfIEnumerable(nonGenericArrayList);

            // Assert
            actualGenericType.Should().Be(typeof(object));
        }
    }
}