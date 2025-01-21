using System.Linq;
using FluentAssertions;
using Mmu.Mlh.LanguageExtensions.Areas.Markdown;
using Xunit;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Markdown
{
    public class MarkdownTableFactoryUnitTests
    {
        [Fact]
        public void CreatingMarkdownTable_CreatesMarkdownTable()
        {
            // Arrange
            var models = Enumerable.Range(1, 10).Select(i => new
            {
                Id = i,
                Name = i == 3 ? "Very long long long text" : $"Name {i}",
                Description = i == 4 ? "Another ulra long text text" : $"Description {i}"
            }).ToList();

            // Act
            var actualMarkdownTable = MarkdownTableFactory.Create(models);

            // Assert
            var expectedTable =
                @"Id | Name                     | Description                
-- | ------------------------ | ---------------------------
1  | Name 1                   | Description 1              
2  | Name 2                   | Description 2              
3  | Very long long long text | Description 3              
4  | Name 4                   | Another ulra long text text
5  | Name 5                   | Description 5              
6  | Name 6                   | Description 6              
7  | Name 7                   | Description 7              
8  | Name 8                   | Description 8              
9  | Name 9                   | Description 9              
10 | Name 10                  | Description 10";

            actualMarkdownTable.Should().Be(expectedTable);
        }
    }
}