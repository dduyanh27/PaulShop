using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaulShop.API.Models;

namespace PaulShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly PaulShopContext _context;

        public CategoriesController(PaulShopContext context)
        {
            _context = context;
        }

        // 1. API Lấy danh sách danh mục
        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }

        // 2. API Tạo danh mục mới
        // POST: api/Categories
        [HttpPost]
        public async Task<IActionResult> PostCategory(Category category)
        {
            // Tự động tạo ID mới
            category.Id = Guid.NewGuid();

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return Ok(category);
        }
    }
}