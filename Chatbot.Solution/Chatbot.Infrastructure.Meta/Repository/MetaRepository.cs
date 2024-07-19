using System.Text;
using Chatbot.Domain.Models.Enums;
using Chatbot.Domain.Models.JsonMetaApi;
using Chatbot.Infrastructure.Dtto;
using Chatbot.Infrastructure.Meta.Repository.Interfaces;
using Chatbot.Infrastructure.Services.Interfaces;
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
        public MetaRepository(IMetodoCheck metodoCheck, IContatoInterfaceServices contatoInterfaceServices,
            IAtendimentoInterfaceServices atendimentoInterfaceServices, ILoginInterfaceServices
            loginInterfaceServices, IMenuInterfaceServices menuInterfaceServices, IOptionInterfaceServices Option, IConfiguration config)
        {
            _metodoCheck = metodoCheck;
            _contatoInterfaceServices = contatoInterfaceServices;
            _atendimentoInterfaceServices = atendimentoInterfaceServices;
            _loginInterfaceServices = loginInterfaceServices;
            _menuInterfaceServices = menuInterfaceServices;
            _configuration = config;
            _optionInterfaceServices = Option;
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
        public async Task<dynamic> BotResposta(DataAndType Model)
        {

            var descricaoDaMensagem = Model.Dados.entry[0].changes[0].value.messages[0].interactive.list_reply.description ?? Model.Dados.entry[0].changes[0].value.messages[0].text.body;
            var codigoMensagem = Model.Dados.entry[0].changes[0].value.messages[0].interactive.list_reply.id ?? null;
            string name = Model.Dados.entry[0].changes[0].value.metadata.display_phone_number;
            var Login = await _loginInterfaceServices.RetornarLogIdPorWaID(name);
            var Menus = await _menuInterfaceServices.PegarTodosOsMenusPorLogID(Convert.ToInt32(Login?.Codigo));
            var option = await _optionInterfaceServices.GetALl();
            var dadosAtendimento = await _atendimentoInterfaceServices.RetornarTodosAtendimentosPorLogId(Convert.ToInt32(Login?.Codigo));
            var numero = Model.Dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id;
            var dadosJson = "";
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

                    if (optionValida != null)
                    {
                        if (OptionSelecionada?.Finalizar == true)
                        {
                            var Atendimento = dadosAtendimento.FirstOrDefault(x => x?.Contato?.CodigoWhatsapp == Model.Dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id && x.Login?.Codigo == Convert.ToInt32(Login?.Codigo));

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

                                await _atendimentoInterfaceServices.AtualizarPut(NewModel);
                            }
                            else
                            {
                                throw new Exception("Não foi possivel finalizar o atendimento");
                            }

                        }

                        if (numero == "557988132044")
                        {
                            numero = "5579988132044";
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
                        else
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

                    }
                    else
                    {
                        if (numero == "5579988132044")
                        {
                            numero = "55799988132044";
                        }

                        var responseObject = new
                        {
                            messaging_product = "whatsapp",
                            recipient_type = "individual",
                            to = Model.Dados.entry[0].changes[0].value.contacts[0].wa_id,
                            type = "text",
                            text = new { preview_url = false, body = "Não entendi, Lembresse de Escolher a opção no Menu Acima!" }
                        };

                        dadosJson = JsonConvert.SerializeObject(responseObject);
                    }
                    return await PostAsync(_configuration["BaseUrl"], _configuration["Token"], dadosJson);
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
            recaiveMensagem.Root dados = Model.Dados;

            var login = await _loginInterfaceServices.RetornarLogIdPorWaID(dados?.entry[0]?.changes[0]?.value?.metadata?.display_phone_number);

            var contato = await _contatoInterfaceServices.RetornarConIdPorWaID(dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id);

            var dadosMenu = await _menuInterfaceServices.GetALl();

            var menuselecionado = dadosMenu.FirstOrDefault(x => x.Tipo == nameof(ETipos.PrimeiraMensagem) && x?.Login?.Codigo == login?.Codigo);

            if (contato?.CodigoWhatsapp == "557988132044")
            {
                contato.CodigoWhatsapp = "5579988132044";
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
