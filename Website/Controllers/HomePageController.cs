using Microsoft.AspNetCore.Mvc;

namespace ServiceComputer.Website.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
