using System;

namespace Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes.Implementation
{
    public class Some<T> : Maybe<T>
    {
        private readonly T _content;

        public Some(T content)
        {
            _content = content;
        }

        public override bool Equals(Maybe<T> other)
        {
            return Equals(other as Some<T>);
        }

        public override bool Equals(T other)
        {
            return ContentEquals(other);
        }

        public bool Equals(Some<T>? other)
        {
            return !ReferenceEquals(null, other) &&
                   ContentEquals(other._content);
        }

        public override TResult Evaluate<TResult>(Func<T, TResult> whenSome, Func<TResult> whenNone)
        {
            return whenSome(_content);
        }

        public override void Evaluate(Action<T>? whenSome = null, Action? whenNone = null)
        {
            whenSome?.Invoke(_content);
        }

        public override int GetHashCode()
        {
            return _content!.GetHashCode();
        }

        public override Maybe<TNew> Map<TNew>(Func<T, TNew> mapping)
        {
            return new Some<TNew>(mapping(_content));
        }

        public override T Reduce(Func<T> whenNone)
        {
            return _content;
        }

        public override T Reduce(T whenNone)
        {
            return _content;
        }

        private bool ContentEquals(T other)
        {
            if (ReferenceEquals(null, _content) && ReferenceEquals(null, other))
            {
                return true;
            }

            if (!ReferenceEquals(null, _content) && _content.Equals(other))
            {
                return true;
            }

            return false;
        }
    }
}