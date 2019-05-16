using System;
using Mmu.Mlh.LanguageExtensions.Areas.Assemblies.Extensions;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Assemblies.Extensions
{
    [TestFixture]
    public class AssemblyExtensionsUnitTests
    {
        [Test]
        public void GettingAssemblyBasePath_GetsValidPath()
        {
            // Arrange
            var thisAssembly = typeof(AssemblyExtensionsUnitTests).Assembly;

            // Act
            var actualAssemblyPath = thisAssembly.GetBasePath();

            // Assert
            var isValidUri = Uri.TryCreate(actualAssemblyPath, UriKind.Absolute, out _);
            Assert.IsTrue(isValidUri);
        }
    }
}