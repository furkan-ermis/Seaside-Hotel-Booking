using DestinyHaven.Entity;
using DestinyHaven.Services.Interface;
using Microsoft.AspNetCore.Mvc;

[ViewComponent]
public class OurRoomsViewComponent : ViewComponent
{
    IRoomService _RoomService;

    public OurRoomsViewComponent(IRoomService roomService)
    {
        _RoomService = roomService;
    }

    public IViewComponentResult Invoke()
    {
        List<Room> RoomList = _RoomService.GetRooms().Result.Take(3).ToList();
        return View("/Areas/Guest/Views/Shared/Components/Home/OurRooms/Default.cshtml", RoomList);
    }
}

