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

        private static string AppendIndentation(string value, int indentationSize)
        {
            var emptyStr = new string(' ', indentationSize);
            return emptyStr + value;
        }
    }
}