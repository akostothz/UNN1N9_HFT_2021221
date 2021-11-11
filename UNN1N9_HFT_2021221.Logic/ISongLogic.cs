using System.Collections.Generic;
using UNN1N9_HFT_2021221.Models;

namespace UNN1N9_HFT_2021221.Logic
{
    interface ISongLogic
    {
        void Create(Song song);
        void Delete(int id);
        Song Read(int id);
        IEnumerable<Song> ReadAll();
        void Update(Song song);
    }
}