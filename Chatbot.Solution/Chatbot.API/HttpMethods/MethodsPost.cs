using Chatbot.API.Models;
using Chatbot.API.Repository;
//using Chatbot.API.Services;
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
        private readonly MensagemRepository _mensagemRepository;
        private readonly ContatoRepository _contatoRepostiroy;

        public MethodsPost(IConfiguration configuration, MensagemRepository mensagemRepository, ContatoRepository contatoRepostiroy)
        {
            _configuration = configuration;
            HttpClient = new HttpClient();
            _mensagemRepository = mensagemRepository;
            _contatoRepostiroy = contatoRepostiroy;
        }

        public async Task<dynamic> MensagemDeMenu(string waId, string mensagem, string numeroDeEnvio)
        {
            if (waId == "557988132044")
            {
                waId = "5579988132044";
            }

            var dadosJson = "";
            try
            {
                dadosJson = $@"
                {{
                    ""messaging_product"": ""whatsapp"",
                    ""recipient_type"": ""individual"",
                    ""to"": ""{waId}"",
                    ""type"": ""interactive"",
                    ""interactive"": {{
                        ""type"": ""list"",
                        ""header"": {{
                            ""type"": ""text"",
                            ""text"": """"
                        }},
                        ""body"": {{
                            ""text"": ""Selecione o Assunto a se tratar abaixo""
                        }},
                        ""footer"": {{
                            ""text"": """"
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
                }}";

                return await MetodoPostParaAsMensagens(dadosJson);

            }
            catch (Exception)
            {

                throw new Exception();
            }

        }

        public async Task<dynamic> MensagemParaOBotResponder(string waId, string descricaoDaMensagem)
        {

            var MensagensTemplates = await _mensagemRepository.GetAll();

            var dadosJson = "";
            try
            {

                if (descricaoDaMensagem != null && descricaoDaMensagem != "" && descricaoDaMensagem != " ")
                {

                    var ListaMensagem = MensagensTemplates.FirstOrDefault(x => x.MenDescricao == descricaoDaMensagem && x.LogId == 2);

                    if (ListaMensagem != null)
                    {
                        //apenas para testes isso aqui, pois o numero na lista da meta de teste esta com o 9 na frente

                        if (waId == "557988132044")
                        {
                            waId = "5579988132044";
                        }

                        dadosJson = $@"
                        {{
                            ""messaging_product"": ""whatsapp"",
                            ""recipient_type"": ""individual"",
                            ""to"": ""{waId}"",
                            ""type"": ""text"",
                            ""text"": {{
                                ""preview_url"": false,
                                ""body"": ""{ListaMensagem.MenResposta}""
                            }}
                        }}";


                    }
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

            var Nome = Values
           .GetProperty("entry")[0]
           .GetProperty("changes")[0]
           .GetProperty("value")
           .GetProperty("contacts")[0]
           .GetProperty("profile")
           .GetProperty("name")
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

            var dados = await _contatoRepostiroy.GetAll();

            var Item = dados.FirstOrDefault(x => x.ConWaId == waId);

            if (Item == null)
            {
                Contato NovoContato = new Contato
                {
                    ConWaId = waId,
                    ConNome = Nome,
                    ConDataCadastro = DateTime.Now,
                    ConBloqueadoStatus = false,
                    LogId = 2
                };
                await _contatoRepostiroy.Adicionar(NovoContato);
                return MensagemDeMenu(waId, mensagem, numeroDeEnvio);
            }
            //else if (Item == mensagem)
            //{
            //    throw new Exception("Mensagem Repetida");
            //}
            else if (Item.ConBloqueadoStatus == true)
            {
                throw new Exception("Numero Bloqueado");
            }
            else
            {
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

            var dados = await _mensagemRepository.ListaComObjetos();

            var item = dados.LastOrDefault(x => x.Con.ConWaId == waId && x.Log.LogId == 2 && x.MenTipo == "MensagenEnviada");

            if (item != null)
            {

                if (item?.MenDescricao == descricaoDaMensagem)
                {
                    throw new Exception("Mensagem Repetida");
                }
                else
                {
                    Mensagen mensagen = new Mensagen
                    {
                        MenDescricao = descricaoDaMensagem,
                        MenData = DateTime.Now,
                        MenTipo = "MensagenEnviada",
                        LogId = 2,
                        ConId = 1,
                    };
                    await _mensagemRepository.Adicionar(mensagen);
                    return await MensagemParaOBotResponder(waId, descricaoDaMensagem);
                }
            }
            else
            {
                Mensagen mensagen = new Mensagen
                {
                    MenDescricao = descricaoDaMensagem,
                    MenData = DateTime.Now,
                    MenTipo = "MensagenEnviada",
                    LogId = 2,
                    ConId = 1,
                };
                await _mensagemRepository.Adicionar(mensagen);
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