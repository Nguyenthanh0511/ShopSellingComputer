using Microsoft.AspNetCore.Mvc;

namespace ServiceComputer.Website.Controllers
{
    public class OtherPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
