using Moq;
using Xunit;
using MiniAmazonClone.Models;
using MiniAmazonClone.Data;
using MiniAmazonClone.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq.EntityFrameworkCore;

namespace MiniAmazonClone.Tests
{
	public class OrderRepositoryTests
	{
		private readonly Mock<AppDbContext> _mockContext;
		private readonly OrderRepository _orderRepository;

		public OrderRepositoryTests()
		{
			_mockContext = new Mock<AppDbContext>();
			_orderRepository = new OrderRepository(_mockContext.Object);
		}

		[Fact]
		public async Task GetOrdersByUserId_ShouldReturnOrdersForUser()
		{
			// Arrange
			var userId = 1;
			var orders = new List<Order>
			{
				new Order { OrderID = 1, UserID = userId, TotalAmount = 100 },
				new Order { OrderID = 2, UserID = userId, TotalAmount = 200 }
			};

			_mockContext.Setup(c => c.Orders).ReturnsDbSet(orders);

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
			var newOrder = new Order { OrderID = 3, UserID = 2, TotalAmount = 300 };
			var orders = new List<Order>();
			var mockOrderSet = new Mock<DbSet<Order>>();

			_mockContext.Setup(c => c.Orders).Returns(mockOrderSet.Object);

			// Act
			await _orderRepository.AddOrder(newOrder);

			// Assert
			mockOrderSet.Verify(o => o.Add(It.IsAny<Order>()), Times.Once);
			_mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
		}
	}
}
