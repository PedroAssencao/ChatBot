﻿using Chatbot.API.Models;
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

        public async Task<dynamic> MensagemDeMenu(string waId, string mensagem, string LoginWaId)
        {

            try
            {

                //Dar Uma olhada nessa options para ver se vai dar tudo certo com a nova logica

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
                if (Item?.AtenEstado == "Bot")
                {
                    return await MensagemParaOBotResponder(waId, mensagem, LoginWaId);
                }
                if (Item?.AtenEstado == "Finalizado")
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

                var menuselecionado = dadosMenu.FirstOrDefault(x => x.MenTipo == "PrimeiraMensagem" && x?.LogId == login?.LogId);

                var selecionarOptions = dadosOption.Where(x => x?.MenId == menuselecionado?.MenId).ToList();

                //var selecionarOptions = dadosOption.Where(x => x.Log?.LogWaid == LoginWaId && x.Men?.MenTipo == "PrimeiraMensagem").ToList();

                //var menuselecionado = dadosMenu.FirstOrDefault(x => x.MenId == selecionarOptions[0].Men?.MenId);

                List<string> teste = new List<string>();

                foreach (var item in selecionarOptions)
                {
                    string ItemSelecionado = $@"
                    {{
                        ""id"": ""{item.OptId}"",
                        ""title"": ""{item.OptTitle}"",
                        ""description"": ""{item.OptDescricao}""
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
            var Login = await _loginRepostiory.RetornarLogIdPorWaID(LoginWaId);
            var TodasAsOptions = await _optionsRepository.RetornarTodasASOptionPorLOgId(Convert.ToInt32(Login?.LogId));
            var dadosAtendimento = await _atendimentoRepository.BuscarTodosAtendimentosPorLogId(Convert.ToInt32(Login?.LogId));
            var dadosJson = "";
            try
            {
                

                if (descricaoDaMensagem != null && descricaoDaMensagem != "" && descricaoDaMensagem != " ")
                {
                    //nunca deixar a optDescricao Ser Igual a Outra ou arrumar alguma outra forma de selecionar a option correta
                    var Option = TodasAsOptions.FirstOrDefault(x => x.OptDescricao == descricaoDaMensagem);
                    if (Option != null)
                    {
                        if (Option.OptFinalizar == true)
                        {
                            var Atendimento = dadosAtendimento.FirstOrDefault(x => x?.Con?.ConWaId == waId && x.Log?.LogId == Convert.ToInt32(Login?.LogId));

                            if (Atendimento != null)
                            {
                                Atendimento.AtenEstado = "Finalizado";
                                Atendimento.AtenData = DateTime.Now;
                                Atendimento.DepId = null;
                                Atendimento.AteId = null;
                                await _atendimentoRepository.Update(Atendimento);
                            }
                            else
                            {
                                throw new Exception("Não foi possivel finalizar o atendimento");
                            }

                        }

                        if (Option?.OptTipo?.Trim()?.ToLower() == "mensagemderespostainterativa")
                        {
                            //lembrar que o optResposta esta guardando o Id do Menu Nesse Caso
                            var selecionarOptions = TodasAsOptions.Where(x => x.Log?.LogWaid == LoginWaId && x.Men?.MenTipo == "MenuBot").ToList()
                            .Where(x => x?.Men?.MenId == Convert.ToInt32(Option.OptResposta)).ToList();

                            var SelecionarMenu = await _menuRepository.GetPorID(Convert.ToInt32(selecionarOptions[0].MenId));

                            List<string> teste = new List<string>();

                            foreach (var item in selecionarOptions)
                            {
                                string ItemSelecionado = $@"
                                {{
                                    ""id"": ""{item.OptId}"",
                                    ""title"": ""{item.OptTitle}"",
                                    ""description"": ""{item.OptDescricao}""
                                }}";

                                teste.Add(ItemSelecionado);
                            }

                            if (waId == "557988132044")
                            {
                                waId = "5579988132044";
                            }


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
                                        ""text"": ""{SelecionarMenu?.MenHeader}""
                                    }},
                                    ""body"": {{
                                        ""text"": ""{SelecionarMenu?.MenBody}""
                                    }},
                                    ""footer"": {{
                                        ""text"": ""{SelecionarMenu?.MenFooter}""
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
                                    ""body"": ""{Option?.OptResposta}""
                                }}
                            }}";
                        }

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
                    return await MetodoPostParaAsMensagens(dadosJson);
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

            //Alterar essa select

            var itemMensagen = dadosMensagen.LastOrDefault(x => x?.Con?.ConWaId == waId && x?.Log?.LogId == LoginWaIdDados.LogId && x?.MenTipo == "MensagenEnviada");

            var Item = dados.FirstOrDefault(x => x.ConWaId == waId && x?.LogId == LoginWaIdDados.LogId);

            if (Item == null)
            {
                Contato NovoContato = new Contato
                {
                    ConWaId = waId,
                    ConNome = Nome,
                    ConDataCadastro = DateTime.Now,
                    ConBloqueadoStatus = false,
                    LogId = LoginWaIdDados.LogId
                };
                await _contatoRepostiroy.Adicionar(NovoContato);
                return await MensagemDeMenu(waId, mensagem, LoginWaId);
            }
            else if (itemMensagen?.MensDescricao == mensagem)
            {
                throw new Exception("Mensagem Repetida");
            }
            else if (Item.ConBloqueadoStatus == true)
            {
                var dadosJson = $@"
                        {{
                            ""messaging_product"": ""whatsapp"",
                            ""recipient_type"": ""individual"",
                            ""to"": ""{waId}"",
                            ""type"": ""text"",
                            ""text"": {{
                                ""preview_url"": false,
                                ""body"": ""Seu Contato Esta Bloqueado""
                            }}
                        }}";
                return await MetodoPostParaAsMensagens(dadosJson);
            }
            else
            {
                //Alterar essa parte para comportar a nova tabela de mensagem
                Mensagen mensagen = new Mensagen
                {
                    MensDescricao = mensagem,
                    MensData = DateTime.Now,
                    MenTipo = "MensagenEnviada",
                    LogId = LoginWaIdDados.LogId,
                    ConId = Item.ConId,
                };
                await _mensagemRepository.Adicionar(mensagen);
                return await MensagemDeMenu(waId, mensagem, LoginWaId);
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
                if (item?.MensDescricao == descricaoDaMensagem)
                {
                    throw new Exception("Mensagem Repetida");
                }
                else
                {
                    //Alterar essa parte para comportar a nova tabela de mensagem
                    Mensagen mensagen = new Mensagen
                    {
                        MensDescricao = descricaoDaMensagem,
                        MensData = DateTime.Now,
                        MenTipo = "MensagenEnviada",
                        LogId = item?.LogId,
                        ConId = item?.ConId,
                    };
                    await _mensagemRepository.Adicionar(mensagen);
                    return await MensagemParaOBotResponder(waId, descricaoDaMensagem, LoginWaId);
                }
            }
            else
            {
                var Contato = await _contatoRepostiroy.RetornarConIdPorWaID(waId);
                //Alterar essa parte para comportar a nova tabela de mensagem
                Mensagen mensagen = new Mensagen
                {
                    MensDescricao = descricaoDaMensagem,
                    MensData = DateTime.Now,
                    MenTipo = "MensagenEnviada",
                    LogId = LoginWaIdDados?.LogId,
                    ConId = Contato?.ConId,
                };
                await _mensagemRepository.Adicionar(mensagen);
                return await MensagemParaOBotResponder(waId, descricaoDaMensagem, LoginWaId);
            }
        }

        public dynamic? TipoMensagemStatus(dynamic Values)
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