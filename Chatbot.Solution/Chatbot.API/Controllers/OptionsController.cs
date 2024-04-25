using Chatbot.API.Models;
using Chatbot.API.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chatbot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        protected readonly optionsRepository _optionsRepository;

        public OptionsController(optionsRepository optionsRepository)
        {
            _optionsRepository = optionsRepository;
        }

        [HttpGet("/options")]
        [EnableCors("AllowSpecificOrigin")]
        public async Task<IActionResult> PegarTodasOptions() => Ok(await _optionsRepository.RetonarOptionComMenu());

        [HttpGet("/options/{log}")]
        public async Task<IActionResult> PegarTodasAsOptionsPorLogId(int log) => Ok(await _optionsRepository.RetornarTodasASOptionPorLOgId(log));
        [HttpPost("/options/Create")]
        [EnableCors("AllowSpecificOrigin")]
        public async Task<IActionResult> CriarNovasOpcoes(Option Model) => Ok(await _optionsRepository.Adicionar(Model));

        //[HttpPost("/options/CreateM")]
        //[EnableCors("AllowSpecificOrigin")]
        //public async Task<IActionResult> CriarNovasOpcoesComMensagem(Mensagen mensagen, Option Model) => Ok(await _optionsRepository.CriarOptionsPassandoMensagem(mensagen, Model));
        [HttpPut("/option/Update")]
        public async Task<IActionResult> AtualizarOpcoes(Option Model) => Ok(await _optionsRepository.Update(Model));
        [HttpDelete("/options/Delete")]
        public async Task<IActionResult> ApagarOption(int id) => Ok(await _optionsRepository.Delete(id));


    }
}
