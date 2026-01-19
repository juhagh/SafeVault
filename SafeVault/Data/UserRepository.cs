using Microsoft.Data.SqlClient;

using SafeVault.Models;

namespace SafeVault.Data
{
    public class UserRepository
    {
        // Simulation only (not executed)
        public void SaveUser(UserInput user)
        {
            string query = "INSERT INTO Users (Username, Email) VALUES (@Username, @Email)";

            using (SqlCommand command = new SqlCommand(query))
            {
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Email", user.Email);
                
                // Execution intentionally omitted
            }
        }

        // Fake in-memory store
        public static List<UserInput> FakeDatabase = new();
    }
}