using Chatbot.Infrastructure.Meta.Repository.Interfaces;
using Chatbot.Services.Meta.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Chatbot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebHookController : ControllerBase
    {
        protected readonly MetodoCheckServices _services;

        public WebHookController(MetodoCheckServices services)
        {
            _services = services;
        }

        [HttpPost("/hook")]
        public IActionResult HandleWebhookAsync(JsonDocument requestBody)
        {
            try
            {
                var dados = _services.ababa(requestBody.RootElement);
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }
        }

        //Usar Esse Codigo Na Validação para Não dar error
        [HttpGet("/hook")]
        public IActionResult HandleWebhook([FromQuery(Name = "hub.challenge")] string hubChallenge) => Ok(hubChallenge);
    }
}
