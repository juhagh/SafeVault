using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SafeVault.Models
{
    public class UserInput
    {
        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Sanitization helper
        public static string Sanitize(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // Remove script tags & special characters
            input = Regex.Replace(input, "<.*?>", string.Empty);
            input = Regex.Replace(input, @"[;'""--]", string.Empty);

            return input;
        }
    }
}