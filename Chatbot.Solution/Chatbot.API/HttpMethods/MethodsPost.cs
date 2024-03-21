using Chatbot.API.Models;
using Chatbot.API.Repository;
using Chatbot.API.Services;
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
        private readonly CadastroServies _cadastroRepository;
        private readonly BotRespostaServices _botrespostarepository;

        public MethodsPost(IConfiguration configuration, CadastroServies cadastroRepository, BotRespostaServices botrespostarepository)
        {
            _configuration = configuration;
            HttpClient = new HttpClient();
            _cadastroRepository = cadastroRepository;
            _botrespostarepository = botrespostarepository;
        }

        public async Task<string> MensagemDeMenu(string waId, string mensagem, string numeroDeEnvio)
        {
            var dadosJson = "";
            try
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
                return await MetodoPostParaAsMensagens(dadosJson);

            }
            catch (Exception)
            {

                throw new Exception();
            }

        }

        public async Task<dynamic> MensagemParaOBotResponder(string waId, string descricaoDaMensagem)
        {
            List<menu> teste = new List<menu>();


            menu menu1 = new menu
            {
                menu_id = 1,
                menu_descricao = "Mensagem Referente A Assuntos Financeiros para Teste",
                menu_title = "Tratar Assuntos Financeiros"

            };

            menu menu2 = new menu
            {
                menu_id = 2,
                menu_descricao = "Mensagem Referente A Solicitar Ajuda Ao Atendente para Teste",
                menu_title = "Solicitar Ajuda Ao Atendente"

            };

            menu menu3 = new menu
            {
                menu_id = 3,
                menu_descricao = "Mensagem Referente A Solicitar 2 via para boleto para Teste",
                menu_title = "Solicitar 2 via para boleto"

            };

            teste.Add(menu1);
            teste.Add(menu2);
            teste.Add(menu3);

            var dadosJson = "";
            try
            {

                if (descricaoDaMensagem != null && descricaoDaMensagem != "" && descricaoDaMensagem != " ")
                {

                    var a = teste.FirstOrDefault(x => x.menu_title == descricaoDaMensagem);

                    if (a != null)
                    {
                        dadosJson = $@"
                        {{
                            ""messaging_product"": ""whatsapp"",
                            ""recipient_type"": ""individual"",
                            ""to"": ""5579988132044"",
                            ""type"": ""text"",
                            ""text"": {{
                                ""preview_url"": false,
                                ""body"": ""{a?.menu_descricao}""
                            }}
                        }}";


                    }
                    //if (descricaoDaMensagem == "Solicitar Ajuda Ao Atendente")
                    //{
                    //    dadosJson = @"{
                    //      ""messaging_product"": ""whatsapp"",
                    //      ""recipient_type"": ""individual"",
                    //      ""to"": ""5579988132044"",
                    //      ""type"": ""text"",
                    //      ""text"": {
                    //        ""preview_url"": false,
                    //        ""body"": ""Mensagem Referente A Solicitar Ajuda Ao Atendente para Teste""
                    //        }
                    //}
                    //";
                    //}
                    //if (descricaoDaMensagem == "Tratar Assuntos Financeiros")
                    //{
                    //    dadosJson = @"{
                    //      ""messaging_product"": ""whatsapp"",
                    //      ""recipient_type"": ""individual"",
                    //      ""to"": ""5579988132044"",
                    //      ""type"": ""text"",
                    //      ""text"": {
                    //        ""preview_url"": false,
                    //        ""body"": ""Mensagem Referente A Assuntos Financeiros para Teste""
                    //        }
                    //}
                    //";
                    //}

                }
                else
                {
                    dadosJson = @"{
                          ""messaging_product"": ""whatsapp"",
                          ""recipient_type"": ""individual"",
                          ""to"": ""5579988132044"",
                          ""type"": ""text"",
                          ""text"": {
                            ""preview_url"": false,
                            ""body"": ""Porfavor Escolha Uma Das Opções Acima""
                            }
                    }
                    ";
                }
                return await MetodoPostParaAsMensagens(dadosJson);
            }
            catch (Exception)
            {
                throw new Exception("Menssagem Vazia Ou Feita Por Bot");
            }
        }

        public async Task<dynamic> MetodoPostParaAsMensagens(string dadosJson)
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

        public async Task<dynamic> VerificaTipoDeRetorno(dynamic Values)
        {

            try
            {
                return await TipoMensagem(Values);
            }
            catch (Exception)
            {

                try
                {
                    return await TipoMensagemBot(Values);
                }
                catch (Exception)
                {
                    try
                    {
                        return await TipoMensagemStatus(Values);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Metodo Não Identificado");
                    }
                }

            }
        }

        public async Task<dynamic> TipoMensagem(dynamic Values)
        {
            var mensagem = Values
             .GetProperty("entry")[0]
             .GetProperty("changes")[0]
             .GetProperty("value")
             .GetProperty("messages")[0]
             .GetProperty("text")
             .GetProperty("body").GetString();


            var numeroDeEnvio = Values
           .GetProperty("entry")[0]
           .GetProperty("changes")[0]
           .GetProperty("value")
           .GetProperty("messages")[0]
           .GetProperty("from")
           .GetString();

            var waId = Values
           .GetProperty("entry")[0]
           .GetProperty("changes")[0]
           .GetProperty("value")
           .GetProperty("contacts")[0]
           .GetProperty("wa_id")
           .GetString();


            if (mensagem == null)
            {
                throw new Exception();
            }

            var dados = await _cadastroRepository.GetAll();

            var Item = dados.FirstOrDefault(x => x.CatWaId == waId);

            if (Item == null)
            {
                Cadastro NovoCadastro = new Cadastro
                {
                    CatTimeStamp = mensagem,
                    CatWaId = waId,
                };
                await _cadastroRepository.Adicionar(NovoCadastro);
                return MensagemDeMenu(waId, mensagem, numeroDeEnvio);
            }
            else if (Item.CatTimeStamp == mensagem)
            {
                throw new Exception("Mensagem Repetida");
            }
            else
            {
                Item.CatTimeStamp = mensagem;
                Item.CatWaId = waId;
                await _cadastroRepository.Update(Item);
                return await MensagemDeMenu(waId, mensagem, numeroDeEnvio);
            }

        }

        public async Task<dynamic> TipoMensagemBot(dynamic Values)
        {

            var descricaoDaMensagem = Values
            .GetProperty("entry")[0]
            .GetProperty("changes")[0]
            .GetProperty("value")
            .GetProperty("messages")[0]
            .GetProperty("interactive")
            .GetProperty("list_reply")
            .GetProperty("description")
            .GetString();

            var waId = Values
             .GetProperty("entry")[0]
             .GetProperty("changes")[0]
             .GetProperty("value")
             .GetProperty("contacts")[0]
             .GetProperty("wa_id")
             .GetString();

            if (descricaoDaMensagem == null)
            {
                throw new Exception();
            }

            var dados = await _botrespostarepository.GetAll();

            var item = dados.FirstOrDefault(x => x.CatWaId == waId);

            if (item != null)
            {

                if (item?.BotTimeStamp == descricaoDaMensagem)
                {
                    throw new Exception("Mensagem Repetida");
                }
                else
                {
                    item.BotTimeStamp = descricaoDaMensagem;
                    item.CatWaId = waId;
                    await _botrespostarepository.AtualizarBoTrespostum(item);
                    return await MensagemParaOBotResponder(waId, descricaoDaMensagem);
                }
            }
            else
            {
                BoTrespostum boTrespostum = new BoTrespostum
                {
                    BotTimeStamp = descricaoDaMensagem,
                    CatWaId = waId,
                };
                await _botrespostarepository.AdicionarBotResposta(boTrespostum);
                return await MensagemParaOBotResponder(waId, descricaoDaMensagem);
            }
        }

        public async Task<dynamic> TipoMensagemStatus(dynamic Values)
        {
            var sent = Values
                       .GetProperty("entry")[0]
                       .GetProperty("changes")[0]
                       .GetProperty("value")
                       .GetProperty("statuses")[0]
                       .GetProperty("status")
                       .GetString();

            if (sent == null)
            {
                throw new Exception();
            }
            return false;
        }
    }
}