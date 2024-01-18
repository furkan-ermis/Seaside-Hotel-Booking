using Microsoft.AspNetCore.Mvc;

namespace DestinyHaven.Areas.Guest.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Rooms()
        {
            return View();
        }
        public IActionResult RoomSingle()
        {
            return View();
        }
    }
}
