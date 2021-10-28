using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNN1N9_HFT_2021221.Models;

namespace UNN1N9_HFT_2021221.Repository
{
    public interface IArtistRepository
    {
        void Create(Artist item);
        Artist Read(int id);
        IQueryable<Artist> ReadAll();
        void Update(Artist item);
        void Delete(int id);
    }
}
