using System;
using FluentAssertions;
using Mmu.Mlh.LanguageExtensions.Areas.Assemblies.Extensions;
using Xunit;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Assemblies.Extensions
{
    public class AssemblyExtensionsUnitTests
    {
        [Fact]
        public void GettingAssemblyBasePath_GetsValidPath()
        {
            // Arrange
            var thisAssembly = typeof(AssemblyExtensionsUnitTests).Assembly;

            // Act
            var actualAssemblyPath = thisAssembly.GetBasePath();

            // Assert
            var isValidUri = Uri.TryCreate(actualAssemblyPath, UriKind.Absolute, out _);
            isValidUri.Should().BeTrue();
        }
    }
}