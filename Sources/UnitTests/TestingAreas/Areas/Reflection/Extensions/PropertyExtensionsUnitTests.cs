using FluentAssertions;
using Mmu.Mlh.LanguageExtensions.Areas.Reflection.Extensions;
using Mmu.Mlh.LanguageExtensions.UnitTests.TestingInfrastructure.Areas.Reflection.TestModels;
using Xunit;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Reflection.Extensions
{
    public class PropertyExtensionsUnitTests
    {
        [Fact]
        public void GetPropertyInfo_GetsPropertyInfo()
        {
            // Arrange
            var individual = new Individual("Matthias");
            var expectedPropertyInfo = typeof(Individual).GetProperty("FirstName");

            // Act
            var actualPropertyInfo = individual.GetPropertyInfo(f => f.FirstName);

            // Assert
            actualPropertyInfo.Should().BeSameAs(expectedPropertyInfo);
        }
    }
}