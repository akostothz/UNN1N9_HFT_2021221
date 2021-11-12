using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNN1N9_HFT_2021221.Models;
using UNN1N9_HFT_2021221.Repository;

namespace UNN1N9_HFT_2021221.Logic
{
    public class AlbumLogic : IAlbumLogic
    {
        IAlbumRepository albumRepo;

        public AlbumLogic(IAlbumRepository albumRepository)
        {
            this.albumRepo = albumRepository;
        }


        #region CRUDmethods

        public void Create(Album album)
        {
            if (album.AlbumName == String.Empty)
            {
                throw new ArgumentException("ERR :: The name of the album can not be empty.");
            }
            else if (album.Rating < 0 || album.Rating > 10)
            {
                throw new ArgumentException("ERR :: The rating of an album must be between 0 and 10.");
            }
            albumRepo.Create(album);
        }

        public Album Read(int id)
        {
            return albumRepo.Read(id);
        }

        public IEnumerable<Album> ReadAll()
        {
            return albumRepo.ReadAll();
        }

        public void Update(Album album)
        {
            albumRepo.Update(album);
        }

        public void Delete(int id)
        {
            albumRepo.Delete(id);
        }

        #endregion


        #region NON-CRUDmethods

        //number of albums with bigger rating than 8 by countries
        public IEnumerable<KeyValuePair<string, int>> NumberOfAlbumsWBiggerRatingThan8ByCountries()
        {
            return from x in albumRepo.ReadAll()
                   where x.Rating >= 8
                   group x by x.Artist.CountryOfOrigin into g
                   select new KeyValuePair<string, int>
                   (g.Key, g.Count());
        }

        #endregion
    }
}
