using _15PC_BloomBakery.DTOs.TestimonialDTOs;
using _15PC_BloomBakery.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace _15PC_BloomBakery.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        // Listeleme
        public async Task<IActionResult> Index()
        {
            ViewBag.pageTitle = "Referans Bilgileri";
            var testimonials = await _testimonialService.GetAllTestimonialsAsync();
            return View(testimonials);
        }

        // Yeni Ekleme Sayfası (GET)
        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            ViewBag.pageTitle = "Yeni Referans Ekle";
            return View();
        }

        // Yeni Ekleme İşlemi (POST)
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            if (!ModelState.IsValid)
                return View(createTestimonialDto);

            await _testimonialService.CreateTestimonialAsync(createTestimonialDto);
            return RedirectToAction(nameof(Index));
        }

        // Güncelleme Sayfası (GET)
        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var testimonial = await _testimonialService.GetTestimonialByIdAsync(id);
            if (testimonial == null)
                return NotFound();

            ViewBag.pageTitle = "Referans Güncelle";
            return View(testimonial);
        }

        // Güncelleme İşlemi (POST)
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            if (!ModelState.IsValid)
                return View(updateTestimonialDto);

            await _testimonialService.UpdateTestimonialAsync(updateTestimonialDto);
            return RedirectToAction(nameof(Index));
        }

        // Silme İşlemi
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _testimonialService.DeleteTestimonialAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
