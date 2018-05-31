using System;
using System.Collections.Generic;

namespace Mmu.Mlh.LanguageExtensions.Areas.Collections
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var entry in list)
            {
                action(entry);
            }
        }
    }
}