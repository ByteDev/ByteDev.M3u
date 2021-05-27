using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ByteDev.Strings;

namespace ByteDev.M3u
{
    /// <summary>
    /// Represents a playlist in M3U format.
    /// </summary>
    public class M3uPlaylist
    {
        private IList<M3uResource> _resources;

        /// <summary>
        /// Indicates if the content is in Extended M3U format.
        /// </summary>
        public bool IsExtended { get; }

        /// <summary>
        /// Text encoding of the content. If used this should be specified on the second line.
        /// </summary>
        public string Encoding { get; }

        /// <summary>
        /// Playlist title.
        /// </summary>
        public string PlaylistTitle { get; }

        /// <summary>
        /// Playlist resource entries.
        /// </summary>
        public IList<M3uResource> Resources => _resources ?? (_resources = new List<M3uResource>());

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.M3u.M3uFile" /> class.
        /// </summary>
        /// <param name="content">M3U file contents.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="content" /> is null.</exception>
        public M3uPlaylist(string content)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            var lines = content.ToLinesList();

            IsExtended = lines.IsExtended();

            if (IsExtended)
            {
                Encoding = lines.GetEncoding();
                PlaylistTitle = lines.GetDirectiveValue(DirectiveNames.File.PlaylistTitle);
            }

            AddResources(lines);
        }

        /// <summary>
        /// Returns the string representation of the playlist in M3U format.
        /// </summary>
        /// <returns>String representation of the playlist.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            if (IsExtended)
                sb.AppendDirective(DirectiveNames.File.Header);
            
            sb.AppendDirective(DirectiveNames.File.Encoding, Encoding);
            sb.AppendDirective(DirectiveNames.File.PlaylistTitle, PlaylistTitle);

            foreach (var resource in Resources)
            {
                sb.Append(resource);
                sb.Append(Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// Loads a M3U playlist file from disk.
        /// </summary>
        /// <param name="filePath">Full path to the M3U file.</param>
        /// <returns><see cref="T:ByteDev.M3u.M3uPlaylist" /> created from the file.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="filePath" /> is null.</exception>
        /// <exception cref="T:System.IO.FileNotFoundException">M3U file does not exist.</exception>
        public static M3uPlaylist Load(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));

            var fileContents = File.ReadAllText(filePath);

            return new M3uPlaylist(fileContents);
        }

        private void AddResources(IEnumerable<string> lines)
        {
            var directives = new List<string>();

            foreach (var line in lines)
            {
                if (line.IsLocation())
                {
                    // Location delimits the end of the end of the entry

                    Resources.Add(new M3uResource
                    {
                        Location = line,
                        TrackInfo = directives.GetDirectiveValue(DirectiveNames.Resource.TrackInfo),
                        AlbumInfo = directives.GetDirectiveValue(DirectiveNames.Resource.AlbumInfo),
                        AlbumArtist = directives.GetDirectiveValue(DirectiveNames.Resource.AlbumArtist),
                        AlbumGenre = directives.GetDirectiveValue(DirectiveNames.Resource.AlbumGenre),
                        FileSize = directives.GetDirectiveValue(DirectiveNames.Resource.FileSize),
                        CoverImage = directives.GetDirectiveValue(DirectiveNames.Resource.CoverImage),
                        Grouping = directives.GetDirectiveValue(DirectiveNames.Resource.Grouping)
                    });

                    directives.Clear();
                }
                else if (line.IsDirective())
                {
                    directives.Add(line);
                }
            }
        }
    }

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