using Chatbot.API.Models;
using Chatbot.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace chatbot.view.Controllers
{
    public class LogarController : Controller
    {
        protected readonly LoginRepository _loginRepository;

        public LogarController(LoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
