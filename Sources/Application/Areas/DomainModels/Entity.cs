using System;
using Mmu.Mlh.LanguageExtensions.Areas.DomainModels.Abstractions;

namespace Mmu.Mlh.LanguageExtensions.Areas.DomainModels
{
    public abstract class Entity : IIdentityProvider
    {
        protected Entity(string id)
        {
            Id = id;
            IsTransient = true; // If we're in this constructor, it's a new Entity
        }

        public string Id { get; private set; }
        public bool IsTransient { get; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

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

            return !IsTransient && !compareTo.IsTransient && Id == compareTo.Id;
        }

        public override int GetHashCode() => (GetType() + Id).GetHashCode(StringComparison.OrdinalIgnoreCase);

        public static bool operator ==(Entity a, Entity b)
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

        public static bool operator !=(Entity a, Entity b) => !(a == b);
    }
}