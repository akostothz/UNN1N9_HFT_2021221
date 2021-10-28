using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNN1N9_HFT_2021221.Models;

namespace UNN1N9_HFT_2021221.Repository
{
    public interface IAlbumRepository
    {
        void Create(Album item);
        Album Read(int id);
        IQueryable<Album> ReadAll();
        void Update(Album item);
        void Delete(int id);
    }
}
