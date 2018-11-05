namespace Mmu.Mlh.LanguageExtensions.Areas.Types.Options.Implementation
{
    public sealed class ApplicableOption<T> : Option<T>
    {
        public override bool IsApplicable => true;
        public override T OptionValue { get; }

        public ApplicableOption(T optionValue)
        {
            OptionValue = optionValue;
        }

        public override bool Equals(Option<T> other)
        {
            return Equals(other as ApplicableOption<T>);
        }

        public override bool Equals(T other)
        {
            return OptionValueEquals(other);
        }

        public bool Equals(ApplicableOption<T> other)
        {
            return !ReferenceEquals(null, other) && OptionValueEquals(other.OptionValue);
        }

        public override int GetHashCode()
        {
            return OptionValue.GetHashCode();
        }

        private bool OptionValueEquals(T other)
        {
            if (ReferenceEquals(null, OptionValue) && ReferenceEquals(null, other))
            {
                return true;
            }

            if (!ReferenceEquals(null, OptionValue) && OptionValue.Equals(other))
            {
                return true;
            }

            return false;
        }
    }
}