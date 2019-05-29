using System;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.LanguageExtensions.Areas.Functional
{
    public static class FunctionalExtensions
    {
        public static TResult Map<TSource, TResult>(this TSource source, Func<TSource, TResult> mappingCallback)
        {
            Guard.ObjectNotNull(() => mappingCallback);

            return mappingCallback(source);
        }

        public static T Tee<T>(this T @this, Action<T> callback)
        {
            Guard.ObjectNotNull(() => callback);

            callback(@this);
            return @this;
        }
    }
}