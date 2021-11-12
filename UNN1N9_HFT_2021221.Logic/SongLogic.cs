using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNN1N9_HFT_2021221.Models;
using UNN1N9_HFT_2021221.Repository;

namespace UNN1N9_HFT_2021221.Logic
{
    public class SongLogic : ISongLogic
    {
        ISongRepository songRepo;

        public SongLogic(ISongRepository songRepository)
        {
            this.songRepo = songRepository;
        }


        #region CRUDmethods

        public void Create(Song song)
        {
            if (song.SongName == String.Empty)
            {
                throw new ArgumentException("ERR :: The name of the song can not be empty.");
            }
            else if (song.Length <= 0)
            {
                throw new ArgumentException("ERR :: The length of the song can not be less or equal to zero.");
            }
            songRepo.Create(song);
        }

        public Song Read(int id)
        {
            return songRepo.Read(id);
        }

        public IEnumerable<Song> ReadAll()
        {
            return songRepo.ReadAll();
        }

        public void Update(Song song)
        {
            songRepo.Update(song);
        }

        public void Delete(int id)
        {
            songRepo.Delete(id);
        }

        #endregion


        #region NON-CRUDmethods

        //avg length by albums
        public IEnumerable<KeyValuePair<string, double>> AVGLengthByAlbums()
        {
            return from x in songRepo.ReadAll()
                   group x by x.Album.AlbumName into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(y => y.Length));
        }

        //explicit songs by artists
        public IEnumerable<KeyValuePair<string, int>> NumberOfExplicitSongsByArtists()
        {
            return from x in songRepo.ReadAll()
                   group x by x.Album.Artist.ArtistName into g
                   select new KeyValuePair<string, int>
                   (g.Key, g.Count(y => y.IsExplicit.Equals(true)));
        }

        //length of all songs by countries
        public IEnumerable<KeyValuePair<string, int>> LengthOfAllSongsByCountries()
        {
            return from x in songRepo.ReadAll()
                   group x by x.Album.Artist.CountryOfOrigin into g
                   select new KeyValuePair<string, int>
                   (g.Key, g.Sum(y => y.Length));
        }

        //number of love songs made after 2015 minutes by artists
        public IEnumerable<KeyValuePair<string, int>> NumberOfLoveSongsAfter2015ByArtists()
        {
            return from x in songRepo.ReadAll()
                   where x.Album.Year > 2015
                   group x by x.Album.Artist.ArtistName into g
                   select new KeyValuePair<string, int>
                   (g.Key, g.Count(y => y.IsLoveSong.Equals(true)));
        }

        #endregion
    }
}
