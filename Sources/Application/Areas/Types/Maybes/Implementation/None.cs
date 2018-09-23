using System;

namespace Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes.Implementation
{
    public sealed class None<T> : Maybe<T>
    {
        public override bool Equals(Maybe<T> other) => Equals(other as None<T>);

        public override bool Equals(T other) => false;

        public bool Equals(None<T> other) => !ReferenceEquals(null, other);

        public override TResult Evaluate<TResult>(Func<T, TResult> whenSome, Func<TResult> whenNone) => whenNone();

        public override void Evaluate(Action<T> whenSome = null, Action whenNone = null)
        {
            whenNone?.Invoke();
        }

        public override int GetHashCode() => 0;

        public override Maybe<TNew> Map<TNew>(Func<T, TNew> mapping) => new None<TNew>();

        public override T Reduce(Func<T> whenNone) => whenNone();

        public override T Reduce(T whenNone) => whenNone;
    }
}