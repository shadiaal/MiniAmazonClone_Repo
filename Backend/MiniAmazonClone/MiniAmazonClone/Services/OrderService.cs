
using MiniAmazonClone.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using MiniAmazonClone.Data;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using MiniAmazonClone.Models.Dto;
namespace MiniAmazonClone.Services
{
    public class OrderService
    {
        private readonly AppDbContext _context;
        private readonly string _connectionString;

        public OrderService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection"); 
        }

        // Method to fetch orders along with their related products using eager loading (EF Core)
        public async Task<List<Order>> GetOrdersWithProductsAsyncUsingEFCore()
        {
            var ordersWithProducts = await _context.Orders
                .Include(o => o.OrderItems)            
                .ThenInclude(oi => oi.Product)          
                .ToListAsync();                         

            return ordersWithProducts;
        }

        // Method to fetch orders with products using Dapper (Performance Optimization)
        public async Task<List<Order>> GetOrdersWithProductsAsyncUsingDapper()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
               
                var ordersQuery = @"
            SELECT o.OrderID AS OrderID, oi.OrderItemID AS OrderItemID, p.ProductID AS ProductID, p.Name AS ProductName, p.Price AS ProductPrice
            FROM Orders o
            INNER JOIN OrderItems oi ON oi.OrderID = o.OrderID
            INNER JOIN Products p ON p.ProductID = oi.ProductID";

                var ordersDictionary = new Dictionary<int, Order>();

                var orders = await connection.QueryAsync<Order, OrderItem, Product, Order>(
                    ordersQuery,
                    (order, orderItem, product) =>
                    {
                        if (order == null || orderItem == null || product == null)
                        {
                            
                            return null; 
                        }

                        if (!ordersDictionary.TryGetValue(order.OrderID, out var orderEntry))
                        {
                            orderEntry = order;
                            orderEntry.OrderItems = new List<OrderItem>();
                            ordersDictionary.Add(orderEntry.OrderID, orderEntry);
                        }

                        orderItem.Product = product;
                        orderEntry.OrderItems.Add(orderItem);

                        return orderEntry;
                    },
                    splitOn: "OrderItemID,ProductID"
                );

                return orders.Where(o => o != null).ToList(); 
            }
        }

        // Method to refund an order
        public async Task<bool> RefundOrderAsync(int orderId)
        {
            
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderID == orderId);

            if (order == null)
            {
               
                return false;
            }

            if (order.Status != "Completed")
            {
                
                return false;
            }
            order.Status = "Refunded";
            order.RefundDate = DateTime.Now;  
            await _context.SaveChangesAsync();
            return true;
        }


        //  Create a new request
        public async Task<Order?> CreateOrderAsync(int userId, CreateOrderDto orderDto)
        {
            var order = new Order
            {
                UserID = userId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = 0,
                Status = "Pending",
                OrderItems = new List<OrderItem>()
            };

            foreach (var item in orderDto.Items)
            {
                var product = await _context.Products.FindAsync(item.ProductID);
                if (product == null) return null;

                order.OrderItems.Add(new OrderItem
                {
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    Price = product.Price
                });

                order.TotalAmount += product.Price * item.Quantity;
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }


        public async Task<Order?> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.OrderID == orderId);
        }

    }
}
