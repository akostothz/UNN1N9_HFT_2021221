using System.Collections.Generic;
using UNN1N9_HFT_2021221.Models;

namespace UNN1N9_HFT_2021221.Logic
{
    public interface ISongLogic
    {
        void Create(Song song);
        void Delete(int id);
        Song Read(int id);
        IEnumerable<Song> ReadAll();
        void Update(Song song);
        IEnumerable<KeyValuePair<string, double>> AVGLengthByAlbums();
        IEnumerable<KeyValuePair<string, int>> NumberOfExplicitSongsByArtists();
        IEnumerable<KeyValuePair<string, int>> LengthOfAllSongsByCountries();
        IEnumerable<KeyValuePair<string, int>> NumberOfLoveSongsAfter2015ByArtists();
    }
}