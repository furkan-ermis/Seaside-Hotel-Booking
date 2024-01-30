using DestinyHaven.Entity;
using DestinyHaven.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DestinyHaven.Areas.Guest.Controllers
{
    public class RoomController : Controller
    {
        IRoomService _RoomService;

        public RoomController(IRoomService roomService)
        {
            _RoomService = roomService;
        }

        public async Task<IActionResult> Rooms()
        {
            List<Room> RoomList=await _RoomService.GetRooms();
            return View(RoomList);
        }
        public async Task<IActionResult> RoomSingle(int id)
        {
            if(id==0)
            {
                return RedirectToAction("Rooms");
            }
            Room Room=await _RoomService.GetRoomById(id);
            return View(Room);
        }
    }
}
