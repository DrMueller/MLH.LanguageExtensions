using System;
using System.IO;
using System.Reflection;

namespace Mmu.Mlh.LanguageExtensions.Areas.Assemblies.Extensions
{
    public static class AssemblyExtensions
    {
        public static string GetBasePath(this Assembly assembly)
        {
            var uri = new UriBuilder(assembly.CodeBase);
            var result = Uri.UnescapeDataString(uri.Path);
            result = Path.GetDirectoryName(result);

            return result;
        }
    }
}