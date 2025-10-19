using _15PC_BloomBakery.Services.SliderServices;
using Microsoft.AspNetCore.Mvc;

namespace _15PC_BloomBakery.ViewComponents.DefaultViewComponents
{
    public class _SliderDefaultViewComponent : ViewComponent
    {
        private readonly ISliderService _sliderService;

        public _SliderDefaultViewComponent(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sliders = await _sliderService.GetAllSlidersAsync();
            return View(sliders);
        }
    }
}
