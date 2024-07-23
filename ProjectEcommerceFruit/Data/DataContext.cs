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
            optionsBuilder.UseSqlServer("Server=DESKTOP-E89K85P; Database=ProjectSellFruit; Trusted_connection=true; TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" }
                );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "Admin1",
                    PhoneNumber = 0123456789,
                    Username = "Admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("1234"),
                    RoleId = 1,
                },
                new User
                {
                    Id = 2,
                    FullName = "User Haha",
                    PhoneNumber = 0987654321,
                    Username = "User1",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("1234"),
                    RoleId = 2,
                }
                );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
