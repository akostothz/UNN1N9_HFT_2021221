using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNN1N9_HFT_2021221.Logic;
using UNN1N9_HFT_2021221.Models;
using UNN1N9_HFT_2021221.Repository;

namespace UNN1N9_HFT_2021221.Test
{
    [TestFixture]
    public class SongLogicTests
    {
        SongLogic songLogic;
        public SongLogicTests()
        {
            Album fakeAlbum = new Album() { AlbumName = "#000000 & #FFFFFF" };

            var songs = new List<Song>()
                {
                    new Song() { SongName = "Unfair", Length = 2, Album = fakeAlbum },
                    new Song() { SongName = "#icanteven", Length = 5, Album = fakeAlbum }
                }.AsQueryable();

            var mockSongRepo = new Mock<ISongRepository>();

            mockSongRepo.Setup((t) => t.ReadAll()).Returns(songs);

            songLogic = new SongLogic(mockSongRepo.Object);


            //songLogic = new SongLogic(new FakeSongRepository());
        }

        [Test]
        public void AVGLengthByAlbumsTest()
        {
            var result = songLogic.AVGLengthByAlbums().ToArray();

            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, double>("#000000 & #FFFFFF", 3.5)));
        }

        [Test]
        public void CreateSongWithNegativeLengthTest()
        {
            Assert.Throws(typeof(ArgumentException), () => songLogic.Create(new Song() { Length = -1 }));
        }


        class FakeSongRepository : ISongRepository
        {
            public void Create(Song item)
            {
                throw new NotImplementedException();
            }

            public void Delete(int id)
            {
                throw new NotImplementedException();
            }

            public Song Read(int id)
            {
                throw new NotImplementedException();
            }

            public IQueryable<Song> ReadAll()
            {
                Album fakeAlbum = new Album() { AlbumName = "#000000 & #FFFFFF" };

                return new List<Song>()
                {
                    new Song() { SongName = "Unfair", Length = 2, Album = fakeAlbum },
                    new Song() { SongName = "#icanteven", Length = 5, Album = fakeAlbum }
                }.AsQueryable();
            }

            public void Update(Song item)
            {
                throw new NotImplementedException();
            }
        }

    }
}
