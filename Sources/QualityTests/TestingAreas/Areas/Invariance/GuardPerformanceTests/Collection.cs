using System;
using System.Diagnostics;
using System.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.QualityTests.TestingAreas.Areas.Invariance.GuardPerformanceTests
{
    [TestFixture]
    public class Collection
    {
        private const int AmountOfRuns = 1000000;
        private const int CollectionSize = 200;

        [Test]
        public void Performance_Guard()
        {
            var collection = Enumerable.Range(1, CollectionSize).Select(i => i.ToString()).ToList();
            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i <= AmountOfRuns; i++)
            {
                Guard.CollectionNotNullOrEmpty(() => collection);
            }

            stopwatch.Stop();
            Console.WriteLine($"Performance_Guard: {stopwatch.Elapsed.Seconds} seconds");
        }

        [Test]
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