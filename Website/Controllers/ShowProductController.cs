using Microsoft.AspNetCore.Mvc;
using Model.Entity;
using ServiceComputer.Reponsive.Base;
using ServiceComputer.Reponsive.IRepo;

namespace ServiceComputer.Website.Controllers
{
    public class ShowProductController : Controller
    {
        private readonly IReponsive<Product> productRepo;
        public ShowProductController(IReponsive<Product> productRepo)
        {
            this.productRepo = productRepo;
        }
        public async Task<IActionResult> Index()
        {

            return View(await productRepo.GetAll());
        }
    }
}
