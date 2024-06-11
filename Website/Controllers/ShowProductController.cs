using Microsoft.AspNetCore.Mvc;
using ServiceComputer.Reponsive.IRepo;

namespace ServiceComputer.Website.Controllers
{
    public class ShowProductController : Controller
    {
        private readonly IProductRepo productRepo;
        public ShowProductController(IProductRepo productRepo)
        {
            this.productRepo = productRepo;
        }
        public async Task<IActionResult> Index()
        {

            return View(await productRepo.GetAll());
        }
    }
}
