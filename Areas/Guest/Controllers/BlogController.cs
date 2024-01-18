using Microsoft.AspNetCore.Mvc;

namespace DestinyHaven.Areas.Guest.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Blogs()
        {
            return View();
        }
        public IActionResult BlogSingle()
        {
            return View();
        }

    }
}
