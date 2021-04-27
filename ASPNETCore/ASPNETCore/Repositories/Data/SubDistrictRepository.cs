using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Data
{
    public class SubDistrictRepository<T> : IGenericRepository<T> where T : SubDistrict {
        private readonly MyContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public IEnumerable<T> Get()
        {
            return entities.AsEnumerable();
        }


        public T GetById(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }


        public void Post(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }


        public void Put(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }


        public void Delete(object id)
        {
            T entitiesId = entities.Find(id);
            entities.Remove(entitiesId);
            context.SaveChanges();
        }
        public void Save()
        {
            context.SaveChanges();
        }


    }

    
}
