using Chatbot.Infrastructure.Dtto;
using Chatbot.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chatbot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamanetoController : ControllerBase
    {
        protected readonly IDepartamentoInterfaceServices _repository;

        public DepartamanetoController(IDepartamentoInterfaceServices repository)
        {
            _repository = repository;
        }

        [HttpGet("/Departamento")]
        public async Task<IActionResult> BuscarTodos()
        {
            try
            {
                return Ok(await _repository.GetALl());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/Departamento/{id}")]
        public async Task<IActionResult> BuscarDepartamnetoPorId(int id)
        {
            try
            {
                return Ok(await _repository.GetPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/Departamento/Create")]
        public async Task<IActionResult> AdicionarDepartamento(DepartamentoDttoGet Model)
        {
            try
            {
                return Ok(await _repository.Create(Model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/Departamento/Update")]
        public async Task<IActionResult> AtualizarDepartamento(DepartamentoDttoGet Model)
        {
            try
            {
                return Ok(await _repository.Update(Model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/Departamento/Delete")]
        public async Task<IActionResult> ApagarDepartamento(int id)
        {
            try
            {
                return Ok(await _repository.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
