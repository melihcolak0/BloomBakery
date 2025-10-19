using _15PC_BloomBakery.DTOs.CategoryDTOs;
using _15PC_BloomBakery.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace _15PC_BloomBakery.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // Listeleme
        public async Task<IActionResult> Index()
        {
            ViewBag.pageTitle = "Kategori Bilgileri";
            var categories = await _categoryService.GetAllCategoriesAsync();
            return View(categories);
        }

        // Yeni Ekleme Sayfası (GET)
        [HttpGet]
        public IActionResult CreateCategory()
        {
            ViewBag.pageTitle = "Yeni Kategori Ekle";
            return View();
        }

        // Yeni Ekleme İşlemi (POST)
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            if (!ModelState.IsValid)
                return View(createCategoryDto);

            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return RedirectToAction(nameof(Index));
        }

        // Güncelleme Sayfası (GET)
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound();

            ViewBag.pageTitle = "Kategori Güncelle";
            return View(category);
        }

        // Güncelleme İşlemi (POST)
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            if (!ModelState.IsValid)
                return View(updateCategoryDto);

            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return RedirectToAction(nameof(Index));
        }

        // Silme İşlemi
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
