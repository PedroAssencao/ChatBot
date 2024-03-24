using Chatbot.API.Dttos;
using Chatbot.API.HttpMethods;
using Chatbot.API.Models;
using Chatbot.API.Repository;
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
        private readonly MensagemRepository _mensagemRepository;
        private readonly LoginRepository _LoginRepository;
        private readonly ContatoRepository _ContatoRepository;

        public WebHookController(IConfiguration configuration, MethodsPost methods, LoginRepository Login, ContatoRepository Contato, MensagemRepository mensagemRepository)
        {
            _configuration = configuration;
            _methods = methods;
            _LoginRepository = Login;
            _ContatoRepository = Contato;
            _mensagemRepository = mensagemRepository;
        }


        [HttpPost("/hook")]
        public async Task<IActionResult> HandleWebhookAsync(JsonDocument requestBody)
        {
            try
            {
                await _methods.VerificaTipoDeRetorno(requestBody.RootElement);
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
