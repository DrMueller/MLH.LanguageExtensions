using System;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Eithers.Implementation;

namespace Mmu.Mlh.LanguageExtensions.Areas.Types.Eithers
{
    // Taken from https://app.pluralsight.com/course-player?clipId=99342073-37aa-4438-b61d-cf582553798b
    public static class EitherAdapters
    {
        public static Either<TLeft, TNewRight> Map<TLeft, TRight, TNewRight>(
            this Either<TLeft, TRight> either, Func<TRight, TNewRight> map)
        {
            return either is Right<TLeft, TRight> right
                ? (Either<TLeft, TNewRight>)map(right)
                : (TLeft)(Left<TLeft, TRight>)either;
        }

        public static Either<TLeft, TNewRight> Map<TLeft, TRight, TNewRight>(
            this Either<TLeft, TRight> either, Func<TRight, Either<TLeft, TNewRight>> map)
        {
            return either is Right<TLeft, TRight> right
                ? map(right)
                : (TLeft)(Left<TLeft, TRight>)either;
        }

        public static TRight Reduce<TLeft, TRight>(
            this Either<TLeft, TRight> either, Func<TLeft, TRight> map)
        {
            return either is Left<TLeft, TRight> left
                ? map(left)
                : (Right<TLeft, TRight>)either;
        }

        public static Either<TLeft, TRight> Reduce<TLeft, TRight>(
            this Either<TLeft, TRight> either, Func<TLeft, TRight> map, Func<TLeft, bool> when)
        {
            return either is Left<TLeft, TRight> bound && when(bound)
                ? map(bound)
                : either;
        }
    }
}
