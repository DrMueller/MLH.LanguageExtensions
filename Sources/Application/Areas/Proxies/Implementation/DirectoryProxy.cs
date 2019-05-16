using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mmu.Mlh.LanguageExtensions.Areas.Proxies.Implementation
{
    internal class DirectoryProxy : IDirectoryProxy
    {
        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public bool Exists(string path)
        {
            return Directory.Exists(path);
        }

        public IReadOnlyCollection<string> GetFiles(string path)
        {
            var result = Directory.GetFiles(path).ToList();
            return result;
        }

        public IReadOnlyCollection<string> GetFiles(string path, string searchPattern)
        {
            var result = Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories).ToList();
            return result;
        }
    }
}