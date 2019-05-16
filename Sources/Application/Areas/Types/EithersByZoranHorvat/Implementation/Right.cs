using System;

namespace Mmu.Mlh.LanguageExtensions.Areas.Types.EithersByZoranHorvat.Implementation
{
    public class Right<TLeft, TRight> : Either<TLeft, TRight>
    {
        private TRight Value { get; }

        public Right(TRight value)
        {
            Value = value;
        }

        public override Either<TNewLeft, TRight> MapLeft<TNewLeft>(
            Func<TLeft, TNewLeft> mapping)
        {
            return new Right<TNewLeft, TRight>(Value);
        }

        public override Either<TLeft, TNewRight> MapRight<TNewRight>(
            Func<TRight, TNewRight> mapping)
        {
            return new Right<TLeft, TNewRight>(mapping(Value));
        }

        public override TLeft Reduce(Func<TRight, TLeft> mapping)
        {
            return mapping(Value);
        }
    }
}