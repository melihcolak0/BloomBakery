using _15PC_BloomBakery.AIIntegration;
using _15PC_BloomBakery.DTOs.AIDTOs;
using _15PC_BloomBakery.DTOs.ProductDTOs;
using _15PC_BloomBakery.Services.CategoryServices;
using _15PC_BloomBakery.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _15PC_BloomBakery.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        // Listeleme
        public async Task<IActionResult> Index()
        {
            ViewBag.pageTitle = "Ürün Bilgileri";
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        // Yeni Ekleme Sayfası (GET)
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.pageTitle = "Yeni Ürün Ekle";

            //Kategorileri Getirme
            var categories = await _categoryService.GetAllCategoriesAsync();      
            ViewBag.CategoryList = categories.Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.CategoryId.ToString()
            }).ToList();

            return View();
        }

        // Yeni Ekleme İşlemi (POST)
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
                return View(createProductDto);

            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction(nameof(Index));
        }

        // Güncelleme Sayfası (GET)
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            //Kategorileri Getirme
            var categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.CategoryList = categories.Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.CategoryId.ToString()
            }).ToList();

            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();

            ViewBag.pageTitle = "Ürün Güncelle";
            return View(product);
        }

        // Güncelleme İşlemi (POST)
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            if (!ModelState.IsValid)
                return View(updateProductDto);

            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction(nameof(Index));
        }

        // Silme İşlemi
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // AI ile Ekleme Sayfası (GET)
        [HttpGet]
        public async Task<IActionResult> CreateProductWithAI()
        {
            ViewBag.pageTitle = "AI ile Ürün Ekleme";

            //Kategorileri Getirme
            var categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.CategoryList = categories.Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.CategoryId.ToString()
            }).ToList();

            return View();
        }

        // AI ile Ekleme Sayfası (POST)
        [HttpPost]
        public async Task<IActionResult> CreateProductWithAI(GenerateProductDetailsDto model, string action)
        {
            // Eğer kullanıcı "Oluştur" butonuna bastıysa
            if (action == "generate" && !string.IsNullOrWhiteSpace(model.ProductName))
            {
                var ai = new RapidApiGPT4oIntegration();

                // AI promptunu hazırla (çıktı formatını belirt)
                string prompt = $@"
Lütfen aşağıdaki formatta cevap ver:
Ürün Açıklaması:
<ürün açıklaması>

Tarif:
Malzemeler:
- ...

Yapılışı:
1. ...
        
Ürün adı: {model.ProductName}";

                // AI'dan yanıt al
                string aiResponse = await ai.GenerateTextAsync(prompt);

                // Regex ile Description ve Recipe ayrımı
                var descriptionMatch = Regex.Match(aiResponse, @"Ürün Açıklaması:\s*(.+?)\s*Tarif:", RegexOptions.Singleline);
                var recipeMatch = Regex.Match(aiResponse, @"Tarif:\s*(.+)", RegexOptions.Singleline);

                string rawDescription = descriptionMatch.Success ? descriptionMatch.Groups[1].Value.Trim() : "";
                string rawRecipe = recipeMatch.Success ? recipeMatch.Groups[1].Value.Trim() : "";

                // Markdown işaretlerini temizle
                string cleanDescription = Regex.Replace(rawDescription, @"[#*]+", "").Trim();
                string cleanRecipe = Regex.Replace(rawRecipe, @"[#*]+", "").Trim();

                model.Description = descriptionMatch.Success ? descriptionMatch.Groups[1].Value.Trim() : "";
                model.Recipe = recipeMatch.Success ? recipeMatch.Groups[1].Value.Trim() : "";

                ModelState.Clear();

                // ViewBag ile kullanıcıya göstermek için
                ViewBag.AIMessage = "AI tarafından içerik oluşturuldu!";

                // Kategorileri tekrar yükle
                var categories = await _categoryService.GetAllCategoriesAsync();
                ViewBag.CategoryList = categories.Select(c => new SelectListItem
                {
                    Text = c.CategoryName,
                    Value = c.CategoryId.ToString()
                }).ToList();

                return View(model);
            }
            // Eğer kullanıcı "Ekle" butonuna bastıysa
            else if (action == "save")
            {
                if (!ModelState.IsValid)
                {
                    var categories = await _categoryService.GetAllCategoriesAsync();
                    ViewBag.CategoryList = categories.Select(c => new SelectListItem
                    {
                        Text = c.CategoryName,
                        Value = c.CategoryId.ToString()
                    }).ToList();
                    return View(model);
                }

                await _productService.CreateProductAsync(new CreateProductDto
                {
                    ProductName = model.ProductName,
                    UnitPrice = model.UnitPrice,
                    Stock = model.Stock,
                    Description = model.Description,
                    Recipe = model.Recipe,
                    ImageUrl = model.ImageUrl,
                    CategoryId = model.CategoryId
                });

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }     
    }
}
