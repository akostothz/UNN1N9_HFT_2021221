using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNN1N9_HFT_2021221.Repository
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        T ReadOne(int id);
        IQueryable<T> ReadAll();
        void Update(T item);
        void Delete(int id);
    }
}
