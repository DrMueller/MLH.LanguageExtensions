using System;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.LanguageExtensions.Areas.Functional
{
    public static class FunctionalExtensions
    {
        public static Func<TResult> ApplyPartial<TParam1, TResult>(
            this Func<TParam1, TResult> func, TParam1 parameter)
        {
            return () => func(parameter);
        }

        public static Func<TParam2, TResult> ApplyPartial<TParam1, TParam2, TResult>(
            this Func<TParam1, TParam2, TResult> func, TParam1 parameter)
        {
            return (param2) => func(parameter, param2);
        }

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