using DestinyHaven.Data;
using DestinyHaven.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DestinyHaven.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DefaultController : Controller
    {
        Context context;
        UserManager<AppUser> userManager;

        public DefaultController(Context context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public ActionResult Index()
        {
            var user=GetUser();
            ViewData["Avatar"] = user.ImageUrl;
            return View(context.Rooms.ToList());
        }

        private AppUser GetUser()
        {
            AppUser user = userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)).Result;
            return user;
        }

        // GET: HomeController/Details/5
        public ActionResult Users()
        {
            var user = GetUser();
            ViewBag.Avatar = user.ImageUrl;
            return View(context.Users.ToList());
        }

        // GET: HomeController/Create
        public ActionResult Bookings()
        {
            var user = GetUser();
            ViewBag.Avatar = user.ImageUrl;
            return View(context.Bookings.Include(x=>x.AppUser).Include(x=>x.RoomDetails).ToList());
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            var user = GetUser();
            ViewBag.Avatar = user.ImageUrl;
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            var user = GetUser();
            ViewBag.Avatar = user.ImageUrl;
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            var user = GetUser();
            ViewBag.Avatar = user.ImageUrl;
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var user = GetUser();
            ViewBag.Avatar = user.ImageUrl;
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var user = GetUser();
            ViewBag.Avatar = user.ImageUrl;
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
