using System;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes.Implementation
{
    public class Some<T> : Maybe<T>
    {
        private readonly T _content;

        public Some(T content)
        {
            Guard.ObjectNotNull(() => content);
            _content = content;
        }

        public override bool Equals(Maybe<T> other) => Equals(other as Some<T>);

        public override bool Equals(T other) => ContentEquals(other);

        public bool Equals(Some<T> other) => !ReferenceEquals(null, other) &&
            ContentEquals(other._content);

        public override TResult Evaluate<TResult>(Func<T, TResult> whenSome, Func<TResult> whenNone) => whenSome(_content);

        public override void Evaluate(Action<T> whenSome = null, Action whenNone = null)
        {
            whenSome?.Invoke(_content);
        }

        public override int GetHashCode() => _content.GetHashCode();

        public override Maybe<TNew> Map<TNew>(Func<T, TNew> mapping) => new Some<TNew>(mapping(_content));

        public override T Reduce(Func<T> whenNone) => _content;

        public override T Reduce(T whenNone) => _content;

        private bool ContentEquals(T other) => ReferenceEquals(null, _content) && ReferenceEquals(null, other) ||
            !ReferenceEquals(null, _content) && _content.Equals(other);
    }
}