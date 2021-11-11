using System.Collections.Generic;
using UNN1N9_HFT_2021221.Models;

namespace UNN1N9_HFT_2021221.Logic
{
    interface IArtistLogic
    {
        void Create(Artist artist);
        void Delete(int id);
        Artist Read(int id);
        IEnumerable<Artist> ReadAll();
        void Update(Artist artist);
    }
}