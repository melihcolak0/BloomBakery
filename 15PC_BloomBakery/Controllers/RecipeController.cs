using _15PC_BloomBakery.AIIntegration;
using _15PC_BloomBakery.DTOs.AIDTOs;
using Microsoft.AspNetCore.Mvc;

namespace _15PC_BloomBakery.Controllers
{
    public class RecipeController : Controller
    {
        private readonly RapidApiGPT4oIntegration _ai;

        public RecipeController()
        {
            _ai = new RapidApiGPT4oIntegration();
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.pageTitle = "Tarif Öneri Asistanı";
            return View(new RecipeDto());
        }

        [HttpPost]
        public async Task<IActionResult> Index(RecipeDto model)
        {
            if (!string.IsNullOrWhiteSpace(model.Prompt))
            {
                string prompt = $"Bu malzemelerle yapılabilecek yemekleri sırala ve kısa tarifleri ver:\n{model.Prompt}";
                ModelState.Clear();
                model.Answer = await _ai.GenerateTextAsync(prompt);
            }

            ViewBag.pageTitle = "Tarif Öneri Asistanı";
            return View(model);
        }
    }
}
