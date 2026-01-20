using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SafeVault.Models
{
    public class UserInput : IValidatableObject
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Reject SQL injection patterns
            if (Regex.IsMatch(Username, @"('|--|;|\bOR\b|\bAND\b)", RegexOptions.IgnoreCase))
            {
                yield return new ValidationResult(
                    "Username contains invalid or dangerous characters.",
                    new[] { nameof(Username) }
                );
            }

            // Reject XSS patterns
            if (Regex.IsMatch(Username, @"<.*?>"))
            {
                yield return new ValidationResult(
                    "Username contains script-like content.",
                    new[] { nameof(Username) }
                );
            }
        }
    }
}