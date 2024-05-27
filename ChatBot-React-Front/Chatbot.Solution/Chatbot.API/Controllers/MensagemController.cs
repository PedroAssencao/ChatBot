using Chatbot.API.Repository;
using Chatbot.Domain.Models;
using Chatbot.Infrastructure.Dtto;
using Chatbot.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chatbot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensagemController : ControllerBase
    {
        protected readonly IMensagemInterfaceServices _repository;

        public MensagemController(IMensagemInterfaceServices repository)
        {
            _repository = repository;
        }

        [HttpGet("/mensagens")]
        public async Task<IActionResult> PegarTodasMensagens() => Ok(await _repository.GetALl());
        [HttpGet("/mensagens/chat")]
        public async Task<IActionResult> PegarMensagensParaChat(int con, int log) => Ok(await _repository.BuscarMensagensDeUmChat(con, log));
        [HttpPost("/mensagens/Create")]
        public async Task<IActionResult> CriarMensagem(MensagensDttoPost Model) => Ok(await _repository.AdicionarPost(Model));
        [HttpPut("/mensagens/Atualizar")]
        public async Task<IActionResult> AtualizarMensagens(MensagensDttoPut Model) => Ok(await _repository.AtualizarPut(Model));
        [HttpDelete("/mensagens/Delete")]
        public async Task<IActionResult> ApagarMensagens(int id) => Ok(await _repository.Delete(id));
    }
}
