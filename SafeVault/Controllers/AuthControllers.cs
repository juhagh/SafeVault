using Microsoft.AspNetCore.Mvc;
using SafeVault.Data;
using SafeVault.Services;

namespace SafeVault.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = UserStore.FindUser(username);

            if (user == null || !AuthService.VerifyPassword(password, user.PasswordHash))
            {
                ModelState.AddModelError("", "Invalid credentials");
                return View();
            }

            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Role", user.Role);

            return RedirectToAction("Index", "SafeVault");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}