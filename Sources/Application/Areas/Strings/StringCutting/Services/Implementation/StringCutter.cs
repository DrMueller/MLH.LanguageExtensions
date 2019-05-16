using System;

namespace Mmu.Mlh.LanguageExtensions.Areas.Strings.StringCutting.Services.Implementation
{
    internal class StringCutter : IStringCutter
    {
        private string _str;

        public StringCutter(string str)
        {
            _str = str;
        }

        public IStringCutter Cut(int length, out string str)
        {
            if (string.IsNullOrEmpty(_str))
            {
                str = string.Empty;
                return this;
            }

            length = Math.Min(length, _str.Length);
            str = _str.Substring(0, length).Trim();
            _str = _str.Substring(length);

            return this;
        }
    }
}