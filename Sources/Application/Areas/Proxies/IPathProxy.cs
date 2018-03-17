namespace Mmu.Mlh.LanguageExtensions.Areas.Proxies
{
    public interface IPathProxy
    {
        string ChangeExtension(string path, string extension);

        string Combine(params string[] paths);

        string GetDirectoryName(string path);

        string GetExtension(string path);

        string GetFileName(string path);

        string GetTempPath();
    }
}