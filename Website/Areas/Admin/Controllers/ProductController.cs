using Microsoft.AspNetCore.Mvc;
using Model.Entity;
using ServiceComputer.Reponsive.IRepo;

namespace ServiceComputer.Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepo _repo;
        public ProductController(IProductRepo repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product entity)
        {
            await _repo.UpdateRepo(entity);
            if (_repo.checkStatus != false)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest(_repo.noticationErr);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var Product = await _repo.GetId(id);
            if (Product == null)
            {
                return NotFound();
            }

            return View(Product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteRepo(id);
            if (_repo.checkStatus != false)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest(_repo.noticationErr);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var Product = await _repo.GetId(id);
            if (Product == null)
            {
                return NotFound();
            }

            return View(Product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Product Product)
        {
            if (id != Product.Id)
            {
                return NotFound();
            }

            await _repo.UpdateRepo(Product);
            if (_repo.checkStatus != false)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest(_repo.noticationErr);
            }

            return View(Product);
        }
    }
}
