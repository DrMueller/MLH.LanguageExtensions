using System;
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

    public abstract class Maybe<T> : IEquatable<Maybe<T>>, IEquatable<T>
    {
        public abstract bool Equals(Maybe<T> other);

        public abstract bool Equals(T other);

        public override bool Equals(object obj)
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

        public abstract TResult Evaluate<TResult>(Func<T, TResult> whenSome, Func<TResult> whenNone);

        public abstract void Evaluate(Action<T> whenSome = null, Action whenNone = null);

        public abstract override int GetHashCode();

        public abstract Maybe<TNew> Map<TNew>(Func<T, TNew> mapping);

        public static bool operator ==(Maybe<T> a, Maybe<T> b)
        {
            return ReferenceEquals(null, a) && ReferenceEquals(null, b) ||
                !ReferenceEquals(null, a) && a.Equals(b);
        }

        public static bool operator ==(Maybe<T> a, T b)
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
            return !(a == b);
        }

        public abstract T Reduce(Func<T> whenNone);

        public abstract T Reduce(T whenNone);

        public static Maybe<T> ToMaybe(T value)
        {
            return new Some<T>(value);
        }

        public static T ToT(Maybe<T> maybe)
        {
            return maybe.Evaluate(
                value => value,
                () => default(T));
        }
    }
}