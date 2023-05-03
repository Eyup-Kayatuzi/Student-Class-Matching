

using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApplication8.Models;

namespace WebApplication7.Context
{
    public class GeneralContext : DbContext
    {
        public GeneralContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }

        public DbSet<ClassType> ClassTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ClassType>()
            .HasIndex(c => new { c.Level, c.Branch })
            .IsUnique();

            modelBuilder.Entity<ClassType>().HasData(
                new ClassType
                {
                    Id = 1,
                    Level = 1,
                    Branch = "Matematik"
                },
                new ClassType
                {
                    Id = 2,
                    Level = 1,
                    Branch = "Fizik"
                }
                );
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "Yaman",
                    LastName = "Seven",
                    Address = "İstanbul",
                    ClassTypeId = 1
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Hüseyin",
                    LastName = "Şülen",
                    Address = "Tekirdağ",
                    ClassTypeId = 2
                }
                );


        }
    }
}
