using Microsoft.EntityFrameworkCore;
using ProjectTest.Models;

namespace ProjectTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Building> Building { get; set; }
        public DbSet<ClassRoom> ClassRoom { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{           
        //}
    }
}
