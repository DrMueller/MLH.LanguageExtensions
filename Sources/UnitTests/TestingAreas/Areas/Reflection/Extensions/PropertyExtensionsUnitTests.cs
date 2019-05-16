using System;
using Mmu.Mlh.LanguageExtensions.Areas.Reflection.Extensions;
using Mmu.Mlh.LanguageExtensions.UnitTests.TestingInfrastructure.Areas.Reflection.TestModels;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Reflection.Extensions
{
    [TestFixture]
    public class PropertyExtensionsUnitTests
    {
        [Test]
        public void GetPropertyInfo_GetsPropertyInfo()
        {
            // Arrange
            var individual = new Individual("Matthias", "Müller", new DateTime(1986, 12, 29));
            var expectedPropertyInfo = typeof(Individual).GetProperty("FirstName");

            // Act
            var actualPropertyInfo = individual.GetPropertyInfo(f => f.FirstName);

            // Assert
            Assert.AreEqual(expectedPropertyInfo, actualPropertyInfo);
        }
    }
}