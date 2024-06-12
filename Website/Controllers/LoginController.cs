using Microsoft.AspNetCore.Mvc;

namespace ServiceComputer.Website.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
