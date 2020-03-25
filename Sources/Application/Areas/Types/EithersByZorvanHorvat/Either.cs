////using System;

////namespace Mmu.Mlh.LanguageExtensions.Areas.Types.EithersByZorvanHorvat
////{
////    // See his PluralSight Course or https://gist.github.com/ehouarn-perret/da8849156570fa6421e5a872307d6ec5
////    // Course: https://app.pluralsight.com/player?course=making-functional-csharp&author=zoran-horvat&name=7a03a9bf-f592-4ea8-878d-ab27f78021b6&clip=1&mode=live
////    public abstract class Either<TLeft, TRight>
////    {
////        public static implicit operator Either<TLeft, TRight>(TLeft left)
////        {
////            return new Left<TLeft, TRight>(left);
////        }

////        public static implicit operator Either<TLeft, TRight>(TRight right)
////        {
////            return new Right<TLeft, TRight>(right);
////        }
////    }

////    public class Left<TLeft, TRight> : Either<TLeft, TRight>
////    {
////        private readonly TLeft _content;

////        public Left(TLeft content)
////        {
////            _content = content;
////        }

////        public static implicit operator TLeft(Left<TLeft, TRight> left)
////        {
////            return left._content;
////        }
////    }

////    public class Right<TLeft, TRight> : Either<TLeft, TRight>
////    {
////        private readonly TRight _content;

////        public Right(TRight content)
////        {
////            _content = content;
////        }

////        public static implicit operator TRight(Right<TLeft, TRight> right)
////        {
////            return right._content;
////        }
////    }

////    public static class EitherAdapters
////    {
////        // Either --> Either conversation
////        public static Either<TLeft, TNewRight> MapRight<TLeft, TRight, TNewRight>(this Either<TLeft, TRight> either, Func<TRight, TNewRight> map)
////        {
////            return either is Right<TLeft, TRight> right
////                ? (Either<TLeft, TNewRight>)map(right)
////                : (TLeft)(Left<TLeft, TRight>)either;
////        }

////        // Object if TRight --> Either
////        // This is important for map chaining
////        public static Either<TLeft, TNewRight> MapRight<TLeft, TRight, TNewRight>(this Either<TLeft, TRight> either, Func<TRight, Either<TLeft, TNewRight>> map)
////        {
////            return either is Right<TLeft, TRight> right
////                ? map(right)
////                : (TLeft)(Left<TLeft, TRight>)either;
////        }

////        public static TRight Reduce<TLeft, TRight>(this Either<TLeft, TRight> either, Func<TLeft, TRight> leftMap)
////        {
////            return either is Left<TLeft, TRight> left
////                ? leftMap(left)
////                : (Right<TLeft, TRight>)either;
////        }
////    }
////}