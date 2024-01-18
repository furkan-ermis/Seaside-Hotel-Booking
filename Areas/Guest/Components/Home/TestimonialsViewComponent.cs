using Microsoft.AspNetCore.Mvc;

[ViewComponent]
public class TestimonialsViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("/Areas/Guest/Views/Shared/Components/Home/Testimonials/Default.cshtml");
    }
}

