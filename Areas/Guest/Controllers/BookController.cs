using Microsoft.AspNetCore.Mvc;

namespace DestinyHaven.Areas.Guest.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
