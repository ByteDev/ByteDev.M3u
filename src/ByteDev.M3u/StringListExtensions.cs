using System.Collections.Generic;
using System.Linq;

namespace ByteDev.M3u
{
    internal static class StringListExtensions
    {
        public static bool IsExtended(this IList<string> source)
        {
            var firstLine = source.GetLineNumber(1);

            return firstLine != null && firstLine.StartsWith(DirectiveNames.File.Header);
        }

        public static string GetEncoding(this IList<string> source)
        {
            var line = source.GetLineNumber(2);

            return line.GetDirectiveValue(DirectiveNames.File.Encoding);
        }

        public static string GetDirectiveValue(this IList<string> source, string name)
        {
            var line = source.FirstOrDefault(l => l.StartsWith(name));

            return line?.GetDirectiveValue(name);
        }

        public static string GetLineNumber(this IList<string> source, int number)
        {
            return source?.Count >= number ? source[number - 1] : null;
        }
    }
}