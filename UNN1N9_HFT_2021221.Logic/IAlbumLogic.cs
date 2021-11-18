using System.Collections.Generic;
using UNN1N9_HFT_2021221.Models;

namespace UNN1N9_HFT_2021221.Logic
{
    public interface IAlbumLogic
    {
        void Create(Album album);
        void Delete(int id);
        Album Read(int id);
        IEnumerable<Album> ReadAll();
        void Update(Album album);
        IEnumerable<KeyValuePair<string, int>> NumberOfAlbumsWBiggerRatingThan8ByCountries();
    }
}