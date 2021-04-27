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
    public class DistrictRepository : GeneralRepository<District> 
    {
        private readonly MyContext context;
        private DbSet<District> district;
        string errorMessage = string.Empty;
        public DistrictRepository(MyContext context)
        {
            this.context = context;
            district = context.Set<District>();
        }
        public IEnumerable<District> GetAll()
        {
            return district.ToList();
        }
        public District GetById(int id)
        {
            return district.SingleOrDefault(s => s.Id == id);
        }
        public void Post(District entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            district.Add(entity);
            context.SaveChanges();
        }
        public void Put(District entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }
        public void Delete(District entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            district.Remove(entity);
            context.SaveChanges();
        }

    }
    }  


   
