using Microsoft.AspNetCore.Mvc;

namespace ServiceComputer.Website.Controllers
{
    public class ShopCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
