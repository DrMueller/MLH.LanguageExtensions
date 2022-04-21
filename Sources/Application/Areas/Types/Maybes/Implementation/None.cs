using System.Diagnostics.CodeAnalysis;

namespace Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes.Implementation
{
    // This is a helper, saving some generic boilerplate
    public class None
    {
        private None()
        {
        }

        public static None Value { get; } = new None();
    }

    [SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "It makes sense to keep these Classes together")]
    public sealed class None<T> : Maybe<T>
    {
        public override bool Equals(Maybe<T> other)
        {
            return Equals(other as None<T>);
        }

        public override bool Equals(T other)
        {
            return false;
        }

        public bool Equals(None<T>? other)
        {
            return !ReferenceEquals(null, other);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}