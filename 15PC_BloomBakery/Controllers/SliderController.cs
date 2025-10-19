using _15PC_BloomBakery.DTOs.SliderDTOs;
using _15PC_BloomBakery.Services.SliderServices;
using Microsoft.AspNetCore.Mvc;

namespace _15PC_BloomBakery.Controllers
{
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        // Listeleme
        public async Task<IActionResult> Index()
        {
            ViewBag.pageTitle = "Kayan Afiş Bilgileri";
            var sliders = await _sliderService.GetAllSlidersAsync();
            return View(sliders);
        }

        // Yeni Ekleme Sayfası (GET)
        [HttpGet]
        public IActionResult CreateSlider()
        {
            ViewBag.pageTitle = "Yeni Kayan Afiş Ekle";
            return View();
        }

        // Yeni Ekleme İşlemi (POST)
        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
        {
            if (!ModelState.IsValid)
                return View(createSliderDto);

            await _sliderService.CreateSliderAsync(createSliderDto);
            return RedirectToAction(nameof(Index));
        }

        // Güncelleme Sayfası (GET)
        [HttpGet]
        public async Task<IActionResult> UpdateSlider(int id)
        {
            var slider = await _sliderService.GetSliderByIdAsync(id);
            if (slider == null)
                return NotFound();

            ViewBag.pageTitle = "Kayan Afiş Güncelle";
            return View(slider);
        }

        // Güncelleme İşlemi (POST)
        [HttpPost]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            if (!ModelState.IsValid)
                return View(updateSliderDto);

            await _sliderService.UpdateSliderAsync(updateSliderDto);
            return RedirectToAction(nameof(Index));
        }

        // Silme İşlemi
        public async Task<IActionResult> DeleteSlider(int id)
        {
            await _sliderService.DeleteSliderAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
