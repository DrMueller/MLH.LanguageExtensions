using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mmu.Mlh.LanguageExtensions.Areas.StringBuilders
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendLineWithIndentation(this StringBuilder sb, string value, int indentationSize)
        {
            return sb.AppendLine(AppendIndentation(value, indentationSize));
        }

        public static StringBuilder AppendWithIndentation(this StringBuilder sb, string value, int indentationSize)
        {
            return sb.Append(AppendIndentation(value, indentationSize));
        }

        public static void AppendWithSeperatorExceptLast(this StringBuilder sb, IReadOnlyCollection<string> values, string seperator)
        {
            for (var i = 0; i < values.Count; i++)
            {
                sb.Append(values.ElementAt(i));
                if (i + 1 < values.Count)
                {
                    sb.Append(seperator);
                }
            }
        }

        private static string AppendIndentation(string value, int indentationSize)
        {
            var emptyStr = new string(' ', indentationSize);
            return emptyStr + value;
        }
    }
}