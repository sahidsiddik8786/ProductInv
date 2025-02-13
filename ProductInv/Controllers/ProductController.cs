using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductInventoryAPI.Database;
using ProductInventoryAPI.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public ProductController(ProductDbContext context)
        {
            _context = context;
        }

        // Create a product
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            product.Id = Guid.NewGuid();
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }

        // List all products
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products.Include(p => p.Variants).ThenInclude(v => v.SubVariants).ToListAsync();
            return Ok(products);
        }
    }
}
