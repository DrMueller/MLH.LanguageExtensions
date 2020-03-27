using System;

namespace Mmu.Mlh.LanguageExtensions.Areas.Types.Eithers.Implementation
{
    public class Left<TLeft, TRight> : Either<TLeft, TRight>
    {
        public TLeft Content { get; }

        public Left(TLeft content)
        {
            Content = content;
        }

        public static implicit operator TLeft(Left<TLeft, TRight> left)
        {
            return left.Content;
        }

        public override Either<TLeft, TNewRight> MapRight<TNewRight>(Func<TRight, TNewRight> map)
        {
            return (TLeft)this;
        }

        public override TRight Reduce(Func<TLeft, TRight> leftMap)
        {
            return leftMap(Content);
        }

        public TLeft ToTLeft()
        {
            return Content;
        }
    }
}