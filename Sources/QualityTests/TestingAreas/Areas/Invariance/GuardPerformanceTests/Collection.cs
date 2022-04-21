using System;
using System.Diagnostics;
using System.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Xunit;
using Xunit.Abstractions;

namespace Mmu.Mlh.LanguageExtensions.QualityTests.TestingAreas.Areas.Invariance.GuardPerformanceTests
{
    public class Collection
    {
        private readonly ITestOutputHelper _testOutputHelper;

        private const int AmountOfRuns = 1000;
        private const int CollectionSize = 200;

        public Collection(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Performance_Guard()
        {
            var collection = Enumerable.Range(1, CollectionSize).Select(i => i.ToString()).ToList();
            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i <= AmountOfRuns; i++)
            {
                Guard.CollectionNotNullOrEmpty(() => collection);
            }

            stopwatch.Stop();
            _testOutputHelper.WriteLine($"Performance_Guard: {stopwatch.Elapsed.Seconds} seconds");
        }

        [Fact]
        public void Performance_Native()
        {
            var collection = Enumerable.Range(1, CollectionSize).Select(i => i.ToString()).ToList();
            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i <= AmountOfRuns; i++)
            {
                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                if (collection != null && collection.Any())
                {
                    continue;
                }

                throw new Exception("Tra");
            }

            stopwatch.Stop();
            Debug.WriteLine($"Performance_Guard: {stopwatch.Elapsed.Seconds} seconds");
        }
    }
}