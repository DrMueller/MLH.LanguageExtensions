using System.Diagnostics;

namespace Mmu.Mlh.LanguageExtensions.Areas.Proxies.Implementation
{
    internal class ProcessProxy : IProcessProxy
    {
        public void Start(string fileName)
        {
            Process.Start(fileName);
        }
    }
}