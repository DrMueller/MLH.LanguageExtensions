using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes.Implementation;

namespace Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes
{
    public static class MaybeAdapter
    {
        public static Maybe<TNew> Bind<T, TNew>(this Maybe<T> maybe, Func<T, TNew> map)
        {
            if (maybe is None<T>)
            {
                return None.Value;
            }

            var someValue = (Some<T>)maybe;

            return map(someValue);
        }

        public static T Reduce<T>(
            this Maybe<T> maybe,
            Func<T> whenNone)
        {
            if (maybe is None<T>)
            {
                return whenNone();
            }

            return (Some<T>)maybe;
        }

        public static async Task<T> ReduceAsync<T>(
            this Maybe<T> maybe,
            Func<Task<T>> whenNone)
        {
            if (maybe is None<T>)
            {
                return await whenNone();
            }

            return (Some<T>)maybe;
        }

        public static IEnumerable<T> SelectSome<T>(this IEnumerable<Maybe<T>> maybes)
        {
            return maybes
                .OfType<Some<T>>()
                .Select(some => (T)some)
                .ToList();
        }
    }
}