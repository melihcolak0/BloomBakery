using _15PC_BloomBakery.Services.AboutServices;
using _15PC_BloomBakery.Services.SliderServices;
using Microsoft.AspNetCore.Mvc;

namespace _15PC_BloomBakery.ViewComponents.DefaultViewComponents
{
    public class _AboutDefaultViewComponent : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public _AboutDefaultViewComponent(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var abouts = await _aboutService.GetAllAboutsAsync();
            return View(abouts);
        }
    }
}
