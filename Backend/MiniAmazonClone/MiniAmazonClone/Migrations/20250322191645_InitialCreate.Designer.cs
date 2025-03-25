﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniAmazonClone.Data;

#nullable disable

namespace MiniAmazonClone.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250322191645_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MiniAmazonClone.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("UserID");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderID = 1,
                            OrderDate = new DateTime(2025, 3, 22, 22, 16, 45, 161, DateTimeKind.Local).AddTicks(9275),
                            Status = "Pending",
                            TotalAmount = 2000.00m,
                            UserID = 2
                        },
                        new
                        {
                            OrderID = 2,
                            OrderDate = new DateTime(2025, 3, 22, 22, 16, 45, 161, DateTimeKind.Local).AddTicks(9291),
                            Status = "Completed",
                            TotalAmount = 800.00m,
                            UserID = 3
                        },
                        new
                        {
                            OrderID = 3,
                            OrderDate = new DateTime(2025, 3, 22, 22, 16, 45, 161, DateTimeKind.Local).AddTicks(9293),
                            Status = "Shipped",
                            TotalAmount = 150.00m,
                            UserID = 4
                        },
                        new
                        {
                            OrderID = 4,
                            OrderDate = new DateTime(2025, 3, 22, 22, 16, 45, 161, DateTimeKind.Local).AddTicks(9294),
                            Status = "Pending",
                            TotalAmount = 1200.00m,
                            UserID = 5
                        },
                        new
                        {
                            OrderID = 5,
                            OrderDate = new DateTime(2025, 3, 22, 22, 16, 45, 161, DateTimeKind.Local).AddTicks(9296),
                            Status = "Completed",
                            TotalAmount = 800.00m,
                            UserID = 1
                        });
                });

            modelBuilder.Entity("MiniAmazonClone.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemID"));

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            OrderItemID = 1,
                            OrderID = 1,
                            Price = 1200.00m,
                            ProductID = 1,
                            Quantity = 1
                        },
                        new
                        {
                            OrderItemID = 2,
                            OrderID = 2,
                            Price = 800.00m,
                            ProductID = 2,
                            Quantity = 1
                        },
                        new
                        {
                            OrderItemID = 3,
                            OrderID = 3,
                            Price = 150.00m,
                            ProductID = 3,
                            Quantity = 1
                        },
                        new
                        {
                            OrderItemID = 4,
                            OrderID = 4,
                            Price = 250.00m,
                            ProductID = 4,
                            Quantity = 1
                        },
                        new
                        {
                            OrderItemID = 5,
                            OrderID = 5,
                            Price = 700.00m,
                            ProductID = 5,
                            Quantity = 2
                        });
                });

            modelBuilder.Entity("MiniAmazonClone.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedByUserUserID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.HasIndex("CreatedByUserUserID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            CreatedBy = 1,
                            Description = "A powerful laptop for professionals.",
                            Name = "Laptop",
                            Price = 1200.00m,
                            Stock = 50
                        },
                        new
                        {
                            ProductID = 2,
                            CreatedBy = 1,
                            Description = "Latest model smartphone with amazing features.",
                            Name = "Smartphone",
                            Price = 800.00m,
                            Stock = 100
                        },
                        new
                        {
                            ProductID = 3,
                            CreatedBy = 1,
                            Description = "Noise-canceling headphones for a better sound experience.",
                            Name = "Headphones",
                            Price = 150.00m,
                            Stock = 150
                        },
                        new
                        {
                            ProductID = 4,
                            CreatedBy = 1,
                            Description = "Wearable smartwatch with fitness tracking features.",
                            Name = "Smartwatch",
                            Price = 250.00m,
                            Stock = 200
                        },
                        new
                        {
                            ProductID = 5,
                            CreatedBy = 1,
                            Description = "Portable tablet for reading and entertainment.",
                            Name = "Tablet",
                            Price = 350.00m,
                            Stock = 120
                        });
                });

            modelBuilder.Entity("MiniAmazonClone.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Email = "john.doe@example.com",
                            Name = "John Doe",
                            Password = "password123",
                            Role = "Admin"
                        },
                        new
                        {
                            UserID = 2,
                            Email = "jane.smith@example.com",
                            Name = "Jane Smith",
                            Password = "password123",
                            Role = "Customer"
                        },
                        new
                        {
                            UserID = 3,
                            Email = "mike.johnson@example.com",
                            Name = "Mike Johnson",
                            Password = "password123",
                            Role = "Customer"
                        },
                        new
                        {
                            UserID = 4,
                            Email = "emily.davis@example.com",
                            Name = "Emily Davis",
                            Password = "password123",
                            Role = "Customer"
                        },
                        new
                        {
                            UserID = 5,
                            Email = "chris.lee@example.com",
                            Name = "Chris Lee",
                            Password = "password123",
                            Role = "Customer"
                        });
                });

            modelBuilder.Entity("MiniAmazonClone.Models.Order", b =>
                {
                    b.HasOne("MiniAmazonClone.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MiniAmazonClone.Models.OrderItem", b =>
                {
                    b.HasOne("MiniAmazonClone.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniAmazonClone.Models.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MiniAmazonClone.Models.Product", b =>
                {
                    b.HasOne("MiniAmazonClone.Models.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserUserID");

                    b.Navigation("CreatedByUser");
                });

            modelBuilder.Entity("MiniAmazonClone.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("MiniAmazonClone.Models.Product", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("MiniAmazonClone.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
