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
            optionsBuilder.UseSqlServer("Server=DESKTOP-DTGB06O\\SQLEXPRESS; Database=SellFruit; Trusted_connection=true; TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SystemSetting>().HasData(
                new SystemSetting { Id = 1, WebName = "อานาตาปัตชัยเย", Description = "Hahaha", Image = null, ShippingCost = 40 }
                );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" }
                );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "admin",
                    PhoneNumber = "1111111111",
                    Username = "admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("1234"),
                    RoleId = 1,
                },
                new User
                {
                    Id = 2,
                    FullName = "ร้านค้า 1",
                    PhoneNumber = "1111111112",
                    Username = "shop1",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("1234"),
                    RoleId = 2,
                },
                new User
                {
                    Id = 3,
                    FullName = "ร้านค้า 2",
                    PhoneNumber = "1111111113",
                    Username = "shop1",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("1234"),
                    RoleId = 2,
                },
                new User
                {
                    Id = 4,
                    FullName = "ลูกค้า 1",
                    PhoneNumber = "1111111114",
                    Username = "user1",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("1234"),
                    RoleId = 2,
                },
                new User
                {
                    Id = 5,
                    FullName = "พลส่ง 1",
                    PhoneNumber = "1111111115",
                    Username = "user1",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("1234"),
                    RoleId = 2,
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "ผลไม้สด" },
                new Category { Id = 2, Name = "ผลไม้แปรรูป" }
            );

            modelBuilder.Entity<Store>().HasData(
                new Store
                {
                    Id = 1,
                    Name = "ทองผาภูมิ มีดี",
                    Description = "แหล่งผลิตที่ทองผาภูมิ",
                    CreatedAt = DateTime.Now,
                    UserId = 2,
                    Hidden = false
                },
                new Store
                {
                    Id = 2,
                    Name = "อาปาชาเฮ้",
                    Description = "แหล่งผลิตที่ทองผาภูมิ",
                    CreatedAt = DateTime.Now,
                    UserId = 3,
                    Hidden = false
                }
            );

            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id = 1,
                    Detail = "1/23 หมู่ 1",
                    CreatedAt = DateTime.Now,
                    Province = "กาญจนบุรี",
                    District = "เมืองกาญจนบุรี",
                    SubDistrict = "วังด้ง",
                    PostCode = "71190",
                    IsUsed = false,
                    IsUsed_Store = true,
                    GPS = "",
                    UserId = 2,
                },
                new Address
                {
                    Id = 2,
                    Detail = "33/45 หมู่ 6",
                    CreatedAt = DateTime.Now,
                    Province = "กาญจนบุรี",
                    District = "ทองผาภูมิ",
                    SubDistrict = "ชะแล",
                    PostCode = "71180",
                    IsUsed = false,
                    IsUsed_Store = true,
                    GPS = "",
                    UserId = 3,
                }
            );

            modelBuilder.Entity<ProductGI>().HasData(
                new ProductGI
                {
                    Id = 1,
                    Name = "ทุเรียน",
                    Description = "<p>วัสดุ TPU ที่ใช้ในเคสนี้มีคุณสมบัติป้องกันการกระแทกที่ช่วยปกป้องโทรศัพท์ของคุณจากความเสียหายจากอุบัติเหตุที่เกิดจากการตกหล่นและการกระแทก นอกจากนี้ยัง</p>",
                    CategoryId = 1,
                    StoreId = 1
                },
                new ProductGI
                {
                    Id = 2,
                    Name = "เงอะ",
                    Description = "<p><br></p>",
                    CategoryId = 1,
                    StoreId = 1
                },
                new ProductGI
                {
                    Id = 3,
                    Name = "ยางพารา",
                    Description = "<p><br></p>",
                    CategoryId = 2,
                    StoreId = 1
                },
                new ProductGI
                {
                    Id = 4,
                    Name = "มังคุด",
                    Description = "<p><br></p>",
                    CategoryId = 1,
                    StoreId = 2
                },
                new ProductGI
                {
                    Id = 5,
                    Name = "มังแคด",
                    Description = "<p></p>",
                    CategoryId = 1,
                    StoreId = 2
                },
                new ProductGI
                {
                    Id = 6,
                    Name = "มังแคด",
                    Description = "<p>111</p>",
                    CategoryId = 1,
                    StoreId = 2
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Images = null,
                    Weight = 3,
                    Quantity = 7,
                    Price = 125,
                    Sold = 11,
                    Detail = "",
                    Status = true,
                    CreatedAt = DateTime.Now,
                    ProductGIId = 1,
                    Expire = DateTime.Now.AddMonths(1)
                },
                new Product
                {
                    Id = 2,
                    Images = null,
                    Weight = 10,
                    Quantity = 3,
                    Price = 155,
                    Sold = 9,
                    Detail = "<p>1</p>",
                    Status = true,
                    CreatedAt = DateTime.Now,
                    ProductGIId = 2,
                    Expire = DateTime.Now.AddMonths(1)
                },
                new Product
                {
                    Id = 3,
                    Images = null,
                    Weight = 3,
                    Quantity = 50,
                    Price = 60,
                    Sold = 0,
                    Detail = "<p>111</p>",
                    Status = true,
                    CreatedAt = DateTime.Now,
                    ProductGIId = 3,
                    Expire = DateTime.Now.AddMonths(1)
                },
                new Product
                {
                    Id = 4,
                    Images = null,
                    Weight = 3,
                    Quantity = 50,
                    Price = 60,
                    Sold = 0,
                    Detail = "<p>111</p>",
                    Status = true,
                    CreatedAt = DateTime.Now,
                    ProductGIId = 4,
                    Expire = DateTime.Now.AddMonths(1)
                },
                new Product
                {
                    Id = 5,
                    Images = null,
                    Weight = 1,
                    Quantity = 10,
                    Price = 40,
                    Sold = 0,
                    Detail = "<p></p>",
                    Status = true,
                    CreatedAt = DateTime.Now,
                    ProductGIId = 5,
                    Expire = DateTime.Now.AddMonths(1)
                },
                new Product
                {
                    Id = 6 ,
                    Images = null,
                    Weight = 1,
                    Quantity = 18,
                    Price = 50,
                    Sold = 0,
                    Detail = "<p></p>",
                    Status = true,
                    CreatedAt = DateTime.Now,
                    ProductGIId = 5,
                    Expire = DateTime.Now.AddMonths(1)
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

            modelBuilder.Entity<DriverHistory>()
                .HasOne(ci => ci.Shipping)
                .WithMany(u => u.DriverHistories)
                .HasForeignKey(ci => ci.ShippingId)
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

        public DbSet<SystemSetting> SystemSettings { get; set; }
        public DbSet<SlideShow> SlideShows { get; set; }

        public DbSet<NEWS> NEWSs { get; set; }

        public DbSet<DriverHistory> DriverHistories { get; set; }   
        public DbSet<Shipping> Shippings { get; set; }
    }
}
 