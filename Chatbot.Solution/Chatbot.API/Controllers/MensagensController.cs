using Chatbot.API.Models;
using Chatbot.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chatbot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensagensController : ControllerBase
    {
        private readonly MensagemRepository _mensagemRepository;

        public MensagensController(MensagemRepository mensagemRepository)
        {
            _mensagemRepository = mensagemRepository;
        }

        [HttpGet("/mensagens")]
        public async Task<IActionResult> PegarTodasMensagens() => Ok(await _mensagemRepository.ListaComObjetos());
        [HttpGet("/mensagens/chat")]
        public async Task<IActionResult> PegarMensagensParaChat(int con, int log) => Ok(await _mensagemRepository.RetornarMensagensPorConIdELogId(con, log));
        [HttpPost("/mensagens/Create")]
        public async Task<IActionResult> CriarMensagem(Mensagen Model) => Ok(await _mensagemRepository.Adicionar(Model));
        [HttpPut("/mensagens/Atualizar")]
        public async Task<IActionResult> AtualizarMensagens(Mensagen Model) => Ok(await _mensagemRepository.Update(Model));
        [HttpDelete("/mensagens/Delete")]
        public async Task<IActionResult> ApagarMensagens(int id) => Ok(await _mensagemRepository.Delete(id));

    }
}
