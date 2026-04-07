using System.ComponentModel.DataAnnotations;
namespace PaulShop.API.DTOs.Account
{
    public class LoginRequestDTO
    {
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; } = null!;
    }
}