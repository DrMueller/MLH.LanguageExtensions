using System;
using System.Collections.Generic;
using System.Linq;

namespace Mmu.Mlh.LanguageExtensions.Areas.Collections
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> list, int chunkSize)
        {
            return list
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }

        public static bool ContainsAny<T>(this IEnumerable<T> list, IEnumerable<T> otherList)
        {
            if (otherList == null)
            {
                return false;
            }

            return list.Intersect(otherList).Any();
        }

        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var entry in list)
            {
                action(entry);
            }
        }

        public static bool HasSameElementsAs<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            var firstMap = first.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var secondMap = second.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            return
                firstMap.Keys.All(x => secondMap.Keys.Contains(x) && firstMap[x] == secondMap[x]) &&
                secondMap.Keys.All(x => firstMap.Keys.Contains(x) && secondMap[x] == firstMap[x]);
        }
    }
}