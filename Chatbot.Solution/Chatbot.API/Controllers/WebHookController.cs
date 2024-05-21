using Chatbot.Infrastructure.Meta.Repository.Interfaces;
using Chatbot.Infrastructure.Meta.Services;
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
        protected readonly MetaClientServices _services;

        public WebHookController(MetaClientServices services)
        {
            _services = services;
        }

        [HttpPost("/hook")]
        public IActionResult HandleWebhookAsync(JsonDocument requestBody)
        {
            try
            {
                var dados = _services.MAIN(requestBody.RootElement);
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }
        }

        //Usar Esse Codigo Na Validação para Não dar error
        //[HttpGet("/hook")]
        //public IActionResult HandleWebhook([FromQuery(Name = "hub.challenge")] string hubChallenge) => Ok(hubChallenge);
    }
}
