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
            var Values = requestBody.RootElement;
            var mensagem = "";
            var descricaoDaMensagem = "";
            string accessToken = _configuration.GetSection("security").GetSection("AccessToken").Value;
            string dadosJson = "";
            string url = $"https://graph.facebook.com/v18.0/194454180428439/messages?access_token={accessToken}";

            try
            {
                mensagem = Values
               .GetProperty("entry")[0]
               .GetProperty("changes")[0]
               .GetProperty("value")
               .GetProperty("messages")[0]
               .GetProperty("text")
               .GetProperty("body")
               .GetString();
                if (mensagem != null || mensagem != "" || mensagem != " ")
                {
                    dadosJson = @"{
                                      ""messaging_product"": ""whatsapp"",
                                      ""recipient_type"": ""individual"",
                                      ""to"": ""5579988132044"",
                                      ""type"": ""interactive"",
                                      ""interactive"": {
                                        ""type"": ""list"",
                                        ""header"": {
                                          ""type"": ""text"",
                                          ""text"": ""Bem Vindo A Margi!""
                                        },
                                        ""body"": {
                                          ""text"": ""Selecione o Assunto a se tratar abaixo""
                                        },
                                        ""footer"": {
                                          ""text"": ""Obrigado Por Usar O Sistema Margi!""
                                        },
                                        ""action"": {
                                          ""button"": ""Menu de Opções"",
                                          ""sections"": [
                                            {  ""title"": ""Shorter Section Title""  ,
                                              ""rows"": [
                                                {
                                                  ""id"": ""unique-row-identifier"",
                                                  ""title"": ""Financeiro"",
                                                  ""description"": ""Tratar Assuntos Financeiros""
                                                },{
                                                  ""id"": ""unique-row-identifier2"",
                                                  ""title"": ""Ajuda"",
                                                  ""description"": ""Solicitar Ajuda Ao Atendente""
                                                },{
                                                  ""id"": ""unique-row-identifier3"",
                                                  ""title"": ""2 Via Boleto"",
                                                  ""description"": ""Solicitar 2 via para boleto""
                                                }
                                              ]
                                            }
                                          ]
                                        }
                                      }
                                    }";
                }
                else
                {
                    throw new Exception();
                }
              
            }
            catch (Exception)
            {
                try
                {
                    descricaoDaMensagem = Values
                   .GetProperty("entry")[0]
                   .GetProperty("changes")[0]
                   .GetProperty("value")
                   .GetProperty("messages")[0]
                   .GetProperty("interactive")
                   .GetProperty("list_reply")
                   .GetProperty("description")
                   .GetString();

                    if (descricaoDaMensagem != null || descricaoDaMensagem != "" || descricaoDaMensagem != " ")
                    {
                        if (descricaoDaMensagem == "Solicitar 2 via para boleto")
                        {
                            dadosJson = @"{
                          ""messaging_product"": ""whatsapp"",
                          ""recipient_type"": ""individual"",
                          ""to"": ""5579988132044"",
                          ""type"": ""text"",
                          ""text"": {
                            ""preview_url"": false,
                            ""body"": ""Mensagem Referente A Solicitar 2 via para boleto para Teste""
                            }
                    }
                    ";
                        }
                        if (descricaoDaMensagem == "Solicitar Ajuda Ao Atendente")
                        {
                            dadosJson = @"{
                          ""messaging_product"": ""whatsapp"",
                          ""recipient_type"": ""individual"",
                          ""to"": ""5579988132044"",
                          ""type"": ""text"",
                          ""text"": {
                            ""preview_url"": false,
                            ""body"": ""Mensagem Referente A Solicitar Ajuda Ao Atendente para Teste""
                            }
                    }
                    ";
                        }
                        if (descricaoDaMensagem == "Tratar Assuntos Financeiros")
                        {
                            dadosJson = @"{
                          ""messaging_product"": ""whatsapp"",
                          ""recipient_type"": ""individual"",
                          ""to"": ""5579988132044"",
                          ""type"": ""text"",
                          ""text"": {
                            ""preview_url"": false,
                            ""body"": ""Mensagem Referente A Assuntos Financeiros para Teste""
                            }
                    }
                    ";
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                   
                }
                catch (Exception)
                {
                    throw new Exception("Menssagem Vazia Ou Feita Por Bot");
                }
            }

            var conteudo = new StringContent(dadosJson, Encoding.UTF8, "application/json");

            var resposta = await httpClient.PostAsync(url, conteudo);

            if (resposta.IsSuccessStatusCode)
            {
                return Ok("Mensagem Enviada com suscesso");
            }
            else
            {
                return BadRequest("Mensagem Vazia");
            }

        }


        //Usar Esse Codigo Na Validação para Não dar error
        //[HttpGet("/hook")]
        //public IActionResult HandleWebhook([FromQuery(Name = "hub.challenge")] string hubChallenge)
        //{
        //    return Ok(hubChallenge);
        //}
    }
}
