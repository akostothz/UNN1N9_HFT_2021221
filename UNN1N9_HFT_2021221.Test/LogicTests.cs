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
    public class LogicTests
    {
        SongLogic songLogic;
        AlbumLogic albumLogic;
        public LogicTests()
        {
            Artist fakeArtist = new Artist() { ArtistName = "The Neighbourhood", CountryOfOrigin = "USA" };

            //songlogic setup          
            Album fakeAlbum = new Album() { AlbumName = "#000000 & #FFFFFF", Artist = fakeArtist, Year = 2016 };

            var songs = new List<Song>()
                {
                    new Song() { SongName = "Unfair", Length = 2, Album = fakeAlbum, IsLoveSong = true, SongID = 1 },
                    new Song() { SongName = "#icanteven", Length = 5, Album = fakeAlbum, IsExplicit = true, IsLoveSong = true }
                }.AsQueryable();

            var mockSongRepo = new Mock<ISongRepository>();
            mockSongRepo.Setup((t) => t.ReadAll()).Returns(songs);

            songLogic = new SongLogic(mockSongRepo.Object);

            //albumlogic setup
            var albums = new List<Album>()
            {
                new Album() { AlbumName = "The Two of Us Are Dying", Artist = fakeArtist, Rating = 8.3 },
                new Album() { AlbumName = "BALLADS 1", Artist = fakeArtist, Rating = 6.7 },
                new Album() { AlbumName = "Little Dark Age", Artist = fakeArtist, Rating = 9.8 },
                new Album() { AlbumName = "Oracular Spectacular", Artist = fakeArtist, Rating = 8.7 }
            }.AsQueryable();

            var mockAlbumrepo = new Mock<IAlbumRepository>();
            mockAlbumrepo.Setup((t) => t.ReadAll()).Returns(albums);

            albumLogic = new AlbumLogic(mockAlbumrepo.Object);
        }

        #region NON-CRUD.TESTS

        [Test]
        public void AVGLengthByAlbumsTest()
        {
            var result = songLogic.AVGLengthByAlbums().ToArray();

            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, double>("#000000 & #FFFFFF", 3.5)));
        }

        [Test]
        public void NumberOfExplicitSongsByArtistsTest()
        {
            var result = songLogic.NumberOfExplicitSongsByArtists().ToArray();

            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("The Neighbourhood", 1)));
        }

        [Test]
        public void LengthOfAllSongsByCountriesTest()
        {
            var result = songLogic.LengthOfAllSongsByCountries().ToArray();

            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("USA", 7)));
        }

        [Test]
        public void NumberOfLoveSongsAfter2015ByArtistsTest()
        {
            var result = songLogic.NumberOfLoveSongsAfter2015ByArtists().ToArray();

            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("The Neighbourhood", 2)));
        }

        [Test]
        public void NumberOfAlbumsWBiggerRatingThan8ByCountriesTest()
        {
            var result = albumLogic.NumberOfAlbumsWBiggerRatingThan8ByCountries().ToArray();

            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("USA", 3)));
        }

        #endregion

        #region CREATE.TESTS

        [Test]
        public void CreateSongWithNegativeLengthTest()
        {
            Assert.Throws(typeof(ArgumentException), () => songLogic.Create(new Song() { Length = -1 }));
        }

        [Test]
        public void CreateSongWithEmptyStringTest()
        {
            Assert.Throws(typeof(ArgumentException), () => songLogic.Create(new Song() { SongName = "" }));
        }

        [Test]
        public void CreateSongTest()
        {
            Assert.That(() => songLogic.Create(new Song() { SongName = "Cigarette Daydreams", Length = 3 }), Throws.Nothing);
        }

        #endregion

        #region OPTIONAL.TESTS

        [Test]
        public void UpdateSongWithNegativeLengthTest()
        {
            Assert.Throws(typeof(ArgumentException), () => songLogic.Update(new Song() { SongName = "Space Song", Length = -2 }));
        }

        [Test]
        public void DeleteSongWithNegativeIDTest()
        {
            Assert.Throws(typeof(ArgumentException), () => songLogic.Delete(-1));
        }

        #endregion
    }
}
