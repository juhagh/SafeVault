using Microsoft.AspNetCore.Mvc;
using SafeVault.Models;
using SafeVault.Data;
using SafeVault.Security;

namespace SafeVault.Controllers
{
    public class SafeVaultController : Controller
    {
        private readonly UserRepository _repository;

        public SafeVaultController(UserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(UserInput input)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", input);
            }

            // 🔐 Sanitize inputs (AI-assisted fix)
            var sanitizedUser = new UserInput
            {
                Username = InputSanitizer.Sanitize(input.Username),
                Email = InputSanitizer.Sanitize(input.Email)
            };

            // ✅ Correct repository method
            _repository.SaveUser(sanitizedUser);

            return View("Success");
        }
    }
}