using DestinyHaven.Entity;
using DestinyHaven.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

[ViewComponent]
public class LuxeryRoomViewComponent : ViewComponent
{
    IRoomService _RoomService;

    public LuxeryRoomViewComponent(IRoomService roomService)
    {
        _RoomService = roomService;
    }

    public IViewComponentResult Invoke()
    {
        Room room = _RoomService.GetRooms().Result.OrderByDescending(x => x.RoomLeft).FirstOrDefault();
        return View("/Areas/Guest/Views/Shared/Components/Home/LuxeryRoom/Default.cshtml", room);
    }
}

