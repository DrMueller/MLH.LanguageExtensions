namespace Mmu.Mlh.LanguageExtensions.Areas.Proxies
{
    public interface IFileProxy
    {
        void Delete(string path);

        bool Exists(string path);

        string[] ReadAllLines(string path);

        string ReadAllText(string path);

        void WriteAllLines(string path, string[] contents);

        void WriteAllText(string path, string contents);
    }
}