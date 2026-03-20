using System.ComponentModel.DataAnnotations;

namespace PaulShop.API.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [MaxLength(200)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Giá phải lớn hơn hoặc bằng 0")]
        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        // Lưu URL ảnh từ Minio
        public string? ImageUrl { get; set; }

        // Khóa ngoại liên kết tới Category
        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; } = null!;
    }
}