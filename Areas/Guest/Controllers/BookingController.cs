using DestinyHaven.Entity;
using DestinyHaven.GenericModels;
using DestinyHaven.Services.Interface;
using DestinyHaven.ViewModels;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Model.V2.Subscription;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Security.Claims;

namespace DestinyHaven.Areas.Guest.Controllers
{
    public class BookingController : Controller
    {
        IRoomService roomService;
        IBookingService bookingService;
        UserManager<AppUser> userManager;

        public BookingController(IRoomService roomService, IBookingService bookingService, UserManager<AppUser> userManager)
        {
            this.roomService = roomService;
            this.bookingService = bookingService;
            this.userManager = userManager;
        }

        public bool flag=false;
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.flag = flag;
            // ! SelectBox ---
            int selectedRoomType = id;
            var rooms = await roomService.GetRooms();
            List<SelectListItem> roomItems = new List<SelectListItem>();
            foreach (var room in rooms)
            {
                roomItems.Add(new SelectListItem
                {
                    Value = room.Id.ToString(),
                    Text = room.Name,
                    Selected = (room.Id == selectedRoomType)
                });
            }
            ViewBag.RoomTypes = new SelectList(roomItems, "Value", "Text");
            ViewBag.SelectedRoomType = selectedRoomType.ToString();
            // ! -----------------------------------------------------------------------
            return View();
        }
        [HttpPost]
        public async Task<bool> Index([FromBody] BookingViewModel bookingViewModel)
        {
            flag= true;
            ViewBag.flag=flag;
            #region ROLE CHECK
            // ! SelectBox ---
            var rooms = await roomService.GetRooms();
            List<SelectListItem> roomItems = new List<SelectListItem>();
            foreach (var room in rooms)
            {
                roomItems.Add(new SelectListItem
                {
                    Value = room.Id.ToString(),
                    Text = room.Name,
                    Selected = (room.Id == 1)
                });
            }
            ViewBag.RoomTypes = new SelectList(roomItems, "Value", "Text");
            ViewBag.SelectedRoomType = "1";
            // ! -----------------------------------------------------------------------
            #endregion
            bookingViewModel.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (bookingViewModel.UserId != null)
            {

                var user = await userManager.FindByIdAsync(bookingViewModel.UserId);
                try
                {
                 var result = await bookingService.NewBooking(bookingViewModel);
                    if (result.Id != 0)
                    {
                        OrderStatic.RoomDetails = result.RoomDetails;
                        OrderStatic.UserName = User.Identity.Name ;
                        OrderStatic.BookingId = result.Id.ToString();
                        OrderStatic.UserId = bookingViewModel.UserId;
                        OrderStatic.Email = user.Email;
                        return true;
                    }
                }
                catch (Exception)
                {

                    return false;
                }
                
            }
            return false;
                }

    }
}
