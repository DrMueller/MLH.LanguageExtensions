using System;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes.Implementation;

namespace Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes
{
    public static class MaybeAdapter
    {
        public static Maybe<TNew> Map<T, TNew>(this Maybe<T> maybe, Func<T, TNew> map)
        {
            if (maybe is None<T>)
            {
                return Maybe.CreateNone<TNew>();
            }

            var someValue = (T)maybe;

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

            return maybe;
        }
    }
}