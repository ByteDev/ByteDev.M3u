using System;
using System.Text;

namespace ByteDev.M3u
{
    internal static class StringBuilderExtensions
    {
        public static void AppendDirective(this StringBuilder source, string name)
        {
            source.Append(name);
            source.Append(Environment.NewLine);
        }

        public static void AppendDirective(this StringBuilder source, string name, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                source.Append(name);
                source.Append(value);
                source.Append(Environment.NewLine);
            }
        }
    }
}