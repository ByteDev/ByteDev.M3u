namespace ByteDev.M3u
{
    internal static class StringLineExtensions
    {
        public static bool IsLocation(this string source)
        {
            if (source == null)
                return false;

            if (source.Trim() == string.Empty)
                return false;

            return !source.IsComment();
        }

        public static bool IsComment(this string source)
        {
            if (source == null)
                return false;

            return source.StartsWith("#");
        }

        public static bool IsDirective(this string source)
        {
            if (!source.IsComment())
                return false;

            // A extension directive is a special kind of comment.

            return source.StartsWith(DirectiveNames.File.Header) ||
                   source.StartsWith(DirectiveNames.File.Encoding) ||
                   source.StartsWith(DirectiveNames.Resource.TrackInfo) ||
                   source.StartsWith(DirectiveNames.File.PlaylistTitle) ||
                   source.StartsWith(DirectiveNames.Resource.Grouping) ||
                   source.StartsWith(DirectiveNames.Resource.AlbumInfo) ||
                   source.StartsWith(DirectiveNames.Resource.AlbumArtist) ||
                   source.StartsWith(DirectiveNames.Resource.AlbumGenre) ||
                   source.StartsWith(DirectiveNames.Resource.FileSize) ||
                   source.StartsWith(DirectiveNames.Resource.CoverImage) ||
                   source.StartsWith("#EXTM3A") || // "playlist for tracks or chapters of an album in a single file"
                   source.StartsWith("#EXTBIN:");
        }

        public static string GetDirectiveValue(this string line, string name)
        {
            if (line != null && line.StartsWith(name))
            {
                return line.Substring(name.Length).Trim();
            }

            return null;
        }
    }
}