using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace ServiceComputer.Website.Controllers
{
    public class OtherPageController : Controller
    {
        private readonly List<String> _about = new List<String>();
        public OtherPageController() {
            _about = new List<String>()
                {
                   "https://th.bing.com/th/id/OIP.xDRMvXYbpX1ID66JrJVAOgHaJN?w=202&h=251&c=7&r=0&o=5&dpr=1.3&pid=1.7"
                    ,"https://th.bing.com/th/id/OIP.a9PCetJUjgkd-xWXNRA7_gHaLH?w=202&h=303&c=7&r=0&o=5&dpr=1.3&pid=1.7",
                   "https://th.bing.com/th/id/OIP.5rjGb1MD5srLUXn4rk_PXAAAAA?w=202&h=218&c=7&r=0&o=5&dpr=1.3&pid=1.7",
                   "https://th.bing.com/th/id/OIP.Akqke9Xd6kUALJ7zheUwbAHaHa?w=202&h=202&c=7&r=0&o=5&dpr=1.3&pid=1.7"
             }; 
        }

        public IActionResult About()
        {
            return View(_about);
        }
    }
}
