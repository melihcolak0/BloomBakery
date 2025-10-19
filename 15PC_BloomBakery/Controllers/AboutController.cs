using _15PC_BloomBakery.AIIntegration;
using _15PC_BloomBakery.DTOs.AboutDTOs;
using _15PC_BloomBakery.DTOs.AIDTOs;
using _15PC_BloomBakery.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace _15PC_BloomBakery.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly RapidApiGPT4oIntegration _rapidApiGPT4oIntegrationService;

        public AboutController(IAboutService aboutService, RapidApiGPT4oIntegration rapidApiGPT4oIntegrationService)
        {
            _aboutService = aboutService;
            _rapidApiGPT4oIntegrationService = rapidApiGPT4oIntegrationService;
        }

        // Listeleme
        public async Task<IActionResult> Index()
        {
            ViewBag.pageTitle = "Hakkımızda Bilgileri";
            var abouts = await _aboutService.GetAllAboutsAsync();
            return View(abouts);
        }

        // Yeni Ekleme Sayfası (GET)
        [HttpGet]
        public IActionResult CreateAbout()
        {
            ViewBag.pageTitle = "Yeni Hakkımızda Ekle";
            return View();
        }

        // Yeni Ekleme İşlemi (POST)
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            if (!ModelState.IsValid)
                return View(createAboutDto);

            await _aboutService.CreateAboutAsync(createAboutDto);
            return RedirectToAction(nameof(Index));
        }

        // Güncelleme Sayfası (GET)
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var about = await _aboutService.GetAboutByIdAsync(id);
            if (about == null)
                return NotFound();

            ViewBag.pageTitle = "Hakkımızda Güncelle";
            return View(about);
        }

        // Güncelleme İşlemi (POST)
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            if (!ModelState.IsValid)
                return View(updateAboutDto);

            await _aboutService.UpdateAboutAsync(updateAboutDto);
            return RedirectToAction(nameof(Index));
        }

        // Silme İşlemi
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> GenerateAnAboutSection()
        {
            ViewBag.pageTitle = "AI ile Hakkımızda Bölümü Oluşturma";
            return View();
        }       

        [HttpPost]
        public async Task<IActionResult> GenerateAnAboutSection(ResultRapidApiGPT4oIntegrationDto dto, string action)
        {
            // Prompt sabit, başlık zaten formda sabit
            var prompt = @"Bloom Bakery için Hakkımızda bölümü oluştur. Alt başlık yaratıcı ve markayı tanıtan kısa bir cümle olsun. Markdown formatında ver:
                                        ## Alt Başlık
                                        Bir paragraf açıklama (Description)

                                        ### Özelliklerimiz
                                        - **Özellik 1 Başlığı** ...
                                        - **Özellik 2 Başlığı** ...
                                        - **Özellik 3 Başlığı** ...
                                        - **Özellik 4 Başlığı** ...

                                        Sadece Markdown formatında, başka açıklama ekleme.";

            if (action == "generate")
            {
                try
                {
                    ModelState.Clear();

                    // API çağrısı
                    var apiText = await _rapidApiGPT4oIntegrationService.GenerateTextAsync(prompt);

                    // Parse et
                    var parsedDto = _rapidApiGPT4oIntegrationService.ParseAboutText(apiText);

                    // Formu doldur
                    dto.Title = parsedDto.Title; // Sabit "HAKKIMIZDA"
                    dto.SubTitle = parsedDto.SubTitle;
                    dto.Description = parsedDto.Description;
                    dto.Feature1 = parsedDto.Feature1;
                    dto.Feature2 = parsedDto.Feature2;
                    dto.Feature3 = parsedDto.Feature3;
                    dto.Feature4 = parsedDto.Feature4;
                    dto.ImageUrl = parsedDto.ImageUrl;
                    dto.ImageUrl2 = parsedDto.ImageUrl2;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"API çağrısında hata oluştu: {ex.Message}");
                }

                return View(dto);
            }
            else if (action == "save")
            {
                if (!ModelState.IsValid)
                    return View(dto);

                var createAboutDto = new CreateAboutDto
                {
                    Title = dto.Title,
                    SubTitle = dto.SubTitle,
                    Description = dto.Description,
                    Feature1 = dto.Feature1,
                    Feature2 = dto.Feature2,
                    Feature3 = dto.Feature3,
                    Feature4 = dto.Feature4,
                    ImageUrl = dto.ImageUrl,
                    ImageUrl2 = dto.ImageUrl2
                };

                await _aboutService.CreateAboutAsync(createAboutDto);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.pageTitle = "AI ile Hakkımızda Bölümü Oluşturma";
            return View(dto);
        }
    }
}
