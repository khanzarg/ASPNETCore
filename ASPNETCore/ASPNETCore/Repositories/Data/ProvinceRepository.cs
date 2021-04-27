using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Data
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly MyContext _context;

        public ProvinceRepository()
        {
            _context = new MyContext();
        }

        public ProvinceRepository(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<Province> GetAll()
        {
            return _context.Provinces.ToList();
        }

        public Province GetById(int Id)
        {
            return _context.Provinces.Find(Id);
        }

        public void Post(Province province)
        {
            _context.Provinces.Add(province);
        }

        public void Update(Province province)
        {
            _context.Entry(province).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        public void Delete(int Id)
        {
            Province province = _context.Provinces.Find(Id);
            _context.Provinces.Remove(province);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
