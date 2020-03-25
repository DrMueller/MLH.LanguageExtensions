using System;

namespace Mmu.Mlh.LanguageExtensions.Areas.Types.Eithers.Implementation
{
    public class Right<TLeft, TRight> : Either<TLeft, TRight>
    {
        private readonly TRight _content;

        public Right(TRight content)
        {
            _content = content;
        }

        public static implicit operator TRight(Right<TLeft, TRight> right)
        {
            return right._content;
        }

        public override Either<TLeft, TNewRight> MapRight<TNewRight>(Func<TRight, TNewRight> map)
        {
            return map(_content);
        }

        public override TRight Reduce(Func<TLeft, TRight> leftMap)
        {
            return _content;
        }

        public TRight ToTRight()
        {
            return _content;
        }
    }
}