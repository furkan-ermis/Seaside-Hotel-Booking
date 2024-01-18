using Microsoft.AspNetCore.Mvc;

[ViewComponent]
public class OurRoomsViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("/Areas/Guest/Views/Shared/Components/Home/OurRooms/Default.cshtml");
    }
}

