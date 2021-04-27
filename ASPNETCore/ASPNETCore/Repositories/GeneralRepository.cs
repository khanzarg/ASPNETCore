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
        private MyContext _context = null;
        private DbSet<T> table = null;

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Post(T obj)
        {
            table.Add(obj);
            _context.SaveChanges();
        }

        public void Put(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
