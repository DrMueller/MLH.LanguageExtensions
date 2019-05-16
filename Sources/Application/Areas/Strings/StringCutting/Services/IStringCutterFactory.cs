namespace Mmu.Mlh.LanguageExtensions.Areas.Strings.StringCutting.Services
{
    public interface IStringCutterFactory
    {
        IStringCutter CreateFor(string str);
    }
}