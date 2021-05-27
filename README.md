[![Build status](https://ci.appveyor.com/api/projects/status/github/bytedev/ByteDev.M3u?branch=master&svg=true)](https://ci.appveyor.com/project/bytedev/ByteDev-M3u/branch/master)
[![NuGet Package](https://img.shields.io/nuget/v/ByteDev.M3u.svg)](https://www.nuget.org/packages/ByteDev.M3u)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/ByteDev/ByteDev.M3u/blob/master/LICENSE)

# ByteDev.M3u

.NET Standard library to help handle playlists in the M3U format.

## Installation

ByteDev.M3u is hosted as a package on nuget.org.  To install from the Package Manager Console in Visual Studio run:

`Install-Package ByteDev.M3u`

Further details can be found on the [nuget page](https://www.nuget.org/packages/ByteDev.M3u/).

## Release Notes

Releases follow semantic versioning.

Full details of the release notes can be viewed on [GitHub](https://github.com/ByteDev/ByteDev.M3u/blob/master/docs/RELEASE-NOTES.md).

## M3U Format & Library Support

The library supports both M3U simple format and M3U extended format (mostly).

Example of playlist content in simple M3U format:

```
https://somewhere/some/resource
C:\Sample.mp3
Greatest Hits\My Song.mp3
# This is a comment
```

Example of playlist content in M3U extended format describing two resources:

```
#EXTM3U
#EXTINF:180, Sample artist - Sample title
Sample.mp3
#EXTINF:240,Example Artist - Example title
Greatest Hits\Example.ogg
```

Notes on library support:

- Empty lines are ignored.
- Both Windows (`\r\n`) and Unix (`\n`) line endings are supported.
- Comments:
  - Are supported using the hash `#` character as the first character on a line.
  - Are ignored by the library.
- Extended M3U format content:
  - Must have the extended header directive (`#EXTM3U`) on the first line.
  - Must have any encoding directive (`#EXTENC:`) on the second line.
  - Resources always have their location (path, URI etc.) on the last line of each resource entry.
- Extended M3U format directives supported:
  - `#EXTM3U` - Playlist header.
  - `#EXTENC:` - Playlist encoding.
  - `#PLAYLIST:` - Playlist title.
  - `#EXTINF:` - Resource track info.
  - `#EXTGRP:` - Resource grouping.
  - `#EXTALB:` - Resource album info.
  - `#EXTART:` - Resource album artist.
  - `#EXTGENRE:` - Resource album genre.
  - `#EXTBYT:` - Resource file size in bytes.
  - `#EXTIMG:` - Resource cover image file.

## Usage

Example of initialization via class constructor:

```csharp
string content = 
    "#EXTM3U\n" +
    "#EXTENC: UTF-8\n" +
    "#PLAYLIST: My Sample Playlist\n" +
    "#EXTINF:180, Sample artist - Sample title\n" +
    "Sample.mp3"

var pl = new M3uPlaylist(content);

// pl.IsExtended == true
// pl.Encoding == "UTF-8"
// pl.PlaylistTitle == "My Sample Playlist"
// pl.Resources.Single().TrackInfo == "180, Sample artist - Sample title"
// pl.Location = "Sample.mp3"
```

Example of initialization via `Load` method:

```csharp
var pl = M3uPlaylist.Load(@"C:\Playlists\MyPlaylist.m3u");
```