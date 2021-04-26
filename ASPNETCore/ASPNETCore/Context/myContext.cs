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
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeRole>()
                .HasOne(EmployeeRole => EmployeeRole.Employee)
                .WithMany(Employee => Employee.EmployeeRoles);

            modelBuilder.Entity<EmployeeRole>()
                .HasOne(EmployeeRole => EmployeeRole.Role)
                .WithMany(Role => Role.EmployeeRoles);
        }
    }
}
