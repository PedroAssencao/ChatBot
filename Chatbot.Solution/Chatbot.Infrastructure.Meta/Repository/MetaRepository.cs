using System.Text;
using Chatbot.API.DAL;
using Chatbot.Domain.Models;
using Chatbot.Domain.Models.Enums;
using Chatbot.Domain.Models.JsonMetaApi;
using Chatbot.Infrastructure.Dtto;
using Chatbot.Infrastructure.Meta.Repository.Interfaces;
using Chatbot.Infrastructure.Services.Interfaces;
using Chatbot.Infrastrucutre.OpenAI.Repository.Interface;
using Chatbot.Services.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
namespace Chatbot.Infrastructure.Meta.Repository
{
    public class MetaRepository : IMetaClient
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        protected readonly IMetodoCheck _metodoCheck;
        protected readonly IContatoInterfaceServices _contatoInterfaceServices;
        protected readonly IAtendimentoInterfaceServices _atendimentoInterfaceServices;
        protected readonly ILoginInterfaceServices _loginInterfaceServices;
        protected readonly IMenuInterfaceServices _menuInterfaceServices;
        protected readonly IOptionInterfaceServices _optionInterfaceServices;
        protected readonly IConfiguration _configuration;
        protected readonly IOpenaiRequest _openAiRequest;
        public MetaRepository(IMetodoCheck metodoCheck, IContatoInterfaceServices contatoInterfaceServices,
            IAtendimentoInterfaceServices atendimentoInterfaceServices, ILoginInterfaceServices
            loginInterfaceServices, IMenuInterfaceServices menuInterfaceServices, IOptionInterfaceServices Option, IConfiguration config, IOpenaiRequest openai)
        {
            _metodoCheck = metodoCheck;
            _contatoInterfaceServices = contatoInterfaceServices;
            _atendimentoInterfaceServices = atendimentoInterfaceServices;
            _loginInterfaceServices = loginInterfaceServices;
            _menuInterfaceServices = menuInterfaceServices;
            _configuration = config;
            _optionInterfaceServices = Option;
            _openAiRequest = openai;
        }

