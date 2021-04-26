using ASPNETCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options): base(options) 
        { 
            
        }
        public DbSet<Territory> Territories { get; set; }
        public DbSet<SubDistrict> SubDistricts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Territory>()
                .HasOne(territory => territory.SubDistrict)
                .WithMany(subdistrict => subdistrict.Territory);
        }
        

    }
}
