using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniAmazonClone.Models;
using MiniAmazonClone.Data; 
using System.Linq;

namespace MiniAmazonClone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

       
        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // Add product only by Admin
        [Authorize(Roles = "Admin")]
        [HttpPost("addProduct")]
        public IActionResult AddProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product data is required.");
            }

            
            var existingProduct = _context.Products
                                            .FirstOrDefault(p => p.Name == product.Name);
            if (existingProduct != null)
            {
                return Conflict("Product with the same name already exists.");
            }

            // Add the product to the database
            _context.Products.Add(product);
            _context.SaveChanges();

            return Ok(new { Message = "Product added successfully!" });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("updateProduct/{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            if (id <= 0 || product == null)
            {
                return BadRequest("Invalid data.");
            }

            // Check if the product exists in the database
            var existingProduct = _context.Products.FirstOrDefault(p => p.ProductID == id);
            if (existingProduct == null)
            {
                return NotFound("Product not found.");
            }

            // Update the product data
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;
            existingProduct.CreatedBy = product.CreatedBy;

            // Save the changes to the database
            _context.SaveChanges();

            return Ok(new { Message = "Product updated successfully!" });
        }
        //Create an endpoint /products to list all available products 

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }


    }
}
