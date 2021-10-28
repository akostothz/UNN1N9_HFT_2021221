using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNN1N9_HFT_2021221.Models;

namespace UNN1N9_HFT_2021221.Repository
{
    public interface ISongRepository
    {
        void Create(Song item);
        Song Read(int id);
        IQueryable<Song> ReadAll();
        void Update(Song item);
        void Delete(int id);
    }
}
