using System.ComponentModel.DataAnnotations;

namespace PaulShop.API.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        // Quan hệ 1-n: Một danh mục có nhiều sản phẩm
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}