using Chatbot.API.HttpMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Chatbot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebHookController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly MethodsPost _methods;

        public WebHookController(IConfiguration configuration, MethodsPost methods)
        {
            _configuration = configuration;
            _methods = methods;
        }


        [HttpPost("/hook")]
        public async Task<IActionResult> HandleWebhookAsync(JsonDocument requestBody)
        {
            string dadosJson = "";

            try
            {
                dadosJson = _methods.MensagemDeMenu(requestBody.RootElement);
            }
            catch (Exception)
            {
               dadosJson = _methods.MensagemParaOBotResponder(requestBody.RootElement);
            }

            var resposta = await _methods.MetodoPostParaAsMensagens(dadosJson);

            return resposta ? Ok() : BadRequest();
        }


        //Usar Esse Codigo Na Validação para Não dar error
        //[HttpGet("/hook")]
        //public IActionResult HandleWebhook([FromQuery(Name = "hub.challenge")] string hubChallenge)
        //{
        //    return Ok(hubChallenge);
        //}
    }
}
