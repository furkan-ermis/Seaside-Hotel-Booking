using Microsoft.AspNetCore.Mvc;

[ViewComponent]
public class ContactInfoViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("/Areas/Guest/Views/Shared/Components/Home/ContactInfo/Default.cshtml");
    }
}

