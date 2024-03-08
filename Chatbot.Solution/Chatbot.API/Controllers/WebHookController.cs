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

        public WebHookController(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost("/hook")]
        public async Task<IActionResult> HandleWebhookAsync(JsonDocument requestBody)
        {
            var httpClient = new HttpClient();
            try
            {
                var Values = requestBody.RootElement;
                var mensagem = Values
    .GetProperty("entry")[0]
    .GetProperty("changes")[0]
    .GetProperty("value")
    .GetProperty("messages")[0]
    .GetProperty("text")
    .GetProperty("body")
    .GetString();

                if (mensagem != null || mensagem != "" || mensagem != " ")
                {

                    string accessToken = _configuration.GetSection("security").GetSection("AccessToken").Value;

                    // URL para fazer um post em uma timeline
                    string url = $"https://graph.facebook.com/v18.0/194454180428439/messages?access_token={accessToken}";

                    // Dados que você deseja postar
                    string dadosJson = @"
                        {
                            ""messaging_product"": ""whatsapp"",
                            ""recipient_type"": ""individual"",
                            ""to"": ""5579988132044"",
                            ""type"": ""template"",
                            ""template"": {
                                ""name"": ""boas_vindas_5"",
                                ""language"": {
                                    ""code"": ""pt_BR""
                                },
                                ""components"": [
                                    {
                                        ""type"": ""body"",
                                        ""parameters"": [
                                            {
                                                ""type"": ""text"",
                                                ""text"": ""Pedro""
                                            },
                                            {
                                                ""type"": ""text"",
                                                ""text"": ""Teclado""
                                            }
                                        ]
                                    },
                                    {
                                        ""type"": ""header"",
                                        ""parameters"": [
                                            {
                                                ""type"": ""text"",
                                                ""text"": ""Margi""
                                            }
                                        ]
                                    }
                                ]
                            }
                        }";



                    // Serializa os dados para formato JSON
                    var conteudo = new StringContent(dadosJson, Encoding.UTF8, "application/json");

                    // Envia a requisição POST
                    var resposta = await httpClient.PostAsync(url, conteudo);


                    return Ok();
                }
                else
                {
                    return BadRequest("Mensagem Vazia");
                }


            }
            catch (Exception ex)
            {
                throw new Exception();
                //return BadRequest(ex);
            }



        }


        //Usar Esse Codigo Na Validação para Não dar error
        /*[HttpGet("/hook")]
        public IActionResult HandleWebhook([FromQuery(Name = "hub.challenge")] string hubChallenge)
        {
            return Ok(hubChallenge);
        }*/
    }
}
