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
        {

        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Territory> Territories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SubDistrict> SubDistricts { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //University-Education
            modelBuilder.Entity<Education>()
                .HasOne(education => education.University)
                .WithMany(university => university.Educations);

            //Education-Major
            modelBuilder.Entity<Education>()
                .HasOne(education => education.Major)
                .WithMany(major => major.Educations);

            //Employee-Contact
            modelBuilder.Entity<Employee>()
                .HasOne(employee => employee.Contact)
                .WithOne(contact => contact.Employee)
                .HasForeignKey<Contact>(contact => contact.Id);
            
            //Address-Employee
            modelBuilder.Entity<Employee>()
                .HasOne(employee => employee.Address)
                .WithOne(address => address.Employee)
                .HasForeignKey<Address>(address => address.Id);
            
            //Employee-Education
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

            //SubDistrict
            modelBuilder.Entity<SubDistrict>()
             .HasOne(subdistrict => subdistrict.District)
             .WithMany(district => district.SubDistrict);

            //District
            modelBuilder.Entity<District>()
                .HasOne(district => district.Province)
                .WithMany(province => province.Districts);

            //Employee-Employeerole
            modelBuilder.Entity<EmployeeRole>()
                .HasOne(EmployeeRole => EmployeeRole.Employee)
                .WithMany(Employee => Employee.EmployeeRoles);

            //Employeerole-Role
            modelBuilder.Entity<EmployeeRole>()
                .HasOne(EmployeeRole => EmployeeRole.Role)
                .WithMany(Role => Role.EmployeeRoles);
        }
    }
}
