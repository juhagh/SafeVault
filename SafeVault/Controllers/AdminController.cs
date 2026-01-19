using Microsoft.AspNetCore.Mvc;
using SafeVault.Security;

namespace SafeVault.Controllers
{
    public class AdminController : Controller
    {
        [RoleAuthorize("Admin")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}