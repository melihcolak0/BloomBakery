using _15PC_BloomBakery.Services.ChefServices;
using _15PC_BloomBakery.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace _15PC_BloomBakery.ViewComponents.DefaultViewComponents
{
    public class _TestimonialDefaultViewComponent : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public _TestimonialDefaultViewComponent(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var testimonials = await _testimonialService.GetAllTestimonialsAsync();
            return View(testimonials);
        }
    }
}
