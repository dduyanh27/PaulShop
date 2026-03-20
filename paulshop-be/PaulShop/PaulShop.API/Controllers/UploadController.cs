using Microsoft.AspNetCore.Mvc;
using PaulShop.API.Services;

namespace PaulShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly MinioService _minioService;

        // Gọi MinioService vào để dùng
        public UploadController(MinioService minioService)
        {
            _minioService = minioService;
        }

        [HttpPost("image")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Vui lòng chọn một file ảnh!");
            }

            try
            {
                // Nhờ Service đẩy file lên và lấy về đường link
                var imageUrl = await _minioService.UploadFileAsync(file);

                // Trả về link ảnh thành công
                return Ok(new { url = imageUrl });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi hệ thống: {ex.Message}");
            }
        }
    }
}