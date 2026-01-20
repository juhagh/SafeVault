using System.Text.RegularExpressions;

namespace SafeVault.Security
{
    public static class InputSanitizer
    {
        public static string Sanitize(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Remove common XSS / injection characters
            return Regex.Replace(input, @"[<>""';]", string.Empty);
        }
    }
}