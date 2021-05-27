using System.Text;

namespace ByteDev.M3u
{
    /// <summary>
    /// Represents a resource entry in the M3U format file.
    /// </summary>
    public class M3uResource
    {
        /// <summary>
        /// Track information. Often in the format: "[runtime in seconds],[display info]"
        /// </summary>
        public string TrackInfo { get; internal set; }

        /// <summary>
        /// Album information. Usually the album title.
        /// </summary>
        public string AlbumInfo { get; internal set; }

        /// <summary>
        /// Album artist.
        /// </summary>
        public string AlbumArtist { get; internal set; }

        /// <summary>
        /// Album genre.
        /// </summary>
        public string AlbumGenre { get; internal set; }

        /// <summary>
        /// File size in bytes.
        /// </summary>
        public string FileSize { get; internal set; }

        /// <summary>
        /// Cover image file.
        /// </summary>
        public string CoverImage { get; internal set; }

        /// <summary>
        /// Begin named grouping.
        /// </summary>
        public string Grouping { get; internal set; }

        /// <summary>
        /// Location to the resource. This can be either a relative local path, absolute local path or URI.
        /// </summary>
        public string Location { get; internal set; }

        /// <summary>
        /// Returns the string representation of the resource in M3U format.
        /// </summary>
        /// <returns>String representation of the resource.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendDirective(DirectiveNames.Resource.TrackInfo, TrackInfo);
            sb.AppendDirective(DirectiveNames.Resource.AlbumInfo, AlbumInfo);
            sb.AppendDirective(DirectiveNames.Resource.AlbumArtist, AlbumArtist);
            sb.AppendDirective(DirectiveNames.Resource.AlbumGenre, AlbumGenre);
            sb.AppendDirective(DirectiveNames.Resource.FileSize, FileSize);
            sb.AppendDirective(DirectiveNames.Resource.CoverImage, CoverImage);
            sb.AppendDirective(DirectiveNames.Resource.Grouping, Grouping);

            sb.Append(Location);

            return sb.ToString();
        }
    }
}