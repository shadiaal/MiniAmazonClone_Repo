using Microsoft.EntityFrameworkCore;
using MiniAmazonClone.Data;
using MiniAmazonClone.Models;
using MiniAmazonClone.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MiniAmazonClone.Tests
{
	public class OrderRepositoryTests
	{
		private readonly AppDbContext _context;
		private readonly OrderRepository _orderRepository;

		public OrderRepositoryTests()
		{
			var options = new DbContextOptionsBuilder<AppDbContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
				.Options;

			_context = new AppDbContext(options);
			_context.Database.EnsureCreated();
			_orderRepository = new OrderRepository(_context);

			ResetDatabase().Wait();
		}

		private async Task ResetDatabase()
		{
			_context.Orders.RemoveRange(_context.Orders);
			await _context.SaveChangesAsync();
		}

		[Fact]
		public async Task GetOrdersByUserId_ShouldReturnOrdersForUser()
		{
			// Arrange
			var userId = 1;
			var orders = new List<Order>
			{
				new Order { OrderID = 1, UserID = userId, TotalAmount = 100 }, 
                new Order { OrderID = 2,  UserID = userId, TotalAmount = 200 }
			};

			_context.Orders.AddRange(orders);
			await _context.SaveChangesAsync();

			// Act
			var result = await _orderRepository.GetOrdersByUserId(userId);

			// Assert
			Assert.Equal(2, result.Count);
			Assert.All(result, o => Assert.Equal(userId, o.UserID));
		}

		[Fact]
		public async Task AddOrder_ShouldAddOrderToDatabase()
		{
			// Arrange
			var newOrder = new Order {OrderID = 7, UserID = 2, TotalAmount = 300 }; 

			// Act
			await _orderRepository.AddOrder(newOrder);
			var orders = await _context.Orders.ToListAsync();

			// Assert
			Assert.Contains(orders, o => o.TotalAmount == newOrder.TotalAmount);
			Assert.Equal(1, orders.Count);
		}
	}
}
