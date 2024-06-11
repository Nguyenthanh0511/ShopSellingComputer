using Microsoft.AspNetCore.Mvc;
using Model.Entity;
using ServiceComputer.Reponsive.Base;
using ServiceComputer.Reponsive.IRepo;

namespace ServiceComputer.Website.Controllers
{
    public class HomePageController : Controller 
    {
        private readonly IReponsive<Product> _repo;
        public HomePageController(IReponsive<Product> repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var entity = await _repo.GetAll();
            if (entity != null)
            {
                return View(entity);
            }
            else
            {
                return BadRequest(_repo.noticationErr);
            }
        }
    }
}
