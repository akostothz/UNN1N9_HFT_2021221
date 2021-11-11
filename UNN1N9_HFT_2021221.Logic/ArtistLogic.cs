using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNN1N9_HFT_2021221.Models;
using UNN1N9_HFT_2021221.Repository;

namespace UNN1N9_HFT_2021221.Logic
{
    public class ArtistLogic : IArtistLogic
    {
        IArtistRepository artistRepo;

        public ArtistLogic(IArtistRepository artistRepository)
        {
            this.artistRepo = artistRepository;
        }


        #region CRUDmethods

        public void Create(Artist artist)
        {
            artistRepo.Create(artist);
        }

        public Artist Read(int id)
        {
            return artistRepo.Read(id);
        }

        public IEnumerable<Artist> ReadAll()
        {
            return artistRepo.ReadAll();
        }

        public void Update(Artist artist)
        {
            artistRepo.Update(artist);
        }

        public void Delete(int id)
        {
            artistRepo.Delete(id);
        }

        #endregion


        #region NON-CRUDmethods

        #endregion
    }
}
