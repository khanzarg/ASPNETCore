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
    public class UniversityRepository : GeneralRepository<University>
    {
        public readonly MyContext _context;
        public UniversityRepository(MyContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<University> GetAllUni()
        {
            return _context.Universities.Include("Educations").ToList();
        }

        public University GetUniById(int id)
        {
            return _context.Universities.Include("Educations").FirstOrDefault(u => u.Id == id);
        }

        //public void Insert(University obj)
        //{
        //    _context.Universities.Add(obj);
        //    _context.SaveChanges();
        //}

        public void UpdateUni(int id, University obj)
        {
            University uniToUpdate = GetById(id);
            uniToUpdate.Name = obj.Name;
            uniToUpdate.Counter = obj.Counter;
            _context.Entry(uniToUpdate).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //public void Delete(int id)
        //{
        //    University obj = GetById(id);
        //    _context.Universities.Remove(obj);
        //    _context.SaveChanges();
        //}
    }
}
