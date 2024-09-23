﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectEcommerceFruit.Data;

#nullable disable

namespace ProjectEcommerceFruit.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectEcommerceFruit.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GPS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUsed_Store")
                        .HasColumnType("bit");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubDistrict")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ผลไม้สด"
                        },
                        new
                        {
                            Id = 2,
                            Name = "ผลไม้แปรรูป"
                        });
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.DriverHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ShippingFee")
                        .HasColumnType("int");

                    b.Property<int>("ShippingId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShippingId");

                    b.HasIndex("UserId");

                    b.ToTable("DriverHistories");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.Images", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductGIId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductGIId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.NEWS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Hidden")
                        .HasColumnType("bit");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NEWSs");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("ConfirmReceipt")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShippingType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Expire")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Hidden")
                        .HasColumnType("bit");

                    b.Property<string>("Images")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductGIId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Sold")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ProductGIId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 9, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(285),
                            Detail = "",
                            Expire = new DateTime(2024, 10, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(287),
                            Hidden = false,
                            Price = 125.0,
                            ProductGIId = 1,
                            Quantity = 7,
                            Sold = 11,
                            Status = true,
                            Weight = 3.0
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 9, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(297),
                            Detail = "<p>1</p>",
                            Expire = new DateTime(2024, 10, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(298),
                            Hidden = false,
                            Price = 155.0,
                            ProductGIId = 2,
                            Quantity = 3,
                            Sold = 9,
                            Status = true,
                            Weight = 10.0
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 9, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(335),
                            Detail = "<p>111</p>",
                            Expire = new DateTime(2024, 10, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(336),
                            Hidden = false,
                            Price = 60.0,
                            ProductGIId = 3,
                            Quantity = 50,
                            Sold = 0,
                            Status = true,
                            Weight = 3.0
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 9, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(340),
                            Detail = "<p>111</p>",
                            Expire = new DateTime(2024, 10, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(341),
                            Hidden = false,
                            Price = 60.0,
                            ProductGIId = 4,
                            Quantity = 50,
                            Sold = 0,
                            Status = true,
                            Weight = 3.0
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 9, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(344),
                            Detail = "<p></p>",
                            Expire = new DateTime(2024, 10, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(345),
                            Hidden = false,
                            Price = 40.0,
                            ProductGIId = 5,
                            Quantity = 10,
                            Sold = 0,
                            Status = true,
                            Weight = 1.0
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 9, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(355),
                            Detail = "<p></p>",
                            Expire = new DateTime(2024, 10, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(356),
                            Hidden = false,
                            Price = 50.0,
                            ProductGIId = 5,
                            Quantity = 18,
                            Sold = 0,
                            Status = true,
                            Weight = 1.0
                        });
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.ProductGI", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("StoreId");

                    b.ToTable("ProductGIs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "<p>วัสดุ TPU ที่ใช้ในเคสนี้มีคุณสมบัติป้องกันการกระแทกที่ช่วยปกป้องโทรศัพท์ของคุณจากความเสียหายจากอุบัติเหตุที่เกิดจากการตกหล่นและการกระแทก นอกจากนี้ยัง</p>",
                            Name = "ทุเรียน",
                            Status = true,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "<p><br></p>",
                            Name = "เงอะ",
                            Status = true,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "<p><br></p>",
                            Name = "ยางพารา",
                            Status = true,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "<p><br></p>",
                            Name = "มังคุด",
                            Status = true,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Description = "<p></p>",
                            Name = "มังแคด",
                            Status = true,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            Description = "<p>111</p>",
                            Name = "มังแคด",
                            Status = true,
                            StoreId = 2
                        });
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.Shipping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ShippingFee")
                        .HasColumnType("int");

                    b.Property<int>("ShippingStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Shippings");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.SlideShow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Hidden")
                        .HasColumnType("bit");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("SlideShows");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Hidden")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 9, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(108),
                            Description = "แหล่งผลิตที่ทองผาภูมิ",
                            Hidden = false,
                            Name = "ทองผาภูมิ มีดี",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 9, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(128),
                            Description = "แหล่งผลิตที่ทองผาภูมิ",
                            Hidden = false,
                            Name = "อาปาชาเฮ้",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.SystemSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShippingCost")
                        .HasColumnType("int");

                    b.Property<string>("WebName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SystemSettings");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Hidden")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Admin1",
                            Hidden = false,
                            PasswordHash = "$2a$11$S5zjXW8fJH5iTtQZIlYWbORViCuNOG/jNIRW0CCoWsNOmqIZ2iMha",
                            PhoneNumber = "0123456789",
                            RoleId = 1,
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "User Haha",
                            Hidden = false,
                            PasswordHash = "$2a$11$F6pbv5jZlA2z5IrEzfO5BO50X75kdD/ttwuyUR6CteLLqW7k5vvfS",
                            PhoneNumber = "0987654321",
                            RoleId = 2,
                            Username = "user1"
                        });
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.Address", b =>
                {
                    b.HasOne("ProjectEcommerceFruit.Models.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.CartItem", b =>
                {
                    b.HasOne("ProjectEcommerceFruit.Models.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjectEcommerceFruit.Models.User", "User")
                        .WithMany("CartItems")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.DriverHistory", b =>
                {
                    b.HasOne("ProjectEcommerceFruit.Models.Shipping", "Shipping")
                        .WithMany("DriverHistories")
                        .HasForeignKey("ShippingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjectEcommerceFruit.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shipping");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.Images", b =>
                {
                    b.HasOne("ProjectEcommerceFruit.Models.ProductGI", "ProductGI")
                        .WithMany("Images")
                        .HasForeignKey("ProductGIId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductGI");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.Order", b =>
                {
                    b.HasOne("ProjectEcommerceFruit.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.OrderItem", b =>
                {
                    b.HasOne("ProjectEcommerceFruit.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjectEcommerceFruit.Models.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.Product", b =>
                {
                    b.HasOne("ProjectEcommerceFruit.Models.ProductGI", "ProductGI")
                        .WithMany()
                        .HasForeignKey("ProductGIId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductGI");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.ProductGI", b =>
                {
                    b.HasOne("ProjectEcommerceFruit.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectEcommerceFruit.Models.Store", "Store")
                        .WithMany("ProductGIs")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.Shipping", b =>
                {
                    b.HasOne("ProjectEcommerceFruit.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.Store", b =>
                {
                    b.HasOne("ProjectEcommerceFruit.Models.User", "User")
                        .WithMany("Stores")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.User", b =>
                {
                    b.HasOne("ProjectEcommerceFruit.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.ProductGI", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.Shipping", b =>
                {
                    b.Navigation("DriverHistories");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.Store", b =>
                {
                    b.Navigation("ProductGIs");
                });

            modelBuilder.Entity("ProjectEcommerceFruit.Models.User", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("CartItems");

                    b.Navigation("Stores");
                });
#pragma warning restore 612, 618
        }
    }
}
