using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
                    Username = "admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("1234"),
                    RoleId = 1,
                },
                new User
                {
                    Id = 2,
                    FullName = "User Haha",
                    PhoneNumber = 0987654321,
                    Username = "user1",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("1234"),
                    RoleId = 2,
                }
                );

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.User)
                .WithMany(u => u.CartItems)
                .HasForeignKey(ci => ci.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .HasOne(ci => ci.Order)
                .WithMany(u => u.OrderItems)
                .HasForeignKey(ci => ci.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .HasOne(ci => ci.Product)
                .WithMany(u => u.OrderItems)
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<User>().HasMany(x => x.CartItems).GetInfrastructure()!.OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Product>().HasMany(x => x.CartItems).GetInfrastructure()!.OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<ProductGI> ProductGIs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Images> Images { get; set; }
        
        public DbSet<Product> Products { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
 