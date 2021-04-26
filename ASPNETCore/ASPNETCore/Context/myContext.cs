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

        public DbSet<Education> Education { get; set; }
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
        }
          
    }
}
