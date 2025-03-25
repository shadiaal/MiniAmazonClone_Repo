using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniAmazonClone.Models;
using MiniAmazonClone.Services;
using System.Security.Claims;
using MiniAmazonClone.Models.Dto;
using MiniAmazonClone.Data;

namespace MiniAmazonClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;
		private readonly AppDbContext _context;

		public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        //API endpoint to get orders with products
    
        [HttpGet("using-ef-core")]
        public async Task<IActionResult> GetOrdersWithProductsUsingEFCore()
        {
            var orders = await _orderService.GetOrdersWithProductsAsyncUsingEFCore();
            return Ok(orders);
        }

        [HttpGet("using-dapper")]
        public async Task<IActionResult> GetOrdersWithProductsUsingDapper()
        {
            var orders = await _orderService.GetOrdersWithProductsAsyncUsingDapper();
            return Ok(orders);
        }


		
		[Authorize(Policy = "CanViewOrders")]
		[HttpGet("orders/all")]
		public ActionResult<List<Order>> GetAllOrders()
		{
			var orders = _context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Product).ToList();
			return Ok(orders);
		}


		[Authorize(Policy = "CanRefundOrders")]
        [HttpPost("refund/{orderId}")]
        public async Task<IActionResult> RefundOrder(int orderId)
        {
            
            var isRefunded = await _orderService.RefundOrderAsync(orderId);

            if (!isRefunded)
            {
                return BadRequest(new { Message = "Refund failed. Order not found or not eligible for refund." });
            }

            return Ok(new { Message = "Order refunded successfully!" });
        }




        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null) return NotFound("Order not found");

            return Ok(order);
        }

		[Authorize]
		[HttpPost("create")]

		      public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto orderDto)
		      {
		          var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		          if (userId == null)
		          {
		              return Unauthorized("User not found");
		          }

		          var order = await _orderService.CreateOrderAsync(int.Parse(userId), orderDto);

		          if (order == null)
		          {
		              return BadRequest("Order creation failed. Some products may not be available.");
		          }

		          return Ok(new { order.OrderID, order.TotalAmount, order.Status });
		      }



		


		
		
	}

}






