using SafeVault.Models;
using SafeVault.Services;
using System.Collections.Generic;
using System.Linq;

namespace SafeVault.Data
{
    public static class UserStore
    {
        public static List<UserAccount> Users = new()
        {
            new UserAccount
            {
                Username = "admin",
                PasswordHash = AuthService.HashPassword("Admin123!"),
                Role = "Admin"
            },
            new UserAccount
            {
                Username = "user",
                PasswordHash = AuthService.HashPassword("User123!"),
                Role = "User"
            }
        };

        public static UserAccount? FindUser(string username)
        {
            return Users.FirstOrDefault(u => u.Username == username);
        }
    }
}