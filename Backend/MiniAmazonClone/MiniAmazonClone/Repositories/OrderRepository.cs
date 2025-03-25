using MiniAmazonClone.Models;
using MiniAmazonClone.Data;
using Microsoft.EntityFrameworkCore;
namespace MiniAmazonClone.Repositories
{
	public class OrderRepository
	{
		private readonly AppDbContext _context;

		public OrderRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<List<Order>> GetOrdersByUserId(int userId)
		{
			return await _context.Orders.Where(o => o.UserID == userId).ToListAsync();
		}

		public async Task AddOrder(Order order)
		{
			_context.Orders.Add(order);
			await _context.SaveChangesAsync();
		}
	}
}