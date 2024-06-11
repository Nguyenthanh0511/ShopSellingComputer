using Microsoft.AspNetCore.Mvc;
using ServiceComputer.Website.ViewModel;

namespace ServiceComputer.Website.Controllers
{
    public class BlogController : Controller
    {
        private readonly List<Blog> _logs;
        public BlogController()
        {
            _logs = new List<Blog>()
            {
                new Blog()
                {
                    blogURL="https://tse2.mm.bing.net/th?id=OIP.oLkIyHYaTICMKQA9VJQl1gHaEK&pid=Api&P=0&h=220",
                    blogTitle=" Máy siêu xịn, ngon bổ rẻ, nức lòng,\r\n                                asperiores mollitia excepturi voluptatibus sequi nostrum ipsam veniam omnis nihil! A ea maiores corporis. Lorem ipsum dolor sit amet, consectetur adipisicing elit,\r\n                                sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                },
                new Blog()
                {
                    blogURL="https://tse4.mm.bing.net/th?id=OIP.5WDkCFfsNRXviWiQReDefwHaEK&pid=Api&P=0&h=220",
                    blogTitle=" Máy siêu xịn, ngon bổ rẻ, nức lòng,\r\n                                asperiores mollitia excepturi voluptatibus sequi nostrum ipsam veniam omnis nihil! A ea maiores corporis. Lorem ipsum dolor sit amet, consectetur adipisicing elit,\r\n                                sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                },
            };
        }
        public IActionResult Index()
        {
            return View(_logs);
        }
    }
}
