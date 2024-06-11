using Microsoft.AspNetCore.Mvc;
using Model.Entity;
using ServiceComputer.Reponsive.Base;
using ServiceComputer.Reponsive.IRepo;
using ServiceComputer.Reponsive.Repo;

namespace ServiceComputer.Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepo _repo;
        public  CategoryController (ICategoryRepo repo)
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
        public async Task<IActionResult> Create(Category entity)
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
            var category = await _repo.GetId(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteRepo(id);
            if (_repo.checkStatus!=false)
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
            var category = await _repo.GetId(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

                await _repo.UpdateRepo(category);
                if (_repo.checkStatus != false)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest(_repo.noticationErr);
                }

            return View(category);
        }
    }
}
