using System;
using System.Diagnostics.CodeAnalysis;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes.Implementation;

namespace Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes
{
    public static class Maybe
    {
        public static Maybe<T> CreateFromNullable<T>(T possiblyNull)
        {
            return possiblyNull == null ? CreateNone<T>() : CreateSome(possiblyNull);
        }

        public static Maybe<T> CreateNone<T>()
        {
            return new None<T>();
        }

        public static Maybe<T> CreateSome<T>(T value)
        {
            return new Some<T>(value);
        }
    }

    [SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "It makes sense to keep these Classes together")]
    public abstract class Maybe<T> : IEquatable<Maybe<T>>, IEquatable<T>
    {
        public static Maybe<T> ToMaybe(T value)
        {
            return new Some<T>(value);
        }

        public static T ToT(Maybe<T> maybe)
        {
            return maybe.Reduce(() => default!);
        }

        public abstract bool Equals(Maybe<T> other);

        public abstract bool Equals(T other);

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((Maybe<T>)obj);
        }

        public abstract override int GetHashCode();

        public static bool operator ==(Maybe<T>? a, Maybe<T>? b)
        {
            if (ReferenceEquals(null, a) && ReferenceEquals(null, b))
            {
                return true;
            }

            if (!ReferenceEquals(null, a) && !ReferenceEquals(null, b) && a.Equals(b))
            {
                return true;
            }

            return false;
        }

        public static bool operator ==(Maybe<T>? a, T b)
        {
            return !ReferenceEquals(null, a) && a.Equals(b);
        }

        public static implicit operator Maybe<T>(T value)
        {
            return ToMaybe(value);
        }

        public static implicit operator T(Maybe<T> maybe)
        {
            return ToT(maybe);
        }

        public static bool operator !=(Maybe<T> a, Maybe<T> b)
        {
            return !(a == b);
        }

        public static bool operator !=(Maybe<T> a, T b)
        {
            return !(a == b!);
        }
    }
}