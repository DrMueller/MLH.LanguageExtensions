using System;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Options.Implementation;

namespace Mmu.Mlh.LanguageExtensions.Areas.Types.Options
{
    public static class Option
    {
        public static Option<T> CreateApplicable<T>(T optionValue)
        {
            return new ApplicableOption<T>(optionValue);
        }

        public static Option<T> CreateNotApplicable<T>(bool treatAsEqualsTrue)
        {
            return new NotApplicableOption<T>(treatAsEqualsTrue);
        }
    }

    public abstract class Option<T> : IEquatable<Option<T>>, IEquatable<T>
    {
        public abstract bool IsApplicable { get; }
        public abstract T OptionValue { get; }

        public abstract bool Equals(Option<T> other);

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

            return obj.GetType() == GetType() && Equals((Option<T>)obj);
        }

        public abstract override int GetHashCode();

        public static bool operator ==(Option<T> a, Option<T> b)
        {
            return ReferenceEquals(null, a) && ReferenceEquals(null, b) ||
                !ReferenceEquals(null, a) && a.Equals(b);
        }

        public static bool operator ==(Option<T> a, T b)
        {
            return !ReferenceEquals(null, a) && a.Equals(b);
        }

        public static implicit operator Option<T>(T optionValue)
        {
            return ToOption(optionValue);
        }

        public static bool operator !=(Option<T> a, Option<T> b)
        {
            return !(a == b);
        }

        public static bool operator !=(Option<T> a, T b)
        {
            return !(a == b);
        }

        public static Option<TOpt> ToOption<TOpt>(TOpt optionValue)
        {
            return Option.CreateApplicable(optionValue);
        }
    }
}