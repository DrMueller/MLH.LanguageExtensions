using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Mmu.Mlh.LanguageExtensions.Areas.Markdown
{
    public static class MarkdownTableFactory
    {
        public static string Create<T>(IReadOnlyCollection<T> items)
        {
            if (!items.Any())
            {
                return string.Empty;
            }

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            if (!properties.Any())
            {
                return string.Empty;
            }

            var columnWidths = properties
                .Select(p => Math.Max(
                    p.Name.Length,
                    items.Max(item => p.GetValue(item)?.ToString()?.Length ?? 0)
                )).ToArray();

            var markdownBuilder = new StringBuilder();

            var headerRow = string.Join(" | ", properties.Select((p, i) => p.Name.PadRight(columnWidths[i])));
            markdownBuilder.AppendLine(headerRow);

            var separatorRow = string.Join(" | ", columnWidths.Select(w => new string('-', w)));
            markdownBuilder.AppendLine(separatorRow);

            foreach (var item in items)
            {
                var row = string.Join(" | ", properties.Select((p, i) =>
                    (p.GetValue(item)?.ToString() ?? string.Empty).PadRight(columnWidths[i])));
                markdownBuilder.AppendLine(row);
            }

            var sb = markdownBuilder.ToString();

            return sb.Trim();
        }
    }
}