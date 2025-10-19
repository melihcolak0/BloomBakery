using _15PC_BloomBakery.DTOs.ChefDTOs;
using _15PC_BloomBakery.Services.ChefServices;
using Microsoft.AspNetCore.Mvc;

namespace _15PC_BloomBakery.Controllers
{
    public class ChefController : Controller
    {
        private readonly IChefService _chefService;

        public ChefController(IChefService chefService)
        {
            _chefService = chefService;
        }

        // Listeleme
        public async Task<IActionResult> Index()
        {
            ViewBag.pageTitle = "Şef Bilgileri";
            var chefs = await _chefService.GetAllChefsAsync();
            return View(chefs);
        }

        // Yeni Ekleme Sayfası (GET)
        [HttpGet]
        public IActionResult CreateChef()
        {
            ViewBag.pageTitle = "Yeni Şef Ekle";
            return View();
        }

        // Yeni Ekleme İşlemi (POST)
        [HttpPost]
        public async Task<IActionResult> CreateChef(CreateChefDto createChefDto)
        {
            if (!ModelState.IsValid)
                return View(createChefDto);

            await _chefService.CreateChefAsync(createChefDto);
            return RedirectToAction(nameof(Index));
        }

        // Güncelleme Sayfası (GET)
        [HttpGet]
        public async Task<IActionResult> UpdateChef(int id)
        {
            var chef = await _chefService.GetChefByIdAsync(id);
            if (chef == null)
                return NotFound();

            ViewBag.pageTitle = "Şef Güncelle";
            return View(chef);
        }

        // Güncelleme İşlemi (POST)
        [HttpPost]
        public async Task<IActionResult> UpdateChef(UpdateChefDto updateChefDto)
        {
            if (!ModelState.IsValid)
                return View(updateChefDto);

            await _chefService.UpdateChefAsync(updateChefDto);
            return RedirectToAction(nameof(Index));
        }

        // Silme İşlemi
        public async Task<IActionResult> DeleteChef(int id)
        {
            await _chefService.DeleteChefAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
