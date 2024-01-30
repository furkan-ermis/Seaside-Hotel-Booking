using DestinyHaven.Entity;
using DestinyHaven.Services.Interface;
using DestinyHaven.ViewModels;
using Microsoft.AspNetCore.Mvc;

[ViewComponent]
public class TestimonialsViewComponent : ViewComponent
{
    IHomeService _homeService;

    public TestimonialsViewComponent(IHomeService homeService)
    {
        _homeService = homeService;
    }

    public IViewComponentResult Invoke()
    {
        List<TestimonyViewModel> testimonials = _homeService.GetTestimonials().Result;
        return View("/Areas/Guest/Views/Shared/Components/Home/Testimonials/Default.cshtml",testimonials);
    }

    
}

