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
        public async Task<IActionResult> BuscarTodosContato()
        {
            try
            {
                return Ok(await _contatoServices.GetALl());
            }
            catch (Exception ex)
            {
                return BadRequest("error: " + ex.Message);
            }
        }
        [HttpGet("/Contatos/Get/{id}")]
        public async Task<IActionResult> BuscarContatoPorId(int id)
        {
            try
            {
                return Ok(await _contatoServices.GetPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest("error: " + ex.Message);
            }
        }

        [HttpGet("/Contatos/Get/waID/{id}")]
        public async Task<IActionResult> BuscaContatoPorWaId(string id)
        {
            try
            {
                return Ok(await _contatoServices.RetornarConIdPorWaID(id));
            }
            catch (Exception ex)
            {
                return BadRequest("error: " + ex.Message);
            }
        }


        [HttpPost("/Contatos/Create")]
        public async Task<IActionResult> CriarNovoContato(ContatoDttoGet Model)
        {
            try
            {
                return Ok(await _contatoServices.Create(Model));
            }
            catch (Exception ex)
            {
                return BadRequest("error: " + ex.Message);
            }
        }

        [HttpPut("/Contatos/Update")]
        public async Task<IActionResult> AtualizarContato(ContatoDttoGet Model)
        {
            try
            {
                return Ok(await _contatoServices.Update(Model));
            }
            catch (Exception ex)
            {
                return BadRequest("error: " + ex.Message);
            }
        }

        [HttpDelete("/Contatos/Delete")]
        public async Task<IActionResult> ApagarContato(int id)
        {
            try
            {
                return Ok(await _contatoServices.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest("error: " + ex.Message);
            }
        }

    }
}
