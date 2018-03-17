namespace Mmu.Mlh.LanguageExtensions.Areas.DeepCopying
{
    public interface IDeepCopyService
    {
        T DeepCopy<T>(T source);
    }
}