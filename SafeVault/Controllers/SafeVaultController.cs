using Microsoft.AspNetCore.Mvc;
using SafeVault.Models;
using SafeVault.Data;

namespace SafeVault.Controllers
{
    public class SafeVaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(UserInput input)
        {
            if (!ModelState.IsValid)
                return View("Index");

            // Sanitize inputs
            input.Username = UserInput.Sanitize(input.Username);
            input.Email = UserInput.Sanitize(input.Email);

            // Simulated persistence
            UserRepository.FakeDatabase.Add(input);
            return View("Success");
        }
    }
}