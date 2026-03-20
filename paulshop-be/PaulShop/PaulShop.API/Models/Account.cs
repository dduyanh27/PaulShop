using System.ComponentModel.DataAnnotations;

namespace PaulShop.API.Models
{
    public class Account
    {
        public Guid Id { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; } = null!;

        [Required]
        public string PasswordHash { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        // Phân quyền: "Admin" hoặc "Customer"
        public string Role { get; set; } = "Customer";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;
    }
}