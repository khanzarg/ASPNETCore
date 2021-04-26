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
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Territory> Territories  { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SubDistrict> SubDistricts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Territory
            modelBuilder.Entity<Territory>()
                .HasOne(territory => territory.SubDistrict)
                .WithMany(subdistrict => subdistrict.Territory);

            // Address
            modelBuilder.Entity<Address>()
                .HasOne(address => address.Territory)
                .WithMany(territory => territory.Addresses);

        }
    }
}
