using System;

namespace Mmu.Mlh.LanguageExtensions.Areas.DomainModels.Abstractions
{
    public abstract class ComparableIdentityProvider
    {
        protected abstract string ComparedId { get; }
        private bool IsTransient => string.IsNullOrEmpty(ComparedId);

        public override bool Equals(object obj)
        {
            var compareTo = obj as ComparableIdentityProvider;

            if (ReferenceEquals(compareTo, null))
            {
                return false;
            }

            if (ReferenceEquals(this, compareTo))
            {
                return true;
            }

            if (GetType() != compareTo.GetType())
            {
                return false;
            }

            return !IsTransient && !compareTo.IsTransient && ComparedId == compareTo.ComparedId;
        }

        public override int GetHashCode() => (GetType() + ComparedId).GetHashCode(StringComparison.OrdinalIgnoreCase);

        public static bool operator ==(ComparableIdentityProvider a, ComparableIdentityProvider b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(ComparableIdentityProvider a, ComparableIdentityProvider b) => !(a == b);
    }
}