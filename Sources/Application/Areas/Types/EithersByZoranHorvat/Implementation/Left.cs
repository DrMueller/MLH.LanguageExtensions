using System;

namespace Mmu.Mlh.LanguageExtensions.Areas.Types.EithersByZoranHorvat.Implementation
{
    public class Left<TLeft, TRight> : Either<TLeft, TRight>
    {
        private TLeft Value { get; }

        public Left(TLeft value)
        {
            Value = value;
        }

        public override Either<TNewLeft, TRight> MapLeft<TNewLeft>(
            Func<TLeft, TNewLeft> mapping)
        {
            return new Left<TNewLeft, TRight>(mapping(Value));
        }

        public override Either<TLeft, TNewRight> MapRight<TNewRight>(
            Func<TRight, TNewRight> mapping)
        {
            return new Left<TLeft, TNewRight>(Value);
        }

        public override TLeft Reduce(Func<TRight, TLeft> mapping)
        {
            return Value;
        }
    }
}