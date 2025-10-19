using _15PC_BloomBakery.DTOs.ServiceDTOs;
using _15PC_BloomBakery.Services.ServiceServices;
using Microsoft.AspNetCore.Mvc;

namespace _15PC_BloomBakery.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        // Listeleme
        public async Task<IActionResult> Index()
        {
            ViewBag.pageTitle = "Hizmet Bilgileri";
            var services = await _serviceService.GetAllServicesAsync();
            return View(services);
        }

        // Yeni Ekleme Sayfası (GET)
        [HttpGet]
        public IActionResult CreateService()
        {
            ViewBag.pageTitle = "Yeni Hizmet Ekle";
            return View();
        }

        // Yeni Ekleme İşlemi (POST)
        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            if (!ModelState.IsValid)
                return View(createServiceDto);

            await _serviceService.CreateServiceAsync(createServiceDto);
            return RedirectToAction(nameof(Index));
        }

        // Güncelleme Sayfası (GET)
        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var service = await _serviceService.GetServiceByIdAsync(id);
            if (service == null)
                return NotFound();

            ViewBag.pageTitle = "Hizmet Güncelle";
            return View(service);
        }

        // Güncelleme İşlemi (POST)
        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            if (!ModelState.IsValid)
                return View(updateServiceDto);

            await _serviceService.UpdateServiceAsync(updateServiceDto);
            return RedirectToAction(nameof(Index));
        }

        // Silme İşlemi
        public async Task<IActionResult> DeleteService(int id)
        {
            await _serviceService.DeleteServiceAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
