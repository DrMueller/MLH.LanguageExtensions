using System.IO;

namespace Mmu.Mlh.LanguageExtensions.Areas.Proxies.Implementation
{
    internal class FileProxy : IFileProxy
    {
        public void Delete(string path)
        {
            File.Delete(path);
        }

        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public string[] ReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }

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