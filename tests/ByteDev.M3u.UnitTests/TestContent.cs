using System;

namespace ByteDev.M3u.UnitTests
{
    public static class TestContent
    {
        private const string NewLineWin = "\r\n";
        private const string NewLineUnix = "\n";

        public const string ContentExtended = "#EXTM3U";

        public static class PlaylistTitle
        {
            public const string HasTitle = "#EXTM3U" + NewLineWin + 
                                           "#PLAYLIST:My Title";

            public const string HasTitleWs = "#EXTM3U" + NewLineWin + 
                                             "#PLAYLIST: My Title ";

            public const string HasTitleEmpty = "#EXTM3U" + NewLineWin + 
                                                "#PLAYLIST:";

            public const string HasTitleNotExtended = "#PLAYLIST:My Title";
        }

        public static class Encoding
        {
            public const string HasUtf8Encoding = "#EXTM3U" + NewLineWin +
                                                  "#EXTENC: UTF-8";

            public const string HasUtf8EncodingOnThirdLine = "#EXTM3U" + NewLineWin +
                                                             "#PLAYLIST:" + NewLineWin +
                                                             "#EXTENC: UTF-8";
        }

        public static class Entries
        {
            public const string Has1Entry = "#EXTM3U" + NewLineWin +
                                            "MyFile1.mp3";

            public const string Has2Entry = 
                "#EXTM3U" + NewLineWin +
                "#EXTINF:111, Some Artist 1 - Some Track Title 1" + NewLineWin +
                "MyFile1.mp3" + NewLineWin +
                "#This is just a comment" + NewLineWin +
                "#EXTINF:222, Some Artist 2 - Some Track Title 2" + NewLineWin +
                "#EXTALB:Some Album Info" + NewLineWin +
                "#EXTART:Some Album Artist" + NewLineWin +
                "#EXTGENRE:Some Album Genre" + NewLineWin +
                NewLineWin +
                "#EXTBYT:12345" + NewLineWin +
                "#EXTIMG:cover.png" + NewLineWin +
                "#EXTGRP:Action Movies" + NewLineUnix +
                "MyFile2.mp3";
        }

        public static class Complete
        {
            public const string SimpleTwoEntries =
                "# Simple two entries" + NewLineUnix +
                "MyFile1.mp3" + NewLineWin +
                "MyFile2.mp3" + NewLineUnix;

            public const string SimpleThreeUnsortedEntries =
                "# Simple two entries" + NewLineUnix +
                "MyFile1.mp3" + NewLineWin +
                "MyFile3.mp3" + NewLineUnix +
                "MyFile2.mp3" + NewLineUnix;

            public static readonly string SimpleTwoEntriesToString =
                "MyFile1.mp3" + Environment.NewLine +
                "MyFile2.mp3";

            public const string ExtendedTwoEntries = 
                "#EXTM3U" + NewLineWin +
                "#EXTENC: UTF-8" + NewLineWin +
                "#PLAYLIST: My Title " + NewLineWin +
                "#EXTINF:111, Some Artist 1 - Some Track Title 1" + NewLineWin +
                "MyFile1.mp3" + NewLineWin +
                "#This is just a comment" + NewLineWin +
                "#EXTINF:222, Some Artist 2 - Some Track Title 2" + NewLineWin +
                "#EXTALB:Some Album Info" + NewLineWin +
                "#EXTART:Some Album Artist" + NewLineWin +
                "#EXTGENRE:Some Album Genre" + NewLineWin +
                NewLineWin +
                "#EXTBYT:12345" + NewLineWin +
                "#EXTIMG:cover.png" + NewLineWin +
                "#EXTGRP:Action Movies" + NewLineUnix +
                "MyFile2.mp3";

            public static readonly string ExtendedTwoEntriesToString =
                "#EXTM3U" + Environment.NewLine +
                "#EXTENC:UTF-8" + Environment.NewLine +
                "#PLAYLIST:My Title" + Environment.NewLine +
                
                "#EXTINF:111, Some Artist 1 - Some Track Title 1" + Environment.NewLine +
                "MyFile1.mp3" + Environment.NewLine +

                "#EXTINF:222, Some Artist 2 - Some Track Title 2" + Environment.NewLine +
                "#EXTALB:Some Album Info" + Environment.NewLine +
                "#EXTART:Some Album Artist" + Environment.NewLine +
                "#EXTGENRE:Some Album Genre" + Environment.NewLine +
                "#EXTBYT:12345" + Environment.NewLine +
                "#EXTIMG:cover.png" + Environment.NewLine +
                "#EXTGRP:Action Movies" + Environment.NewLine +
                "MyFile2.mp3";

            public const string ExtendedThreeUnsortedEntries = 
                "#EXTM3U" + NewLineWin +
                "#EXTENC: UTF-8" + NewLineWin +
                "#PLAYLIST: My Title " + NewLineWin +
                "#EXTINF:111, Some Artist 1 - Some Track Title 1" + NewLineWin +
                "MyFile3.mp3" + NewLineWin +
                "#This is just a comment" + NewLineWin +
                "#EXTINF:222, Some Artist 2 - Some Track Title 2" + NewLineWin +
                "#EXTALB:Some Album Info" + NewLineWin +
                "#EXTART:Some Album Artist" + NewLineWin +
                "#EXTGENRE:Some Album Genre" + NewLineWin +
                NewLineWin +
                "#EXTBYT:12345" + NewLineWin +
                "#EXTIMG:cover.png" + NewLineWin +
                "#EXTGRP:Action Movies" + NewLineUnix +
                "MyFile1.mp3" +
                NewLineWin +
                "#EXTBYT:12345" + NewLineWin +
                "#EXTIMG:cover.png" + NewLineWin +
                "#EXTGRP:Action Movies" + NewLineUnix +
                "MyFile2.mp3";
        }
    }
}