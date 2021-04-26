using ASPNETCore.Models;
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
        public DbSet<SubDistrict> SubDistrict { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Province> Provinces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Address
            modelBuilder.Entity<Address>()
                .HasOne(address => address.Territory)
                .WithMany(territory => territory.Addresses);

            //Territory
            modelBuilder.Entity<Territory>()
                .HasOne(territory => territory.SubDistrict)
                .WithMany(subdistrict => subdistrict.Territory);
            
            //District
            modelBuilder.Entity<District>()
                .HasOne(district => district.Province)
                .WithMany(province => province.Districts);

            //SubDistrict
            modelBuilder.Entity<SubDistrict>()
             .HasOne(subdistrict => subdistrict.District)
             .WithMany(district => district.SubDistrict);

        }
    }
}

