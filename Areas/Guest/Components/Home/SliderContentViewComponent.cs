using Microsoft.AspNetCore.Mvc;

[ViewComponent]
public class SliderContentViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("/Areas/Guest/Views/Shared/Components/Home/SliderContent/Default.cshtml");
    }
}
