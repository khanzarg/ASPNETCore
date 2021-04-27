using ASPNETCore.Context;
using ASPNETCore.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : class
    {
        private MyContext _context = null;
        private DbSet<T> table = null;

        public GeneralRepository()
        {
            _context = new MyContext();
            table = _context.Set<T>();
        }

        public GeneralRepository(MyContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object Id)
        {
            return table.Find(Id);
        }

        public void Post(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object Id)
        {
            T existing = table.Find(Id);
            table.Remove(existing);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        
    }
}
