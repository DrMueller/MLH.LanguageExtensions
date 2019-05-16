using System;

namespace Mmu.Mlh.LanguageExtensions.Areas.Strings.Extensions
{
    public static class StringExtensions
    {
        public static string AppendIfNotEndingWith(this string str, string toAppend)
        {
            if (str.EndsWith(toAppend, StringComparison.Ordinal))
            {
                return str;
            }

            return str + toAppend;
        }
    }
}