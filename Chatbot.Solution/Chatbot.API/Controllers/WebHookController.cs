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
        private readonly CadastroRepository _cadastrorepository;

        public WebHookController(IConfiguration configuration, MethodsPost methods, CadastroRepository cadastrorepository)
        {
            _configuration = configuration;
            _methods = methods;
            _cadastrorepository = cadastrorepository;
        }


        [HttpPost("/hook")]
        public async Task<IActionResult> HandleWebhookAsync(JsonDocument requestBody)
        {
            Thread.Sleep(4000);

            string dadosJson = "";

            try
            {
                dadosJson = await _methods.MensagemDeMenu(requestBody.RootElement);
            }
            catch (Exception)
            {
                dadosJson = _methods.MensagemParaOBotResponder(requestBody.RootElement);
            }

            var resposta = await _methods.MetodoPostParaAsMensagens(dadosJson);

            return resposta ? Ok() : BadRequest();
        }

        //[HttpGet]
        //[Route("getcategoriasTeste")]
        //public async Task<IActionResult> PegarTodosCadastros() => Ok(await _cadastrorepository.GetAll());     

        //[HttpPost]
        //[Route("PostCadastro")]
        //public async Task<IActionResult> Criatecadastro(Cadastro Model) => Ok(await _cadastrorepository.Adicionar(Model));     

        //[HttpPut]
        //[Route("UpdateCadastro")]
        //public async Task<IActionResult> updateCadastro(Cadastro Model) => Ok(await _cadastrorepository.Update(Model));     


        //Usar Esse Codigo Na Validação para Não dar error
        //[HttpGet("/hook")]
        //public IActionResult HandleWebhook([FromQuery(Name = "hub.challenge")] string hubChallenge)
        //{
        //    return Ok(hubChallenge);
        //}
    }
}
