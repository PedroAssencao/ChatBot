using Chatbot.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chatbot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private readonly AtendimentoRepository _repository;

        public AtendimentoController(AtendimentoRepository repository)
        {
            _repository = repository;
        }

        //[HttpGet("/Atendimento/Mensagens/{id}")]
        //public async Task<IActionResult> PegarMensagensDoChatEspecifico(int id)
        //{

        //}
    }
}
