using System;
using System.Diagnostics.CodeAnalysis;
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

    [SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "It makes sense to keep these Classes together")]
    public abstract class Option<T> : IEquatable<Option<T>>, IEquatable<T>
    {
        public abstract bool IsApplicable { get; }
        public abstract T OptionValue { get; }

        public static Option<TOpt> ToOption<TOpt>(TOpt optionValue)
        {
            return Option.CreateApplicable(optionValue);
        }

        public abstract bool Equals(Option<T> other);

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

            return obj.GetType() == GetType() && Equals((Option<T>)obj);
        }

        public abstract override int GetHashCode();

        public static bool operator ==(Option<T>? a, Option<T>? b)
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

        public static bool operator ==(Option<T>? a, T b)
        {
            return !ReferenceEquals(null, a) && a.Equals(b);
        }

        public static implicit operator Option<T>(T optionValue)
        {
            return ToOption(optionValue);
        }

        public static bool operator !=(Option<T>? a, Option<T>? b)
        {
            return !(a == b);
        }

        public static bool operator !=(Option<T>? a, T b)
        {
            return !(a == b!);
        }
    }
}