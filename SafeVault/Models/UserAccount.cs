using System.ComponentModel.DataAnnotations;

namespace SafeVault.Models
{
    public class UserAccount
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "User"; // Admin | User
    }
}