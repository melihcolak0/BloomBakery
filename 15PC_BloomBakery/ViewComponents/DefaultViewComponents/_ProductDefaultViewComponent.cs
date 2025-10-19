using _15PC_BloomBakery.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace _15PC_BloomBakery.ViewComponents.DefaultViewComponents
{
    public class _ProductDefaultViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductDefaultViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }
    }
}