        public HttpClient ConfigurarClient(string token, string url)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                _httpClient.DefaultRequestHeaders.Add("User-Agent", "Other");
                return _httpClient;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<dynamic> RespostaGpt(AtendimentoDttoGet Atendimento, string Conteudo, string numero, DataAndType Model)
        {
            try
            {
                var dadosJson = "";

                if (Conteudo.Trim().ToLower() == "sim")
                {
                    AtendimentoDttoPut NewModel = new AtendimentoDttoPut
                    {
                        Codigo = Atendimento.Codigo,
                        CodigoAtendente = null,
                        CodigoDepartamento = null,
                        Data = DateTime.Now,
                        EstadoAtendimento = null,
                        CodigoContato = Atendimento.Contato.Codigo,
                        CodigoLogin = Atendimento.Login.Codigo
                    };
                    await _atendimentoInterfaceServices.AtualizarPut(NewModel);
                    return await MensagemInicial(Model);
                }

                var responseObject = new
                {
                    messaging_product = "whatsapp",
                    recipient_type = "individual",
                    to = numero,
                    type = "text",
                    text = new { preview_url = false, body = "Aguardando Resposta..." },
                };
                dadosJson = JsonConvert.SerializeObject(responseObject);
                await PostAsync(_configuration["BaseUrl"], _configuration["Token"], dadosJson);

                var resposta = await _openAiRequest.PostAsync(_configuration.GetSection("AES").Value, Conteudo);
                var NewresponseObject = new
                {
                    messaging_product = "whatsapp",
                    recipient_type = "individual",
                    to = numero,
                    type = "text",
                    text = new { preview_url = false, body = resposta },
                };
                dadosJson = JsonConvert.SerializeObject(NewresponseObject);
                await PostAsync(_configuration["BaseUrl"], _configuration["Token"], dadosJson);

                var dadosMenu = await _menuInterfaceServices.GetALl();
                var menuselecionado = dadosMenu.FirstOrDefault(x => x.Tipo == nameof(ETipos.MenuDaIA) && x?.Login?.Codigo == Atendimento?.Login.Codigo);

                var NewResponseObjectToPost = new
                {
                    messaging_product = "whatsapp",
                    recipient_type = "individual",
                    to = numero,
                    type = "interactive",
                    interactive = new
                    {
                        type = "list",
                        header = new { type = "text", text = menuselecionado?.Header },
                        body = new { text = menuselecionado?.Body },
                        footer = new { text = menuselecionado?.Footer },
                        action = new
                        {
                            button = "Menu de Opções",
                            sections = new[]
                            {
                                new { title = "Shorter Section Title", rows = menuselecionado?.Options?.Select(item => new { id = item.Codigo, title = item.Titulo, description = item.Descricao }).ToArray() }
                            }
                        }
                    }
                };
                dadosJson = JsonConvert.SerializeObject(NewResponseObjectToPost);
                return await PostAsync(_configuration["BaseUrl"], _configuration["Token"], dadosJson);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<dynamic> BotResposta(DataAndType Model)
        {
            var descricaoDaMensagem = Model.Dados.entry[0].changes[0].value.messages[0].interactive.list_reply.description ?? Model.Dados.entry[0].changes[0].value.messages[0].text.body;
            var codigoMensagem = Model.Dados.entry[0].changes[0].value.messages[0].interactive.list_reply.id;
            string name = Model.Dados.entry[0].changes[0].value.metadata.display_phone_number;
            var Login = await _loginInterfaceServices.RetornarLogIdPorWaID(name);
            var Menus = await _menuInterfaceServices.PegarTodosOsMenusPorLogID(Convert.ToInt32(Login?.Codigo));
            var option = await _optionInterfaceServices.GetALl();
            var dadosAtendimento = await _atendimentoInterfaceServices.RetornarTodosAtendimentosPorLogId(Convert.ToInt32(Login?.Codigo));
            var numero = Model.Dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id;
            var dadosJson = "";
            var isFinalizar = false;
            var isBotAtendimento = false;
            var Atendimento = dadosAtendimento.FirstOrDefault(x => x?.Contato?.CodigoWhatsapp == Model.Dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id && x.Login?.Codigo == Convert.ToInt32(Login?.Codigo));
            try
            {

                if (descricaoDaMensagem != null && descricaoDaMensagem != "" && descricaoDaMensagem != " ")
                {
                    var OptionSelecionada = option.Where(x => x?.Login?.Codigo == Login?.Codigo).ToList().FirstOrDefault(x => x.Codigo == Convert.ToInt32(codigoMensagem) || x.Descricao == descricaoDaMensagem);
                    MenuDttoGet MenuSelecionadoOption = null;
                    var optionValida = Menus.FirstOrDefault(x => x.Codigo == OptionSelecionada.CodigoMenu);
                    try
                    {
                        MenuSelecionadoOption = Menus.FirstOrDefault(x => x.Codigo == Convert.ToInt32(OptionSelecionada?.Resposta));
                    }
                    catch (Exception)
                    {
                        MenuSelecionadoOption = null;
                    }

                    if (OptionSelecionada?.Finalizar == true)
                    {
                        if (Atendimento != null)
                        {
                            AtendimentoDttoPut NewModel = new AtendimentoDttoPut
                            {
                                Codigo = Atendimento.Codigo,
                                CodigoAtendente = null,
                                CodigoDepartamento = null,
                                Data = DateTime.Now,
                                EstadoAtendimento = "Finalizado",
                                CodigoContato = Atendimento.Contato.Codigo,
                                CodigoLogin = Atendimento.Login.Codigo
                            };
                            isFinalizar = true;
                            await _atendimentoInterfaceServices.AtualizarPut(NewModel);
                        }
                        else
                        {
                            throw new Exception("Não foi possivel finalizar o atendimento");
                        }

                    }

                    if (Atendimento.EstadoAtendimento == "GPT")
                    {
                        if (descricaoDaMensagem.Trim().ToLower() == "Voltar ao Fluxo de Atendimento Normal".Trim().ToLower())
                        {
                            AtendimentoDttoPut NewModel = new AtendimentoDttoPut
                            {
                                Codigo = Atendimento.Codigo,
                                CodigoAtendente = null,
                                CodigoDepartamento = null,
                                Data = DateTime.Now,
                                EstadoAtendimento = "Bot",
                                CodigoContato = Atendimento.Contato.Codigo,
                                CodigoLogin = Atendimento.Login.Codigo
                            };
                            await _atendimentoInterfaceServices.AtualizarPut(NewModel);
                            var dadosMenu = await _menuInterfaceServices.GetALl();
                            var menuselecionado = dadosMenu.FirstOrDefault(x => x.Tipo == nameof(ETipos.PrimeiraMensagem) && x?.Login?.Codigo == Login?.Codigo);

                            var NewResponseObjectToPost = new
                            {
                                messaging_product = "whatsapp",
                                recipient_type = "individual",
                                to = numero,
                                type = "interactive",
                                interactive = new
                                {
                                    type = "list",
                                    header = new { type = "text", text = menuselecionado?.Header },
                                    body = new { text = menuselecionado?.Body },
                                    footer = new { text = menuselecionado?.Footer },
                                    action = new
                                    {
                                        button = "Menu de Opções",
                                        sections = new[]
                                            {
                                                new { title = "Shorter Section Title", rows = menuselecionado?.Options?.Select(item => new { id = item.Codigo, title = item.Titulo, description = item.Descricao }).ToArray() }
                                            }
                                    }
                                }
                            };
                            dadosJson = JsonConvert.SerializeObject(NewResponseObjectToPost);
                            return await PostAsync(_configuration["BaseUrl"], _configuration["Token"], dadosJson);
                        }

                        if (descricaoDaMensagem.Trim().ToLower() == "Finalizar o Atendimento".Trim().ToLower())
                        {
                            AtendimentoDttoPut NewModel = new AtendimentoDttoPut
                            {
                                Codigo = Atendimento.Codigo,
                                CodigoAtendente = null,
                                CodigoDepartamento = null,
                                Data = DateTime.Now,
                                EstadoAtendimento = "Finalizado",
                                CodigoContato = Atendimento.Contato.Codigo,
                                CodigoLogin = Atendimento.Login.Codigo
                            };
                            isFinalizar = true;
                            Atendimento NovoAtendimento = new Atendimento
                            {
                                AtenId = NewModel.Codigo,
                                AtenEstado = NewModel.EstadoAtendimento,
                                AtenData = DateTime.Now,
                                AteId = NewModel.CodigoAtendente,
                                DepId = NewModel.CodigoDepartamento,
                                LogId = NewModel.CodigoLogin,
                                ConId = NewModel.CodigoContato,
                            };
                            using (var newContext = new chatbotContext())
                            {
                                newContext.Atendimentos.Update(NovoAtendimento);
                                await newContext.SaveChangesAsync();
                            }
                            var FinalizarMensageObject = new
                            {
                                messaging_product = "whatsapp",
                                recipient_type = "individual",
                                to = numero,
                                type = "text",
                                text = new { preview_url = false, body = "O Atendimento com IA foi finalizado Obrigado por interagir" },
                            };
                            dadosJson = JsonConvert.SerializeObject(FinalizarMensageObject);
                        }
                        else
                        {
                            var responseObject = new
                            {
                                messaging_product = "whatsapp",
                                recipient_type = "individual",
                                to = numero,
                                type = "text",
                                text = new { preview_url = false, body = "Aguardando Resposta..." },
                            };
                            dadosJson = JsonConvert.SerializeObject(responseObject);
                            await PostAsync(_configuration["BaseUrl"], _configuration["Token"], dadosJson);

                            var resposta = await _openAiRequest.PostAsync(_configuration.GetSection("AES").Value, descricaoDaMensagem);
                            var NewresponseObject = new
                            {
                                messaging_product = "whatsapp",
                                recipient_type = "individual",
                                to = numero,
                                type = "text",
                                text = new { preview_url = false, body = resposta },
                            };
                            dadosJson = JsonConvert.SerializeObject(NewresponseObject);
                            await PostAsync(_configuration["BaseUrl"], _configuration["Token"], dadosJson);

                        }
                    }


                    if (OptionSelecionada?.Resposta == null)
                    {
                        if (Atendimento != null)
                        {
                            AtendimentoDttoPut NewModel = new AtendimentoDttoPut
                            {
                                Codigo = Atendimento.Codigo,
                                CodigoAtendente = null,
                                CodigoDepartamento = null,
                                Data = DateTime.Now,
                                EstadoAtendimento = "GPT",
                                CodigoContato = Atendimento.Contato.Codigo,
                                CodigoLogin = Atendimento.Login.Codigo
                            };
                            await _atendimentoInterfaceServices.AtualizarPut(NewModel);
                        }
                        else
                        {
                            throw new Exception("Não foi possivel Atualizar o atendimento");
                        }

                    }

                    if (numero == "557988132044")
                    {
                        numero = "5579988132044";
                    }

                    if (numero == "557998468046")
                    {
                        numero = "5579998468046";
                    }

                    if (OptionSelecionada?.Tipo?.Trim()?.ToLower() == nameof(ETipos.mensagemderespostainterativa))
                    {
                        var responseObject = new
                        {
                            messaging_product = "whatsapp",
                            recipient_type = "individual",
                            to = numero,
                            type = "interactive",
                            interactive = new
                            {
                                type = "list",
                                header = new { type = "text", text = MenuSelecionadoOption?.Header },
                                body = new { text = MenuSelecionadoOption?.Body },
                                footer = new { text = MenuSelecionadoOption?.Footer },
                                action = new
                                {
                                    button = "Menu de Opções",
                                    sections = new[]
                                    {
                                            new { title = "Shorter Section Title", rows = MenuSelecionadoOption?.Options?.Select(item => new { id = item.Codigo, title = item.Titulo, description = item.Descricao }).ToArray() }
                                        }
                                }

                            }
                        };
                        dadosJson = JsonConvert.SerializeObject(responseObject);
                    }

                    if (OptionSelecionada.Tipo == nameof(ETipos.MensagemDeResposta))
                    {
                        var responseObject = new
                        {
                            messaging_product = "whatsapp",
                            recipient_type = "individual",
                            to = numero,
                            type = "text",
                            text = new { preview_url = false, body = OptionSelecionada?.Resposta },
                        };
                        dadosJson = JsonConvert.SerializeObject(responseObject);
                    }

                    if (OptionSelecionada.Tipo == nameof(ETipos.MensagemPorIA))
                    {
                        var NewresponseObject = new
                        {
                            messaging_product = "whatsapp",
                            recipient_type = "individual",
                            to = numero,
                            type = "text",
                            text = new { preview_url = false, body = "Aguardando Resposta..." },
                        };

                        dadosJson = JsonConvert.SerializeObject(NewresponseObject);
                        await PostAsync(_configuration["BaseUrl"], _configuration["Token"], dadosJson);

                        var resposta = await _openAiRequest.PostAsync(_configuration.GetSection("AES").Value, descricaoDaMensagem);
                        var responseObject = new
                        {
                            messaging_product = "whatsapp",
                            recipient_type = "individual",
                            to = numero,
                            type = "text",
                            text = new { preview_url = false, body = resposta },
                        };
                        dadosJson = JsonConvert.SerializeObject(responseObject);
                        isBotAtendimento = true;
                    }

                    if (isFinalizar)
                    {
                        await PostAsync(_configuration["BaseUrl"], _configuration["Token"], dadosJson);
                        var responseObject = new
                        {
                            messaging_product = "whatsapp",
                            recipient_type = "individual",
                            to = Model.Dados.entry[0].changes[0].value.contacts[0].wa_id,
                            type = "text",
                            text = new { preview_url = false, body = "O Atendimento foi Finalizado Se Tiver Mais Alguma Questão Apenas Intereja Novamente!" }
                        };
                        dadosJson = JsonConvert.SerializeObject(responseObject);
                        return await PostAsync(_configuration["BaseUrl"], _configuration["Token"], dadosJson);
                    }
                    if (isBotAtendimento)
                    {
                        await PostAsync(_configuration["BaseUrl"], _configuration["Token"], dadosJson);
                        var NewresponseObject = new
                        {
                            messaging_product = "whatsapp",
                            recipient_type = "individual",
                            to = numero,
                            type = "text",
                            text = new { preview_url = false, body = "Voce entrou no modo de Interação com a IA Faça Uma Pergunta que ela ira te responder!" },
                        };

                        dadosJson = JsonConvert.SerializeObject(NewresponseObject);
                        return await PostAsync(_configuration["BaseUrl"], _configuration["Token"], dadosJson);
                    }
                    else
                    {
                        return await PostAsync(_configuration["BaseUrl"], _configuration["Token"], dadosJson);
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
        
        public async Task<dynamic> MensagemInicial(DataAndType Model)
        {
            try
            {
                recaiveMensagem.Root dados = Model.Dados;

                var login = await _loginInterfaceServices.RetornarLogIdPorWaID(dados?.entry[0]?.changes[0]?.value?.metadata?.display_phone_number);

                var contato = await _contatoInterfaceServices.RetornarConIdPorWaID(dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id);

                var dadosMenu = await _menuInterfaceServices.GetALl();

                var dadosAtendimento = await _atendimentoInterfaceServices.RetornarTodosAtendimentosPorLogId(Convert.ToInt32(login?.Codigo));

                var menuselecionado = dadosMenu.FirstOrDefault(x => x.Tipo == nameof(ETipos.PrimeiraMensagem) && x?.Login?.Codigo == login?.Codigo);

                var conteudo = dados.entry[0].changes[0].value.messages[0].text.body;

                if (contato?.CodigoWhatsapp == "557988132044")
                {
                    contato.CodigoWhatsapp = "5579988132044";
                }

                if (contato?.CodigoWhatsapp == "557998468046")
                {
                    contato.CodigoWhatsapp = "5579998468046";
                }

                var IsAtendimentoGoing = dadosAtendimento.Where(x => x.EstadoAtendimento == null || x.EstadoAtendimento == "Finalizado" || x.EstadoAtendimento == "GPT").FirstOrDefault(x => x.Contato.Codigo == contato.Codigo);

                if (IsAtendimentoGoing == null)
                {
                    var dadosJson = "";

                    var teste = new
                    {
                        messaging_product = "whatsapp",
                        recipient_type = "individual",
                        to = Model.Dados.entry[0].changes[0].value.contacts[0].wa_id,
                        type = "text",
                        text = new { preview_url = false, body = "Não entendi, Lembresse de Escolher a opção no Menu Acima!" }
                    };

                    dadosJson = JsonConvert.SerializeObject(teste);
                    return await PostAsync(_configuration["BaseUrl"], _configuration["Token"], dadosJson);
                }

                if (IsAtendimentoGoing.EstadoAtendimento == "GPT")
                {
                    return await RespostaGpt(IsAtendimentoGoing, conteudo, contato.CodigoWhatsapp, Model);
                }
                else
                {
                    IsAtendimentoGoing.EstadoAtendimento = "Bot";
                    Atendimento NovoAtendimento = new Atendimento
                    {
                        AtenId = IsAtendimentoGoing.Codigo,
                        AtenEstado = IsAtendimentoGoing.EstadoAtendimento,
                        AtenData = DateTime.Now,
                        AteId = IsAtendimentoGoing.Atendente?.Codigo,
                        DepId = IsAtendimentoGoing.Departamento?.Codigo,
                        LogId = IsAtendimentoGoing.Login?.Codigo,
                        ConId = IsAtendimentoGoing.Contato?.Codigo,
                    };
                    using (var newContext = new chatbotContext())
                    {
                        newContext.Atendimentos.Update(NovoAtendimento);
                        await newContext.SaveChangesAsync();
                    }
                }

                var responseObject = new
                {
                    messaging_product = "whatsapp",
                    recipient_type = "individual",
                    to = contato?.CodigoWhatsapp,
                    type = "interactive",
                    interactive = new
                    {
                        type = "list",
                        header = new { type = "text", text = menuselecionado?.Header },
                        body = new { text = menuselecionado?.Body },
                        footer = new { text = menuselecionado?.Footer },
                        action = new
                        {
                            button = "Menu de Opções",
                            sections = new[]
                            {
                            new { title = "Shorter Section Title", rows = menuselecionado?.Options?.Select(item => new { id = item.Codigo, title = item.Titulo, description = item.Descricao }).ToArray() }
                        }
                        }
                    }
                };

                return await PostAsync(_configuration["BaseUrl"], _configuration["Token"], JsonConvert.SerializeObject(responseObject));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<dynamic> ChamarMetodo(dynamic Values)
        {
            DataAndType dados = await _metodoCheck.VerificarTipoDeRetorno(Values);
            if (dados.Tipo == ETipoRetornoJson.TipoSimples)
            {
                return await MensagemInicial(dados);
            }
            else if (dados.Tipo == ETipoRetornoJson.TipoMultiplaEscolhas)
            {
                return await BotResposta(dados);
            }
            else if (dados.Tipo == ETipoRetornoJson.TipoPost)
            {
                return await PostAsync(_configuration["BaseUrl"], _configuration["Token"], JsonConvert.SerializeObject(dados.Dados));
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public async Task<string> PostAsync(string url, string token, dynamic data)
        {
            try
            {
                var client = ConfigurarClient(token, url);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                string responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
