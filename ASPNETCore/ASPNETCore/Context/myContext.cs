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
        public MyContext(DbContextOptions<MyContext> options)
            :base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
       public DbSet<Contact> Contacts { get; set; }
       public DbSet<Address> Addresses { get; set; }
       public DbSet<Education> Educations { get; set; }
        public DbSet<Territory> Territories  { get; set; }
        public DbSet<SubDistrict> SubDistrict { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Province> Provinces { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeRole>()
                .HasOne(EmployeeRole => EmployeeRole.Employee)
                .WithMany(Employee => Employee.EmployeeRoles);

            modelBuilder.Entity<EmployeeRole>()
                .HasOne(EmployeeRole => EmployeeRole.Role)
                .WithMany(Role => Role.EmployeeRoles);
            modelBuilder.Entity<Employee>()
                .HasOne(employee => employee.Contact)
                .WithOne(contact => contact.Employee)
                .HasForeignKey<Contact>(contact => contact.Id);
            
            modelBuilder.Entity<Employee>()
                .HasOne(employee => employee.Address)
                .WithOne(address => address.Employee)
                .HasForeignKey<Address>(address => address.Id);
            
            modelBuilder.Entity<Employee>()
                .HasOne(employee => employee.Education)
                .WithOne(education => education.Employee)
                .HasForeignKey<Education>(education => education.Id);

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

