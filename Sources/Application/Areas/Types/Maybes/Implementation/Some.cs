namespace Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes.Implementation
{
    public class Some<T> : Maybe<T>
    {
        private readonly T _content;

        public Some(T content)
        {
            _content = content;
        }

        public static implicit operator T(Some<T> value)
        {
            return value._content;
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

        public override int GetHashCode()
        {
            return _content!.GetHashCode();
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