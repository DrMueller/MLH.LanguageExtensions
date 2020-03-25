////using System;
////using System.Diagnostics.CodeAnalysis;

////namespace Mmu.Mlh.LanguageExtensions.Areas.Types.EithersByHaskell
////{
////    // https://gist.github.com/siliconbrain/3923828
////    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1649:FileNameMustMatchTypeName", Justification = "Fine")]
////    public interface ILeft<out TLeft>
////    {
////        TLeft Value { get; }
////    }

////    public interface IRight<out TRight>
////    {
////        TRight Value { get; }
////    }

////    public interface IEither<out TLeft, out TRight>
////    {
////        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "Fine")]
////        void Do(Action<TLeft> ofLeft, Action<TRight> ofRight);

////        TLeft Left();

////        TRight Right();

////        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "Fine")]
////        TReturn Select<TReturn>(Func<TLeft, TReturn> ofLeft, Func<TRight, TReturn> ofRight);
////    }

////    public static class Either
////    {
////        public static IEither<TLeft, TRight> Left<TLeft, TRight>(TLeft value)
////        {
////            return new LeftImpl<TLeft, TRight>(value);
////        }

////        public static IEither<TLeft, TRight> Right<TLeft, TRight>(TRight value)
////        {
////            return new RightImpl<TLeft, TRight>(value);
////        }

////        private struct LeftImpl<TLeft, TRight> : IEither<TLeft, TRight>, ILeft<TLeft>
////        {
////            public TLeft Value { get; }

////            public LeftImpl(TLeft value)
////            {
////                Value = value;
////            }

////            public void Do(Action<TLeft> ofLeft, Action<TRight> ofRight)
////            {
////                if (ofLeft == null)
////                {
////                    throw new ArgumentNullException(nameof(ofLeft));
////                }

////                ofLeft(Value);
////            }

////            public TLeft Left()
////            {
////                return Value;
////            }

////            public TRight Right()
////            {
////                throw new InvalidOperationException();
////            }

////            public TReturn Select<TReturn>(Func<TLeft, TReturn> ofLeft, Func<TRight, TReturn> ofRight)
////            {
////                if (ofLeft == null)
////                {
////                    throw new ArgumentNullException(nameof(ofLeft));
////                }

////                return ofLeft(Value);
////            }
////        }

////        private struct RightImpl<TLeft, TRight> : IEither<TLeft, TRight>, IRight<TRight>
////        {
////            public TRight Value { get; }

////            public RightImpl(TRight value)
////            {
////                Value = value;
////            }

////            public void Do(Action<TLeft> ofLeft, Action<TRight> ofRight)
////            {
////                if (ofRight == null)
////                {
////                    throw new ArgumentNullException(nameof(ofRight));
////                }

////                ofRight(Value);
////            }

////            public TLeft Left()
////            {
////                throw new InvalidOperationException();
////            }

////            public TRight Right()
////            {
////                return Value;
////            }

////            public TReturn Select<TReturn>(Func<TLeft, TReturn> ofLeft, Func<TRight, TReturn> ofRight)
////            {
////                if (ofRight == null)
////                {
////                    throw new ArgumentNullException(nameof(ofRight));
////                }

////                return ofRight(Value);
////            }
////        }
////    }
////}