using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaulShop.API.Models;
using BCrypt.Net;

namespace PaulShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly PaulShopContext _context;

        public AccountsController(PaulShopContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(Account account)
        {
            // 1. Kiểm tra email đã tồn tại chưa
            if (await _context.Accounts.AnyAsync(a => a.Email == account.Email))
            {
                return BadRequest("Email này đã được sử dụng!");
            }

            // 2. Mã hóa mật khẩu trước khi lưu
            account.Id = Guid.NewGuid();
            account.PasswordHash = BCrypt.Net.BCrypt.HashPassword(account.PasswordHash);
            account.CreatedAt = DateTime.UtcNow;

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return Ok("Đăng ký tài khoản thành công!");
        }
    }
}