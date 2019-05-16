namespace Mmu.Mlh.LanguageExtensions.Areas.Strings.StringCutting.Services
{
    public interface IStringCutter
    {
        IStringCutter Cut(int length, out string str);
    }
}