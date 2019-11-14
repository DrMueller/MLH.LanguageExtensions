namespace Mmu.Mlh.LanguageExtensions.Areas.Types.Options.Implementation
{
    public sealed class NotApplicableOption<T> : Option<T>
    {
        private readonly bool _treatAsEqualsTrue;

        public override bool IsApplicable => false;
        public override T OptionValue => default;

        public NotApplicableOption(bool treatAsEqualsTrue)
        {
            _treatAsEqualsTrue = treatAsEqualsTrue;
        }

        public override bool Equals(Option<T> other)
        {
            return _treatAsEqualsTrue;
        }

        public override bool Equals(T other)
        {
            return _treatAsEqualsTrue;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}