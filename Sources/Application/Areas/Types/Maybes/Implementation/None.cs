using System;

namespace Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes.Implementation
{
    public sealed class None<T> : Maybe<T>
    {
        public override bool Equals(Maybe<T> other)
        {
            return Equals(other as None<T>);
        }

        public override bool Equals(T other)
        {
            return false;
        }

        public bool Equals(None<T> other)
        {
            return !ReferenceEquals(null, other);
        }

        public override TResult Evaluate<TResult>(Func<T, TResult> whenSome, Func<TResult> whenNone)
        {
            return whenNone();
        }

        public override void Evaluate(Action<T> whenSome = null, Action whenNone = null)
        {
            whenNone?.Invoke();
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override Maybe<TNew> Map<TNew>(Func<T, TNew> mapping)
        {
            return new None<TNew>();
        }

        public override T Reduce(Func<T> whenNone)
        {
            return whenNone();
        }

        public override T Reduce(T whenNone)
        {
            return whenNone;
        }
    }
}