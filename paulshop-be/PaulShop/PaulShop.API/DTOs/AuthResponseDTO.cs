namespace PaulShop.API.DTOs.Account
{
    public class AuthResponseDTO
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string Token { get; set; } = null!; // Sẽ dùng cho JWT sau này
    }
}