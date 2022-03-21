using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mmu.Mlh.LanguageExtensions.Areas.Collections
{
    public static class EnumerableExtensions
    {
        public static bool ContainsAny<T>(this IEnumerable<T> list, IEnumerable<T>? otherList)
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

        // Executes tasks one after another
        public static async Task<IEnumerable<TResult>> SelectAsync<TResult, TSource>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
        {
            var result = new List<TResult>();

            foreach (var entry in source)
            {
                var selectorResult = await selector(entry);
                result.Add(selectorResult);
            }

            return result;
        }
    }
}