using Chatbot.Infrastructure.Dtto;
using Chatbot.Infrastructure.Services;
using Chatbot.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chatbot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        protected readonly IContatoInterfaceServices _contatoServices;

        public ContatoController(IContatoInterfaceServices contatoServices)
        {
            _contatoServices = contatoServices;
        }
        [HttpGet("/Contatos/Get")]
        public async Task<IActionResult> BuscarTodosContato() => Ok(await _contatoServices.GetALl());
    }
}
