namespace Mmu.Mlh.LanguageExtensions.Areas.Types.Eithers.Implementation
{
    public class Left<TLeft, TRight> : Either<TLeft, TRight>
    {
        public Left(TLeft content)
        {
            Content = content;
        }

        private TLeft Content { get; }

        public TLeft ToTLeft()
        {
            return Content;
        }

        public static implicit operator TLeft(Left<TLeft, TRight> left)
        {
            return left.Content;
        }
    }
}