using Chatbot.Infrastructure.Dtto;
using Chatbot.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chatbot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        protected readonly IOptionInterfaceServices _repository;

        public OptionController(IOptionInterfaceServices repository)
        {
            _repository = repository;
        }

        [HttpGet("/Option")]
        public async Task<IActionResult> BuscarTodasOption()
        {
            try
            {
                return Ok(await _repository.GetALl());
            }
            catch (Exception ex)
            {
                return BadRequest("error: " + ex.Message);
            }
        }

        [HttpGet("/Option/{id}")]
        public async Task<IActionResult> BuscarOptionPorId(int id)
        {
            try
            {
                return Ok(await _repository.GetPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest("error: " + ex.Message);
            }
        }

        [HttpPost("/Option/Create")]
        public async Task<IActionResult> AdicionarOption(OptionDttoPost Model)
        {
            try
            {
                return Ok(await _repository.AdicionarPost(Model));
            }
            catch (Exception ex)
            {
                return BadRequest("error: " + ex.Message);
            }
        }

        [HttpPut("/Option/Update")]
        public async Task<IActionResult> AtualizarOption(OptionDttoPut Model)
        {
            try
            {
                return Ok(await _repository.AtualizarPost(Model));
            }
            catch (Exception ex)
            {
                return BadRequest("error: " + ex.Message);
            }
        }

        [HttpDelete("/Option/Delete")]
        public async Task<IActionResult> ApagarOption(int id)
        {
            try
            {
                return Ok(await _repository.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest("error: " + ex.Message);
            }
        }

    }
}
