using ASPNETCore.Context;
using ASPNETCore.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories
{
    public class GeneralRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MyContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public void Delete(object Id)
        {
            var deleted = entities.Find(Id);
            entities.Remove(deleted);
            context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            var get = entities.ToList();
            return get;
        }

        public T GetById(object Id)
        {
            var GetById = entities.Find(Id);
            return GetById;
        }

        public void Post(T obj)
        {
            entities.Add(obj);
            context.SaveChanges();
        }

        public void Put(T obj)
        {
            entities.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
