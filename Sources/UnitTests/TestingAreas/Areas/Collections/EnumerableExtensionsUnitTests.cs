using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Xunit;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Collections
{
    public class EnumerableExtensionsUnitTests
    {
        [Fact]
        public void Chunk_CunkSizeBeingBiggerThanListSize_ReturnsOneChunk()
        {
            // Arrange
            var listWith20Entries = Enumerable.Range(0, 20).ToList();
            const int ChunkSize = 21;

            // Act
            var actualChunkedList = listWith20Entries.Chunk(ChunkSize).ToList();

            // Assert
            actualChunkedList.Count.Should().Be(1);
            actualChunkedList.Single().Length.Should().Be(listWith20Entries.Count);
        }

        [Fact]
        public void Chunk_CunkSizeBeingEqualToListSize_ReturnsOneChunk()
        {
            // Arrange
            var listWith20Entries = Enumerable.Range(0, 20).ToList();
            const int ChunkSize = 20;

            // Act
            var actualChunkedList = listWith20Entries.Chunk(ChunkSize).ToList();

            // Assert
            actualChunkedList.Count.Should().Be(1);
            actualChunkedList.Single().Length.Should().Be(listWith20Entries.Count);
        }

        [Fact]
        public void Chunk_ListBeingBiggerThanChunkSize_ReturnsChunks_WithLastChunkNotFull_AndOtherCHunksBeingFull()
        {
            // Arrange
            var listWith20Entries = Enumerable.Range(0, 20).ToList();
            const int ChunkSize = 7;

            // Act
            var actualChunkedList = listWith20Entries.Chunk(ChunkSize).ToList();

            // Assert
            var expectedAmountOfChunks = (int)Math.Ceiling((double)listWith20Entries.Count / ChunkSize);

            var allChunksExceptLast = actualChunkedList.Take(actualChunkedList.Count - 1);

            var lastChunk = actualChunkedList.Last();
            var expectedSizeOfLastChunk = listWith20Entries.Count % ChunkSize;

            actualChunkedList.Count.Should().Be(expectedAmountOfChunks);
            lastChunk.Should().NotBeNull();
            lastChunk.Length.Should().Be(expectedSizeOfLastChunk);

            var allChunksSameSize = allChunksExceptLast.All(f => f.Length == ChunkSize);
            allChunksSameSize.Should().BeTrue();
        }

        [Fact]
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
            var actualContainsAny = list1.ContainsAny(null!);

            // Assert
            actualContainsAny.Should().BeFalse();
        }

        [Fact]
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
            actualContainsAny.Should().BeTrue();
        }

        [Fact]
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
            actualContainsAny.Should().BeFalse();
        }

        [Fact]
        public void ForEach_WithElementsInCollection_AppliesActionToAllElements()
        {
            // Arrange
            IEnumerable<long> list = new List<long>
            {
                1,
                3,
                5
            };

            var cnter = 0;

            // Act
            list.ForEach(_ => cnter++);

            // Assert
            cnter.Should().Be(list.Count());
        }

        [Fact]
        public void HasSameElementsAs_BothListsHavingSameElements_ReturnsTrue()
        {
            // Arrange
            var list1 = new List<string>
            {
                "Test1",
                "Test2",
            };

            var list2 = new List<string>
            {
                "Test1",
                "Test2"
            };

            // Act
            var actualResult = list1.HasSameElementsAs(list2);

            // Assert
            actualResult.Should().BeTrue();
        }

        [Fact]
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
            actualResult.Should().BeFalse();
        }

        [Fact]
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
            actualResult.Should().BeFalse();
        }

        [Fact]
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
            actualResult.Should().BeTrue();
        }

        [Fact]
        public async Task SelectAsync_ExecutesTasks()
        {
            // Arrange
            var intList = Enumerable.Range(0, 10).ToList();

            // Act
            var actualResult = await intList.SelectAsync(Task.FromResult);

            // Assert
            actualResult.Should().BeEquivalentTo(intList);
        }

        [Fact]
        public async Task SelectAsync_ExecutesTasks_OneAfterAnother()
        {
            // Arrange
            var newList = new List<int>();

            // Act
            var actualResult = await Enumerable.Range(0, 10).SelectAsync(
                i =>
                {
                    newList.Add(i);

                    return Task.FromResult(i);
                });

            // Assert
            actualResult.Should().BeEquivalentTo(newList);
        }
    }
}