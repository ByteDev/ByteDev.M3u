using System;
using System.Linq;
using ByteDev.Collections;
using NUnit.Framework;

namespace ByteDev.M3u.UnitTests
{
    [TestFixture]
    public class M3uPlaylistTests
    {
        [TestFixture]
        public class Constructor : M3uPlaylistTests
        {
            [Test]
            public void WhenContentIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => _ = new M3uPlaylist(null));
            }
        }

        [TestFixture]
        public class IsExtended : M3uPlaylistTests
        {
            [TestCase("")]
            [TestCase(@"C:\somefile.txt")]
            public void WhenContentDoesNotStartWithExtensionHeader_ThenReturnFalse(string content)
            {
                var sut = new M3uPlaylist(content);

                Assert.That(sut.IsExtended, Is.False);
            }

            [Test]
            public void WhenHeaderOnFirstLine_ThenReturnTrue()
            {
                var sut = new M3uPlaylist(TestContent.ContentExtended);

                Assert.That(sut.IsExtended, Is.True);
            }
        }

        [TestFixture]
        public class PlaylistTitle : M3uPlaylistTests
        {
            [Test]
            public void WhenHasTitle_ThenSet()
            {
                var sut = new M3uPlaylist(TestContent.PlaylistTitle.HasTitle);

                Assert.That(sut.PlaylistTitle, Is.EqualTo("My Title"));
            }

            [Test]
            public void WhenHasTitleWithWhitespace_ThenSet()
            {
                var sut = new M3uPlaylist(TestContent.PlaylistTitle.HasTitleWs);

                Assert.That(sut.PlaylistTitle, Is.EqualTo("My Title"));
            }

            [Test]
            public void WhenHasEmptyTitleValue_ThenSetEmpty()
            {
                var sut = new M3uPlaylist(TestContent.PlaylistTitle.HasTitleEmpty);

                Assert.That(sut.PlaylistTitle, Is.EqualTo(string.Empty));
            }

            [Test]
            public void WhenHasTitle_AndIsNotExtendend_ThenSetNull()
            {
                var sut = new M3uPlaylist(TestContent.PlaylistTitle.HasTitleNotExtended);

                Assert.That(sut.PlaylistTitle, Is.Null);
            }
        }

        [TestFixture]
        public class Encoding : M3uPlaylistTests
        {
            [Test]
            public void WhenHasEncoding_ThenSet()
            {
                var sut = new M3uPlaylist(TestContent.Encoding.HasUtf8Encoding);

                Assert.That(sut.Encoding, Is.EqualTo("UTF-8"));
            }

            [Test]
            public void WhenHasEncodingButNotOnSecondLine_ThenSetNull()
            {
                var sut = new M3uPlaylist(TestContent.Encoding.HasUtf8EncodingOnThirdLine);

                Assert.That(sut.Encoding, Is.Null);
            }

            [Test]
            public void WhenHasNoEncoding_ThenSetNull()
            {
                var sut = new M3uPlaylist(TestContent.ContentExtended);

                Assert.That(sut.Encoding, Is.Null);
            }
        }

        [TestFixture]
        public class Entries : M3uPlaylistTests
        {
            [Test]
            public void WhenHasNoEntries_ThenSetEmpty()
            {
                var sut = new M3uPlaylist(TestContent.ContentExtended);

                Assert.That(sut.Resources, Is.Empty);
            }

            [Test]
            public void WhenHasSingleEntry_ThenSetSingle()
            {
                var sut = new M3uPlaylist(TestContent.Entries.Has1Entry);

                Assert.That(sut.Resources.Single().Location, Is.EqualTo("MyFile1.mp3"));
            }

            [Test]
            public void WhenHasTwoEntries_ThenSetTwo()
            {
                var sut = new M3uPlaylist(TestContent.Entries.Has2Entry);

                Assert.That(sut.Resources.First().Location, Is.EqualTo("MyFile1.mp3"));
                Assert.That(sut.Resources.First().TrackInfo, Is.EqualTo("111, Some Artist 1 - Some Track Title 1"));
                
                Assert.That(sut.Resources.Second().Location, Is.EqualTo("MyFile2.mp3"));
                Assert.That(sut.Resources.Second().TrackInfo, Is.EqualTo("222, Some Artist 2 - Some Track Title 2"));
                Assert.That(sut.Resources.Second().AlbumInfo, Is.EqualTo("Some Album Info"));
                Assert.That(sut.Resources.Second().AlbumArtist, Is.EqualTo("Some Album Artist"));
                Assert.That(sut.Resources.Second().AlbumGenre, Is.EqualTo("Some Album Genre"));
                Assert.That(sut.Resources.Second().FileSize, Is.EqualTo("12345"));
                Assert.That(sut.Resources.Second().CoverImage, Is.EqualTo("cover.png"));
                Assert.That(sut.Resources.Second().Grouping, Is.EqualTo("Action Movies"));
            }
        }

        [TestFixture]
        public class ToStringOverride : M3uPlaylistTests
        {
            [Test]
            public void WhenExtendedTwoEntries_ThenReturnString()
            {
                var sut = new M3uPlaylist(TestContent.Complete.ExtendedTwoEntries);

                var result = sut.ToString();

                Assert.That(result, Is.EqualTo(TestContent.Complete.ExtendedTwoEntriesToString));
            }

            [Test]
            public void WhenSimpleTwoEntries_ThenReturnString()
            {
                var sut = new M3uPlaylist(TestContent.Complete.SimpleTwoEntries);

                var result = sut.ToString();

                Assert.That(result, Is.EqualTo(TestContent.Complete.SimpleTwoEntriesToString));
            }
        }

        [TestFixture]
        public class Load : M3uPlaylistTests
        {
            [Test]
            public void WhenPathIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => _ = M3uPlaylist.Load(null));
            }
        }
    }
}