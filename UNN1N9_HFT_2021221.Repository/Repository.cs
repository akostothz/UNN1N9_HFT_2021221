using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNN1N9_HFT_2021221.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext ctx;
        public Repository(DbContext ctx)
        {
            this.ctx = ctx;
        }
        public abstract void Create(T item);

        public abstract void Delete(int id);

        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }

        public abstract T ReadOne(int id);

        public abstract void Update(T item);
    }
}
