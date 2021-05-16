using System;

namespace Mmu.Mlh.LanguageExtensions.Areas.Types.Eithers.Implementation
{
    public class Right<TLeft, TRight> : Either<TLeft, TRight>
    {
        public Right(TRight content)
        {
            Content = content;
        }

        public TRight Content { get; }

        public override Either<TLeft, TNewRight> MapRight<TNewRight>(Func<TRight, TNewRight> map)
        {
            return map(Content);
        }

        public override TRight Reduce(Func<TLeft, TRight> leftMap)
        {
            return Content;
        }

        public TRight ToTRight()
        {
            return Content;
        }

        public static implicit operator TRight(Right<TLeft, TRight> right)
        {
            return right.Content;
        }
    }
}