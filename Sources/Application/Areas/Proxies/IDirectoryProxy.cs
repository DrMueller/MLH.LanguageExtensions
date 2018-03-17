using System.Collections.Generic;

namespace Mmu.Mlh.LanguageExtensions.Areas.Proxies
{
    public interface IDirectoryProxy
    {
        void CreateDirectory(string path);

        bool Exists(string path);

        IReadOnlyCollection<string> GetFiles(string path);

        IReadOnlyCollection<string> GetFiles(string path, string searchPattern);
    }
}