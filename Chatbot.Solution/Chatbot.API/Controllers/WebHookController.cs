using Chatbot.Infrastructure.Meta.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Chatbot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebHookController : ControllerBase
    {
        protected readonly IMetaClientServices _services;

        public WebHookController(IMetaClientServices services)
        {
            _services = services;
        }

        [HttpPost("hook")]
        public async Task<IActionResult> HandleWebhookAsync(JsonDocument requestBody)
        {
            try
            {
                var dados = await _services.MAIN(requestBody.RootElement);
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }
        }

        [HttpGet("hook")]
        public IActionResult HandleWebhook([FromQuery(Name = "hub.challenge")] string hubChallenge) => Ok(hubChallenge);

        [HttpPost("EnviarMensagenAtendente")]
        public async Task<IActionResult> testeAtendenteEnviarMensagenChat(string descricao, int chat, int ate)
        {
            try
            {
                await _services.SalvarMensagemAtendente(descricao, chat, ate);
                return Ok("Mensagen Enviada");    
            }
            catch (Exception)
            {
                return BadRequest("Mensagen Não foi enviada");
            }
        }

    }
}
