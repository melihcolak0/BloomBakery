using _15PC_BloomBakery.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _15PC_BloomBakery.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IProductService _produtService;

        public DefaultController(IProductService produtService)
        {
            _produtService = produtService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Products(string category, decimal? minPrice, decimal? maxPrice)
        {
            var values = await _produtService.GetAllProductsAsync();

            // Kategori filtreleme
            if (!string.IsNullOrEmpty(category))
                values = values.Where(x => x.CategoryName == category).ToList();

            // Fiyat filtreleme
            if (minPrice.HasValue)
                values = values.Where(x => x.UnitPrice >= minPrice.Value).ToList();

            if (maxPrice.HasValue)
                values = values.Where(x => x.UnitPrice <= maxPrice.Value).ToList();

            ViewBag.Categories = values.Select(x => x.CategoryName).Distinct().ToList();
            ViewBag.SelectedCategory = category;
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            return View(values);
        }        
    }
}
