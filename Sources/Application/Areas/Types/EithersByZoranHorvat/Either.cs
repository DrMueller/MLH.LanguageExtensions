using System;
using System.Diagnostics.CodeAnalysis;
using Mmu.Mlh.LanguageExtensions.Areas.Types.EithersByZoranHorvat.Implementation;

namespace Mmu.Mlh.LanguageExtensions.Areas.Types.EithersByZoranHorvat
{
    public static class Either
    {
        public static Either<TLeft, TRight> CreateLeft<TLeft, TRight>(TLeft value)
        {
            return new Left<TLeft, TRight>(value);
        }

        public static Either<TLeft, TRight> CreateRight<TLeft, TRight>(TRight value)
        {
            return new Right<TLeft, TRight>(value);
        }
    }

    // Implementaion by Zoran Horvat. See: https://app.pluralsight.com/player?course=advanced-defensive-programming-techniques&author=zoran-horvat&name=advanced-defensive-programming-techniques-m9&clip=7&mode=live
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "It makes sense to keep these Classes together")]
    public abstract class Either<TLeft, TRight>
    {
        public abstract Either<TNewLeft, TRight>
            MapLeft<TNewLeft>(Func<TLeft, TNewLeft> mapping);

        public abstract Either<TLeft, TNewRight>
            MapRight<TNewRight>(Func<TRight, TNewRight> mapping);

        public abstract TLeft Reduce(Func<TRight, TLeft> mapping);
    }
}