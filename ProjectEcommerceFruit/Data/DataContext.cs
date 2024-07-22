using Microsoft.EntityFrameworkCore;
using ProjectEcommerceFruit.Models;
using System.Data;

namespace ProjectEcommerceFruit.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-DTGB06O\\SQLEXPRESS; Database=ProjectSellFruit; Trusted_connection=true; TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" }
                );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
