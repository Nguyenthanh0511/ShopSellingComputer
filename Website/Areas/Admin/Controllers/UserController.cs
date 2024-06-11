using Microsoft.AspNetCore.Mvc;
using Model.Entity;
using ServiceComputer.Reponsive.Base;

namespace ServiceComputer.Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IReponsive<User> _userRepo;
        public UserController(IReponsive<User> userRepo)
        {
            _userRepo = userRepo;
        }
    
        public async Task<IActionResult> Index()
        {
            return View(await _userRepo.GetAll());
        }
    }
}
