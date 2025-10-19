using Microsoft.AspNetCore.Mvc;

namespace _15PC_BloomBakery.Controllers
{
    public class ChatBotController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.pageTitle = "ChatBot";
            return View();
        }
    }
}
