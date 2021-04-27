using ASPNETCore.Context;
using ASPNETCore.Models;
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
        private MyContext _context = null;
        private DbSet<T> table = null;
        public GeneralRepository()
        {
            this._context = new MyContext();
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
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Post(T obj)
        {
            table.Add(obj);
        }
        public void Put(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

    }
}
