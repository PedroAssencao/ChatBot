using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chatbot.view.Controllers
{
    [Authorize]
    public class BotController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
