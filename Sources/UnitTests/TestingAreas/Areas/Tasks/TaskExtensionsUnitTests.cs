using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Mmu.Mlh.LanguageExtensions.Areas.Tasks;
using Xunit;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Tasks
{
    public class TaskExtensionsUnitTests
    {
        [Fact]
        public async Task SelectAsync_SelectsAsync()
        {
            // Arrange
            var list = new List<string>
            {
                "Test1",
                "Test2",
                "Test23"
            };

            var selectTask = Task.Run<IReadOnlyCollection<string>>(() => list);

            // Act
            var result = await selectTask.SelectAsync(f => f);

            // Assert
            result.Should().BeEquivalentTo(list);
        }
    }
}