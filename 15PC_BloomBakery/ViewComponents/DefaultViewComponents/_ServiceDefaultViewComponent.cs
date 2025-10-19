using _15PC_BloomBakery.Services.ProductServices;
using _15PC_BloomBakery.Services.ServiceServices;
using Microsoft.AspNetCore.Mvc;

namespace _15PC_BloomBakery.ViewComponents.DefaultViewComponents
{
    public class _ServiceDefaultViewComponent : ViewComponent
    {
        private readonly IServiceService _serviceService;

        public _ServiceDefaultViewComponent(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var services = await _serviceService.GetAllServicesAsync();
            return View(services);
        }
    }
}
