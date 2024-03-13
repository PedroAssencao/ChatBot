using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json;

namespace Chatbot.API.HttpMethods
{
    public class MethodsPost
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient HttpClient;

        public MethodsPost(IConfiguration configuration)
        {
            _configuration = configuration;
            HttpClient = new HttpClient();
        }

        public string MensagemDeMenu(dynamic Values) 
        {
            var mensagem = "";
            var numeroDeEnvio = "";
            var dadosJson = "";
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

                numeroDeEnvio = Values
              .GetProperty("entry")[0]
              .GetProperty("changes")[0]
              .GetProperty("value")
              .GetProperty("messages")[0]
              .GetProperty("from")
              .GetString();

            

               if (mensagem != null && mensagem != "" && mensagem != " ")
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

                    /*dadosJson = string.Format(@"{{
                    ""messaging_product"": ""whatsapp"",
                    ""recipient_type"": ""individual"",
                    ""to"": ""{0}"",
                    ""type"": ""interactive"",
                    ""interactive"": {{
                        ""type"": ""list"",
                        ""header"": {{
                            ""type"": ""text"",
                            ""text"": ""Bem Vindo A Margi!""
                        }},
                        ""body"": {{
                            ""text"": ""Selecione o Assunto a se tratar abaixo""
                        }},
                        ""footer"": {{
                            ""text"": ""Obrigado Por Usar O Sistema Margi!""
                        }},
                        ""action"": {{
                            ""button"": ""Menu de Opções"",
                            ""sections"": [
                                {{
                                    ""title"": ""Shorter Section Title"",
                                    ""rows"": [
                                        {{
                                            ""id"": ""unique-row-identifier"",
                                            ""title"": ""Financeiro"",
                                            ""description"": ""Tratar Assuntos Financeiros""
                                        }},
                                        {{
                                            ""id"": ""unique-row-identifier2"",
                                            ""title"": ""Ajuda"",
                                            ""description"": ""Solicitar Ajuda Ao Atendente""
                                        }},
                                        {{
                                            ""id"": ""unique-row-identifier3"",
                                            ""title"": ""2 Via Boleto"",
                                            ""description"": ""Solicitar 2 via para boleto""
                                        }}
                                    ]
                                }}
                            ]
                        }}
                    }}
                }}", numeroDeEnvio);*/
                }
                else
                {
                    throw new Exception();
                }
                return dadosJson;

            }
            catch (Exception)
            {

                throw new Exception();
            }
        
        }

        public string MensagemParaOBotResponder(dynamic Values)
        {
            var descricaoDaMensagem = "";
            var dadosJson = "";
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

                if (descricaoDaMensagem != null && descricaoDaMensagem != "" && descricaoDaMensagem != " ")
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
                return dadosJson;
            }
            catch (Exception)
            {
                throw new Exception("Menssagem Vazia Ou Feita Por Bot");
            }
        }

        public async Task<bool> MetodoPostParaAsMensagens(string dadosJson)
        {
            if (dadosJson != "" || dadosJson != " ")
            {
                var conteudo = new StringContent(dadosJson, Encoding.UTF8, "application/json");

                var resposta = await HttpClient.PostAsync(_configuration.GetSection("security").GetSection("UrlAndAccessToken").Value, conteudo);

                if (resposta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            

        }
    }
}
