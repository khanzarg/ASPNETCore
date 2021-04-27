using ASPNETCore.Context;
using ASPNETCore.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repository
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : class
    {
        private MyContext context;
        private DbSet<T> dbSet;

        public GeneralRepository()
        {
            this.context = new MyContext();
            dbSet = context.Set<T>();
        }

        public GeneralRepository(MyContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public void Insert(T obj)
        {
            dbSet.Add(obj);
        }

        public void Update(T obj)
        {
            dbSet.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = dbSet.Find(id);
            dbSet.Remove(existing);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
