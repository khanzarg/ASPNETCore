using ASPNETCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repository.Interface
{
    public class GeneralRepository<T> : IGenericRepository<T> where T : class
    {
        private MyContext _context = null;
        private DbSet<T> table = null;
        

        public void Delete(object id)
        {
            T entityToDelete = table.Find(id);
            //Delete(entityToDelete);

            table.Remove(entityToDelete);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}
