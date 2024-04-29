using Microsoft.AspNetCore.Mvc;

namespace chatbot.view.Controllers
{
    public class BotController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
