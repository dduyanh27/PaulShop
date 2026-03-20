using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaulShop.API.Models;

namespace PaulShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly PaulShopContext _context;

        public ProductsController(PaulShopContext context)
        {
            _context = context;
        }

        // 1. API Lấy danh sách sản phẩm (kèm theo thông tin Danh mục)
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            // Include(p => p.Category) giúp lấy luôn tên danh mục thay vì chỉ lấy CategoryId
            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            return Ok(products);
        }

        // 2. API Thêm sản phẩm mới
        [HttpPost]
        public async Task<IActionResult> PostProduct(Product product)
        {
            product.Id = Guid.NewGuid();

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }
    }
}