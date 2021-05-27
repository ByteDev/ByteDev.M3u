namespace ByteDev.M3u
{
    internal static class DirectiveNames
    {
        internal static class File
        {
            /// <summary>
            /// File header. Must be the first line of the file.
            /// </summary>
            public const string Header = "#EXTM3U";

            public const string Encoding = "#EXTENC:";

            public const string PlaylistTitle = "#PLAYLIST:";
        }

        internal static class Resource
        {
            /// <summary>
            /// Track info. Typically for audio: runtime in seconds and display title of the following recources.
            /// </summary>
            public const string TrackInfo = "#EXTINF:";

            public const string Grouping = "#EXTGRP:";

            public const string AlbumInfo = "#EXTALB:";

            public const string AlbumArtist = "#EXTART:";

            public const string AlbumGenre = "#EXTGENRE:";

            public const string FileSize = "#EXTBYT:";

            public const string CoverImage = "#EXTIMG:";
        }
    }
}