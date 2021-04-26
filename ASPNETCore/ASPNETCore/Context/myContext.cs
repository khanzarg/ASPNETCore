using ASPNETCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Context
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions<DbContext> options)
            :base(options)
        {

        }

        public DbSet<EmployeeRole> employeeRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeRole>()
                .HasMany(c => c.Employee)
                .WithOne(e => e.EmployeeRoles);
            
            modelBuilder.Entity<EmployeeRole>()
                .HasMany(c => c.Role)
                .WithOne(e => e.EmployeeRoless);
        }
    }
}
