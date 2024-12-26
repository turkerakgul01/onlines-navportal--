using Microsoft.AspNetCore.Mvc;

namespace onlinesinavportali.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
