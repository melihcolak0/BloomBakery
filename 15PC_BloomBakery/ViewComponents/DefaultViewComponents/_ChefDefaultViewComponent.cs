using _15PC_BloomBakery.Services.ChefServices;
using _15PC_BloomBakery.Services.ServiceServices;
using Microsoft.AspNetCore.Mvc;

namespace _15PC_BloomBakery.ViewComponents.DefaultViewComponents
{
    public class _ChefDefaultViewComponent : ViewComponent
    {
        private readonly IChefService _chefService;

        public _ChefDefaultViewComponent(IChefService chefService)
        {
            _chefService = chefService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var chefs = await _chefService.GetAllChefsAsync();
            return View(chefs);
        }
    }
}
