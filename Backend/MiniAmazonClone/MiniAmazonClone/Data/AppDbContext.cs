
using Microsoft.EntityFrameworkCore;
using MiniAmazonClone.Models;

namespace MiniAmazonClone.Data
{
    public class AppDbContext : DbContext
    {
        // Constructor that accepts DbContextOptions
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Defining tables (DbSets) for each model
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        // Configuring relationships and seeding initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Defining relationships between tables
            // 1. One-to-many relationship between User and Order
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)  
                .WithOne(o => o.User)   
                .HasForeignKey(o => o.UserID);  

            // 2. One-to-many relationship between Product and OrderItem
            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderItems)  
                .WithOne(oi => oi.Product)   
                .HasForeignKey(oi => oi.ProductID); 

            // 3. One-to-many relationship between Order and OrderItem
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)  
                .WithOne(oi => oi.Order)    
                .HasForeignKey(oi => oi.OrderID); 

            // Seeding initial data for Users
            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, Name = "John Doe", Email = "john.doe@example.com", Password = "password123", Role = "Admin" },
                new User { UserID = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Password = "password123", Role = "Customer" },
                new User { UserID = 3, Name = "Mike Johnson", Email = "mike.johnson@example.com", Password = "password123", Role = "Customer" },
                new User { UserID = 4, Name = "Emily Davis", Email = "emily.davis@example.com", Password = "password123", Role = "Customer" },
                new User { UserID = 5, Name = "Chris Lee", Email = "chris.lee@example.com", Password = "password123", Role = "Customer" }
            );

            // Seeding initial data for Products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, Name = "Laptop", Description = "A powerful laptop for professionals.", Price = 1200.00m, Stock = 50, CreatedBy = 1 },
                new Product { ProductID = 2, Name = "Smartphone", Description = "Latest model smartphone with amazing features.", Price = 800.00m, Stock = 100, CreatedBy = 1 },
                new Product { ProductID = 3, Name = "Headphones", Description = "Noise-canceling headphones for a better sound experience.", Price = 150.00m, Stock = 150, CreatedBy = 1 },
                new Product { ProductID = 4, Name = "Smartwatch", Description = "Wearable smartwatch with fitness tracking features.", Price = 250.00m, Stock = 200, CreatedBy = 1 },
                new Product { ProductID = 5, Name = "Tablet", Description = "Portable tablet for reading and entertainment.", Price = 350.00m, Stock = 120, CreatedBy = 1 }
            );

            // Seeding initial data for Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderID = 1, UserID = 2, OrderDate = DateTime.Now, TotalAmount = 2000.00m, Status = "Pending" },
                new Order { OrderID = 2, UserID = 3, OrderDate = DateTime.Now, TotalAmount = 800.00m, Status = "Completed" },
                new Order { OrderID = 3, UserID = 4, OrderDate = DateTime.Now, TotalAmount = 150.00m, Status = "Shipped" },
                new Order { OrderID = 4, UserID = 5, OrderDate = DateTime.Now, TotalAmount = 1200.00m, Status = "Pending" },
                new Order { OrderID = 5, UserID = 1, OrderDate = DateTime.Now, TotalAmount = 800.00m, Status = "Completed" }
            );

            // Seeding initial data for OrderItems
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { OrderItemID = 1, OrderID = 1, ProductID = 1, Quantity = 1, Price = 1200.00m },
                new OrderItem { OrderItemID = 2, OrderID = 2, ProductID = 2, Quantity = 1, Price = 800.00m },
                new OrderItem { OrderItemID = 3, OrderID = 3, ProductID = 3, Quantity = 1, Price = 150.00m },
                new OrderItem { OrderItemID = 4, OrderID = 4, ProductID = 4, Quantity = 1, Price = 250.00m },
                new OrderItem { OrderItemID = 5, OrderID = 5, ProductID = 5, Quantity = 2, Price = 700.00m }
            );
        }
    }
}
