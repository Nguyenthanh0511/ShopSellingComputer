using Microsoft.AspNetCore.Mvc;
using ServiceComputer.Reponsive.IRepo;

namespace ServiceComputer.Website.Controllers
{
    public class HomePageController : Controller 
    {
        private readonly IProductRepo _repo;
        public HomePageController(IProductRepo repo)
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
