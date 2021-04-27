using ASPNETCore.Context;
using ASPNETCore.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories
{
    public class GeneralRepository<Entity, TId> : IGenericRepository<Entity, TId> where Entity : class
    {
        private readonly MyContext context;
        private DbSet<Entity> entities;
        string errorMessage = string.Empty;

        public int Delete(TId Id)
        {
            var deleted = entities.Find(Id);
            entities.Remove(deleted);
            var result = context.SaveChanges();
            return result;
        }

        public IEnumerable<Entity> GetAll()
        {
            var get = entities.ToList();
            return get;
        }

        public Entity GetById(TId Id)
        {
            var GetById = entities.Find(Id);
            return GetById;
        }

        public int Post(Entity obj)
        {
            entities.Add(obj);
            var result = context.SaveChanges();
            return result;
        }

        public int Put(Entity obj)
        {
            entities.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
            var result = context.SaveChanges();
            return result;
        }
    }
}
