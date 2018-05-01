using System;
using Mmu.Mlh.LanguageExtensions.Areas.Maybes.Implementation;

namespace Mmu.Mlh.LanguageExtensions.Areas.Maybes
{
    public static class Maybe
    {
        public static Maybe<T> CreateFromNullable<T>(T possiblyNull) =>
            possiblyNull == null ? CreateNone<T>() : CreateSome(possiblyNull);

        public static Maybe<T> CreateNone<T>() => new NoneMaybe<T>();

        public static Maybe<T> CreateSome<T>(T value) => new SomeMaybe<T>(value);
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

        public static bool operator ==(Maybe<T> a, Maybe<T> b) => ReferenceEquals(null, a) && ReferenceEquals(null, b) ||
            !ReferenceEquals(null, a) && a.Equals(b);

        public static bool operator ==(Maybe<T> a, T b) => !ReferenceEquals(null, a) && a.Equals(b);

        public static bool operator !=(Maybe<T> a, Maybe<T> b) => !(a == b);

        public static bool operator !=(Maybe<T> a, T b) => !(a == b);

        public abstract T Reduce(Func<T> whenNone);

        public abstract T Reduce(T whenNone);
    }
}