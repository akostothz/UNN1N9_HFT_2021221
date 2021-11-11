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

        #endregion
    }
}
