using NUnit.Framework;

namespace ByteDev.M3u.IntTests
{
    [TestFixture]
    public class M3uPlaylistTests
    {
        [TestFixture]
        public class Load : M3uPlaylistTests
        {
            [Test]
            public void WhenFileExists_ThenLoad()
            {
                var sut = M3uPlaylist.Load("TestPlaylist1.m3u");

                Assert.That(sut.IsExtended, Is.True);
                Assert.That(sut.Resources.Count, Is.EqualTo(3));
            }
        }
    }
}