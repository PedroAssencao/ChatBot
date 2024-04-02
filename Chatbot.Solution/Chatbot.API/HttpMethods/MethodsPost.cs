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
        private readonly AtendimentoRepository _atendimentoRepository;
        private readonly LoginRepository _loginRepostiory;
        private readonly optionsRepository _optionsRepository;
        private readonly menuRepository _menuRepository;

        public MethodsPost(IConfiguration configuration, MensagemRepository mensagemRepository, ContatoRepository contatoRepostiroy, AtendimentoRepository atendimentoRepository, LoginRepository login, optionsRepository optionsRepository, menuRepository menu)
        {
            _configuration = configuration;
            HttpClient = new HttpClient();
            _mensagemRepository = mensagemRepository;
            _contatoRepostiroy = contatoRepostiroy;
            _atendimentoRepository = atendimentoRepository;
            _loginRepostiory = login;
            _optionsRepository = optionsRepository;
            _menuRepository = menu;
        }

        public async Task<dynamic> MensagemDeMenu(string waId, string mensagem, string LoginWaId, dynamic Values)
        {

            try
            {
                var contato = await _contatoRepostiroy.RetornarConIdPorWaID(waId);

                var login = await _loginRepostiory.RetornarLogIdPorWaID(LoginWaId);

                var dadosAtendimento = await _atendimentoRepository.AtendimentoComObjetos();

                var Item = dadosAtendimento.FirstOrDefault(x => x?.Con?.ConWaId == waId && x?.Log?.LogId == login?.LogId);

                if (Item == null)
                {
                    Atendimento NovoAtendimento = new Atendimento
                    {
                        AtenEstado = "Bot",
                        AtenData = DateTime.Now,
                        LogId = login?.LogId,
                        ConId = contato?.ConId,
                    };

                    await _atendimentoRepository.Adicionar(NovoAtendimento);
                }
                else if (Item.AtenEstado == "Bot")
                {
                    return await MensagemParaOBotResponder(waId, mensagem, LoginWaId);
                }
                else if (Item.AtenEstado == "Finalizado")
                {
                    Item.AtenEstado = "Bot";
                    Item.AtenData = DateTime.Now;
                    Item.DepId = null;
                    Item.AteId = null;
                    Item.ConId = Item.ConId;
                    Item.LogId = Item.LogId;
                    await _atendimentoRepository.Update(Item);
                }


                var dadosOption = await _optionsRepository.RetonarOptionComMenu();

                var dadosMenu = await _menuRepository.GetAll();

                var selecionarOptions = dadosOption.Where(x => x.Log?.LogWaid == LoginWaId && x.Men?.MenTipo == "PrimeiraMensagem").ToList();

                var menuselecionado = dadosMenu.FirstOrDefault(x => x.MenId == selecionarOptions[0].Men?.MenId);

                List<string> teste = new List<string>();

                foreach (var item in selecionarOptions)
                {
                    string ItemSelecionado = $@"
                    {{
                        ""id"": ""{item.OptId}"",
                        ""title"": ""{item.Mens?.MenTitle}"",
                        ""description"": ""{item.Mens?.MenDescricao}""
                    }}";

                    teste.Add(ItemSelecionado);
                }

                if (waId == "557988132044")
                {
                    waId = "5579988132044";
                }

                var dadosJson = "";

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
                            ""text"": ""{menuselecionado?.MenHeader}""
                        }},
                        ""body"": {{
                            ""text"": ""{menuselecionado?.MenBody}""
                        }},
                        ""footer"": {{
                            ""text"": ""{menuselecionado?.MenFooter}""
                        }},
                        ""action"": {{
                            ""button"": ""Menu de Opções"",
                            ""sections"": [
                                {{
                                    ""title"": ""Shorter Section Title"",
                                    ""rows"": [
                                        {string.Join(",", teste)}
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

        public async Task<dynamic> MensagemParaOBotResponder(string waId, string descricaoDaMensagem, string LoginWaId)
        {

            var MensagensTemplates = await _mensagemRepository.GetAll();
            var LoginId = await _loginRepostiory.RetornarLogIdPorWaID(LoginWaId);

            var dadosJson = "";
            try
            {

                if (descricaoDaMensagem != null && descricaoDaMensagem != "" && descricaoDaMensagem != " ")
                {

                    var ListaMensagem = MensagensTemplates.FirstOrDefault(x => x.MenDescricao == descricaoDaMensagem && x.LogId == LoginId?.LogId && x.MenTipo == "MensagemDeResposta");

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
                    else
                    {

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
                                ""body"": ""Porfavor Escolha Uma Das Opções Acima""
                            }}
                        }}";

                    }
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
            if (dadosJson != "")
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


            var LoginWaId = Values
          .GetProperty("entry")[0]
          .GetProperty("changes")[0]
          .GetProperty("value")
          .GetProperty("metadata")
          .GetProperty("display_phone_number")
          .GetString();

            if (mensagem == null)
            {
                throw new Exception();
            }




            var dados = await _contatoRepostiroy.GetAll();

            var LoginWaIdDados = await _loginRepostiory.RetornarLogIdPorWaID(LoginWaId);

            var dadosMensagen = await _mensagemRepository.ListaComObjetos();

            var itemMensagen = dadosMensagen.LastOrDefault(x => x?.Con?.ConWaId == waId && x?.Log?.LogId == LoginWaIdDados.LogId && x?.MenTipo == "MensagenEnviada");

            var Item = dados.FirstOrDefault(x => x.ConWaId == waId);

            if (Item == null)
            {
                Contato NovoContato = new Contato
                {
                    ConWaId = waId,
                    ConNome = Nome,
                    ConDataCadastro = DateTime.Now,
                    ConBloqueadoStatus = false,
                    LogId = 1
                };
                await _contatoRepostiroy.Adicionar(NovoContato);
                return MensagemDeMenu(waId, mensagem, LoginWaId, Values);
            }
            else if (itemMensagen?.MenDescricao == mensagem)
            {
                throw new Exception("Mensagem Repetida");
            }
            else if (Item.ConBloqueadoStatus == true)
            {
                throw new Exception("Numero Bloqueado");
            }
            else
            {
                Mensagen mensagen = new Mensagen
                {
                    MenDescricao = mensagem,
                    MenData = DateTime.Now,
                    MenTipo = "MensagenEnviada",
                    LogId = 1,
                    ConId = 1,
                };
                await _mensagemRepository.Adicionar(mensagen);
                return await MensagemDeMenu(waId, mensagem, LoginWaId, Values);
            }

        }

        public async Task<dynamic> TipoMensagemBot(dynamic Values)
        {

            var descricaoDaMensagem = "";

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
            }
            catch (Exception)
            {
                descricaoDaMensagem = Values
             .GetProperty("entry")[0]
             .GetProperty("changes")[0]
             .GetProperty("value")
             .GetProperty("messages")[0]
             .GetProperty("text")
             .GetProperty("body").GetString();
            }


            var waId = "";

            try
            {
             waId = Values
           .GetProperty("entry")[0]
           .GetProperty("changes")[0]
           .GetProperty("value")
           .GetProperty("contacts")[0]
           .GetProperty("wa_id")
           .GetString();
            }
            catch (Exception)
            {
                waId = Values
           .GetProperty("entry")[0]
           .GetProperty("changes")[0]
           .GetProperty("value")
           .GetProperty("contacts")[0]
           .GetProperty("wa_id")
           .GetString();
            }

            var LoginWaId = "";

            try
            {
                LoginWaId = Values
                 .GetProperty("entry")[0]
                 .GetProperty("changes")[0]
                 .GetProperty("value")
                 .GetProperty("metadata")
                 .GetProperty("display_phone_number")
                 .GetString();
            }
            catch (Exception)
            {
                LoginWaId = Values
                  .GetProperty("entry")[0]
                  .GetProperty("changes")[0]
                  .GetProperty("value")
                  .GetProperty("metadata")
                  .GetProperty("display_phone_number")
                  .GetString();
            }   

            if (descricaoDaMensagem == null)
            {
                throw new Exception();
            }

            var dados = await _mensagemRepository.ListaComObjetos();

            var LoginWaIdDados = await _loginRepostiory.RetornarLogIdPorWaID(LoginWaId);

            var item = dados.LastOrDefault(x => x.Con?.ConWaId == waId && x.Log?.LogId == LoginWaIdDados?.LogId && x.MenTipo == "MensagenEnviada");

            if (item != null)
            {

                //if (item?.MenDescricao == descricaoDaMensagem)
                if (false)
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
                        LogId = 1,
                        ConId = 1,
                    };
                    await _mensagemRepository.Adicionar(mensagen);
                    return await MensagemParaOBotResponder(waId, descricaoDaMensagem, LoginWaId);
                }
            }
            else
            {
                Mensagen mensagen = new Mensagen
                {
                    MenDescricao = descricaoDaMensagem,
                    MenData = DateTime.Now,
                    MenTipo = "MensagenEnviada",
                    LogId = 1,
                    ConId = 1,
                };
                await _mensagemRepository.Adicionar(mensagen);
                return await MensagemParaOBotResponder(waId, descricaoDaMensagem, LoginWaId);
            }
        }

        public async Task<dynamic?> TipoMensagemStatus(dynamic Values)
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