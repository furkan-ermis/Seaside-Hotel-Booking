using Microsoft.AspNetCore.Mvc;

[ViewComponent]
public class LuxeryRoomViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("/Areas/Guest/Views/Shared/Components/Home/LuxeryRoom/Default.cshtml");
    }
}

