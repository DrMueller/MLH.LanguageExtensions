using System.IO;

namespace Mmu.Mlh.LanguageExtensions.Areas.Proxies.Implementation
{
    internal class FileProxy : IFileProxy
    {
        public void Delete(string path)
        {
            File.Delete(path);
        }

        public bool Exists(string path) => File.Exists(path);

        public string[] ReadAllLines(string path) => File.ReadAllLines(path);

        public string ReadAllText(string path)
        {
            var result = File.ReadAllText(path);
            return result;
        }

        public void WriteAllLines(string path, string[] contents)
        {
            File.WriteAllLines(path, contents);
        }

        public void WriteAllText(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }
    }
}