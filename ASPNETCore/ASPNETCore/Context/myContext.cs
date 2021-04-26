﻿using ASPNETCore.Models;
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

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<Major> Major { get; set; }
        public DbSet<University> University { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Education>()
                .HasOne(education => education.University)
                .WithMany(university => university.Educations);

            modelBuilder.Entity<Education>()
                .HasOne(education => education.Major)
                .WithMany(major => major.Educations);

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
        }
    }
}
