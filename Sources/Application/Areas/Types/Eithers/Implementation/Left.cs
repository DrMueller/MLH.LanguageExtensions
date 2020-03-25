using System;

namespace Mmu.Mlh.LanguageExtensions.Areas.Types.Eithers.Implementation
{
    public class Left<TLeft, TRight> : Either<TLeft, TRight>
    {
        private readonly TLeft _content;

        public Left(TLeft content)
        {
            _content = content;
        }

        public static implicit operator TLeft(Left<TLeft, TRight> left)
        {
            return left._content;
        }

        public override Either<TLeft, TNewRight> MapRight<TNewRight>(Func<TRight, TNewRight> map)
        {
            return (TLeft)this;
        }

        public override TRight Reduce(Func<TLeft, TRight> leftMap)
        {
            return leftMap(_content);
        }

        public TLeft ToTLeft()
        {
            return _content;
        }
    }
}