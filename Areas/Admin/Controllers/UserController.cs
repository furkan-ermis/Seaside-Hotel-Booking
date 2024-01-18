using DestinyHaven.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DestinyHaven.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var users = await userService.GetAllUserAsync();
            return View(users);
        }
    }
}
