using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chatbot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        [HttpGet]
        [Route("/teste")]
        public int testre() 
        {

            return 1 + 2;
        
        }

        [HttpPost("/hook")]
        public async Task<IActionResult> HandleWebhookAsync([FromBody] dynamic requestBody)
        {
           
            return Ok(); 
        }

        //Usar Esse Codigo Na Validação para Não dar error
        //[HttpGet("/hook")]
        //public IActionResult HandleWebhook([FromQuery(Name = "hub.challenge")] string hubChallenge)
        //{
        //    return Ok(hubChallenge);
        //}
    }
}
