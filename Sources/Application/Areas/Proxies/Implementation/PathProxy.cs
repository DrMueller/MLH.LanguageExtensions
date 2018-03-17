using System.IO;

namespace Mmu.Mlh.LanguageExtensions.Areas.Proxies.Implementation
{
    public class PathProxy : IPathProxy
    {
        public string ChangeExtension(string path, string extension) => Path.ChangeExtension(path, extension);

        public string Combine(params string[] paths) => Path.Combine(paths);

        public string GetDirectoryName(string path) => Path.GetDirectoryName(path);

        public string GetExtension(string path) => Path.GetExtension(path);

        public string GetFileName(string path) => Path.GetFileName(path);

        public string GetTempPath() => Path.GetTempPath();
    }
}