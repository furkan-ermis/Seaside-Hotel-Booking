using DestinyHaven.Entity;
using DestinyHaven.Services.Interface;
using DestinyHaven.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Ocsp;
using System.Security.Claims;

namespace DestinyHaven.Areas.Guest.Controllers
{
    public class HomeController : Controller
    {
        IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> About()
        {

            var facilities=await _homeService.GetFacilities();
            return View(facilities);
        }
        public async Task<IActionResult> Gallery()
        {
            var gallery = await _homeService.GetGallery();
            return View(gallery);
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(string Message)
        {
            string result = "false";
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId != null)
                {
                var contact = new Contact
                {
                    Message = Message,
                    UserId = userId
                };
                await _homeService.AddContact(contact);
                result = "true";
                }
            }
            TempData["Message"] = result;
            return View("Contact");
        }

    }
}
