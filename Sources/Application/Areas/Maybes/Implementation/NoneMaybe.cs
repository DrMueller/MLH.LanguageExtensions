using System;

namespace Mmu.Mlh.LanguageExtensions.Areas.Maybes.Implementation
{
    public sealed class NoneMaybe<T> : Maybe<T>
    {
        public override bool Equals(Maybe<T> other) => Equals(other as NoneMaybe<T>);

        public override bool Equals(T other) => false;

        public bool Equals(NoneMaybe<T> other) => !ReferenceEquals(null, other);

        public override TResult Evaluate<TResult>(Func<T, TResult> whenSome, Func<TResult> whenNone) => whenNone();

        public override void Evaluate(Action<T> whenSome = null, Action whenNone = null)
        {
            whenNone?.Invoke();
        }

        public override int GetHashCode() => 0;

        public override Maybe<TNew> Map<TNew>(Func<T, TNew> mapping) => new NoneMaybe<TNew>();

        public override T Reduce(Func<T> whenNone) => whenNone();

        public override T Reduce(T whenNone) => whenNone;
    }
}