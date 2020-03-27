using System;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Eithers.Implementation;

namespace Mmu.Mlh.LanguageExtensions.Areas.Types.Eithers
{
    // We really just want the implicit convertion from object --> Either
    // The other way around we would need to know if the either is right or left, which we dont want

    // We're making the content public, as we can now go one step further: We let automapper decide via type inference, which profile to use!
    public abstract class Either<TLeft, TRight>
    {
        public static implicit operator Either<TLeft, TRight>(TLeft left)
        {
            return new Left<TLeft, TRight>(left);
        }

        public static implicit operator Either<TLeft, TRight>(TRight right)
        {
            return new Right<TLeft, TRight>(right);
        }

        public abstract Either<TLeft, TNewRight> MapRight<TNewRight>(Func<TRight, TNewRight> map);

        public abstract TRight Reduce(Func<TLeft, TRight> leftMap);

        public Either<TLeft, TRight> ToEither(TRight right)
        {
            return new Right<TLeft, TRight>(right);
        }

        public Either<TLeft, TRight> ToEither(TLeft left)
        {
            return new Left<TLeft, TRight>(left);
        }
    }
}