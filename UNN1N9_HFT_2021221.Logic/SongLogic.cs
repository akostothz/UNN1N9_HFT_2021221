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

        #endregion
    }
}
