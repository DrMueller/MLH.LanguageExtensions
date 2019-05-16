using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.LanguageExtensions.Areas.Strings.StringCutting.Services.Implementation
{
    internal class StringCutterFactory : IStringCutterFactory
    {
        public IStringCutter CreateFor(string str)
        {
            Guard.StringNotNullOrEmpty(() => str);

            return new StringCutter(str);
        }
    }
}