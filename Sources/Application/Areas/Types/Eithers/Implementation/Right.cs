namespace Mmu.Mlh.LanguageExtensions.Areas.Types.Eithers.Implementation
{
    public class Right<TLeft, TRight> : Either<TLeft, TRight>
    {
        public Right(TRight content)
        {
            Content = content;
        }

        public TRight Content { get; }

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