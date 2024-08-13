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
        protected readonly IChatsInterfaceServices _chatsInterfaceServices;
        protected readonly IOptionInterfaceServices _optionInterfaceServices;
        protected readonly IConfiguration _configuration;
        protected readonly IOpenaiRequest _openAiRequest;
        protected readonly IMensagemInterfaceServices _MensagemInterfaceServices;
        protected readonly IDepartamentoInterfaceServices _departamentoInterfaceServices;
        protected readonly IAtendenteInterfaceServices _atendenteInterfaceServices;
        public MetaRepository(IMetodoCheck metodoCheck, IContatoInterfaceServices contatoInterfaceServices,
            IAtendimentoInterfaceServices atendimentoInterfaceServices, ILoginInterfaceServices
            loginInterfaceServices, IMenuInterfaceServices menuInterfaceServices, IOptionInterfaceServices Option, IConfiguration config, IOpenaiRequest openai,
            IChatsInterfaceServices chatsInterfaceServices, IMensagemInterfaceServices mensagemInterfaceServices,
            IDepartamentoInterfaceServices departamentoInterfaceServices, IAtendenteInterfaceServices atendenteInterfaceServices)
        {
            _metodoCheck = metodoCheck;
            _contatoInterfaceServices = contatoInterfaceServices;
            _atendimentoInterfaceServices = atendimentoInterfaceServices;
            _loginInterfaceServices = loginInterfaceServices;
            _menuInterfaceServices = menuInterfaceServices;
            _configuration = config;
            _optionInterfaceServices = Option;
            _openAiRequest = openai;
            _chatsInterfaceServices = chatsInterfaceServices;
            _MensagemInterfaceServices = mensagemInterfaceServices;
            _departamentoInterfaceServices = departamentoInterfaceServices;
            _atendenteInterfaceServices = atendenteInterfaceServices;
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
        public async Task CompararData()
        {
            try
            {
                var dados = await _chatsInterfaceServices.GetALl();

                var dadosJson = "";
                foreach (var item in dados)
                {
                    if (item.Atendimento != null)
                    {
                        if (item.Atendimento.EstadoAtendimento != null)
                        {
                            if (item.Atendimento.EstadoAtendimento.ToLower().Trim() != "Finalizado".ToLower().Trim())
                            {
                                var dataMensagem = Convert.ToDateTime(item.Mensagens.LastOrDefault().Data);
                                var dataAtual = DateTime.Now;
                                var diferenca = Math.Abs((dataAtual - dataMensagem).TotalMinutes);
                                string numero = item.Contato.CodigoWhatsapp == "557988132044" || item.Contato.CodigoWhatsapp == "557998468046" ? RetornarNumeroDeWhatsappParaNumeroTeste(item.Contato.CodigoWhatsapp) : item.Contato.CodigoWhatsapp;

                                if (dataAtual < dataMensagem)
                                {
                                    diferenca -= diferenca * 2;
                                }

                                //ver se tem uma opção melhor para enviar a mensagem por que fica paia essa não sendo enviada de vez em quando
                                //if (diferenca >= 5 && diferenca <= 10)
                                //{
                                //    await EnviarMensagemDoTipoSimples("Olá o atendimento ainda não foi finalizado, Se passar mais 10 minutos ele sera automaticamente finalizado!", numero);
                                //}

                                if (diferenca >= 10)
                                {
                                    AtendimentoDttoGet Atendimento = new AtendimentoDttoGet
                                    {
                                        Codigo = item.Atendimento.Codigo,
                                        EstadoAtendimento = "Finalizado",
                                        Data = DateTime.Now,
                                        Atendente = item?.Atendimento?.Atendente,
                                        Departamento = item?.Atendimento?.Departamento,
                                        Login = item?.Atendimento?.Login,
                                        Contato = item?.Atendimento?.Contato,
                                    };
                                    await _atendimentoInterfaceServices.AtualizarEstadoAtendimento(Atendimento, "Finalizado", null, null);
                                    await EnviarMensagemDoTipoSimples("O atendimento foi finalizado por inatividade.", numero, item.Atendimento, item);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task SalvarMensagemAtendente(string descricao, int chat, int ate)
        {
            try
            {
                var dados = await _chatsInterfaceServices.GetPorId(chat);
                if (dados?.Atendente?.Codigo != ate)
                {
                    await _atendimentoInterfaceServices.AtualizarEstadoAtendimento(dados.Atendimento, dados.Atendimento.EstadoAtendimento, dados.Atendimento.Departamento.Codigo, ate);
                    Chat NewModel = new Chat
                    {
                        ChaId = dados.Codigo,
                        AteId = ate,
                        AtenId = dados.Atendimento.Codigo,
                        ConId = dados.Contato.Codigo,
                        LogId = dados.Atendimento.Login.Codigo
                    };
                    using (var newContext = new chatbotContext())
                    {
                        newContext.Chats.Update(NewModel);
                        await newContext.SaveChangesAsync();
                    }
                }
                var numero = dados?.Contato?.CodigoWhatsapp == "557988132044" || dados?.Contato?.CodigoWhatsapp == "557998468046" ? RetornarNumeroDeWhatsappParaNumeroTeste(dados?.Contato?.CodigoWhatsapp) : dados?.Contato?.CodigoWhatsapp;
                await EnviarMensagemDoTipoSimples(descricao, numero, dados.Atendimento, dados);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<string> EnviarMensagemDoTipoSimples(string conteudo, string numero, AtendimentoDttoGet Atendimento, ChatsDttoGet chat)
        {
            try
            {
                var responseObject = new
                {
                    messaging_product = "whatsapp",
                    recipient_type = "individual",
                    to = numero,
                    type = "text",
                    text = new { preview_url = false, body = conteudo },
                };

                if (Atendimento != null || chat != null)
                {
                    await _MensagemInterfaceServices.SaveMensage(Atendimento.Login.Codigo, chat.Codigo, conteudo);
                }

                return await PostAsync(_configuration["BaseUrl"], _configuration["Token"], JsonConvert.SerializeObject(responseObject));
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
                ChatsDttoGet chat = await _chatsInterfaceServices.RetornarChatPorAtenId(Atendimento.Codigo);
                //voltar para o fluxo normal se a resposta enviada for sim
                if (Conteudo.Trim().ToLower() == "sim")
                {
                    await _atendimentoInterfaceServices.AtualizarAtendimentoComDttoDeGet(Atendimento);
                    return await MensagemInicial(Model);
                }

                //Enviar Mensagem de Aguardo a Mensagem do Gpt
                await EnviarMensagemDoTipoSimples("Aguardando Resposta...", numero, Atendimento, chat);
                //Enviar Mensagem de Resposta do Gpt
                string resposta = await _openAiRequest.PostAsync(_configuration.GetSection("AES").Value, Conteudo);

                var menuselecionado = await _menuInterfaceServices.PegarMenuDeIaPorLogId(Atendimento.Login.Codigo);
                return await PostAsync(_configuration["BaseUrl"], _configuration["Token"], await MontarMenuParaEnvio(menuselecionado, numero, Atendimento, chat));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<dynamic> BotResposta(DataAndType Model)
        {
            //Resgatando Informaçoes iniciais e setando status base das variaveis
            var descricaoDaMensagem = Model.Dados.entry[0].changes[0].value.messages[0].interactive.list_reply.description ?? Model.Dados.entry[0].changes[0].value.messages[0].text.body;
            var codigoMensagem = Model.Dados.entry[0].changes[0].value.messages[0].interactive.list_reply.id;
            string name = Model.Dados.entry[0].changes[0].value.metadata.display_phone_number;
            var Login = await _loginInterfaceServices.RetornarLogIdPorWaID(name);
            var numero = Model.Dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id == "557988132044" || Model.Dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id == "557998468046" ? RetornarNumeroDeWhatsappParaNumeroTeste(Model.Dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id) : Model.Dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id;
            AtendimentoDttoGet Atendimento = await _atendimentoInterfaceServices.ResgatarAtendimentoPorLogIdEContatoWaId(Model.Dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id, Convert.ToInt32(Login?.Codigo));
            OptionDttoGet OptionSelecionada = await _optionInterfaceServices.GetPorId(Convert.ToInt32(codigoMensagem));
            MenuDttoGet MenuSelecionadoOption = await _menuInterfaceServices.PegarMenuPorOptionId(Convert.ToInt32(codigoMensagem));
            ChatsDttoGet chat = await _chatsInterfaceServices.RetornarChatPorAtenId(Atendimento.Codigo);
            var isFinalizar = false;
            var isBotAtendimento = false;
            try
            {
                //checkar se a mensagem não e nula
                if (descricaoDaMensagem != null && descricaoDaMensagem != "" && descricaoDaMensagem != " ")
                {
                    //finalizar atendimento se a option for tipo de finalizar
                    if (OptionSelecionada?.Finalizar == true)
                    {
                        if (Atendimento != null)
                        {
                            await _atendimentoInterfaceServices.AtualizarEstadoAtendimento(Atendimento, "Finalizado", null, null);
                            isFinalizar = true;
                        }
                    }
                    //Se o atendimento for do tipo Gpt Ele ira checkar internamente e retornara a mensagem da ia corretamente
                    if (Atendimento?.EstadoAtendimento?.Trim()?.ToLower() == "GPT".Trim()?.ToLower())
                    {
                        if (descricaoDaMensagem.Trim().ToLower() == "Voltar ao Fluxo de Atendimento Normal".Trim().ToLower())
                        {
                            await _atendimentoInterfaceServices.AtualizarEstadoAtendimento(Atendimento, "Bot", null, null);
                            return await PostAsync(_configuration["BaseUrl"], _configuration["Token"], await MontarMenuParaEnvio(await _menuInterfaceServices.PegarMenuInicialPorLogId(Login.Codigo), numero, Atendimento, chat));
                        }

                        if (descricaoDaMensagem.Trim().ToLower() == "Finalizar o Atendimento".Trim().ToLower())
                        {
                            await _atendimentoInterfaceServices.AtualizarEstadoAtendimento(Atendimento, "Finalizado", null, null);
                            await EnviarMensagemDoTipoSimples("O Atendimento com IA foi finalizado Obrigado por interagir", numero, Atendimento, chat);
                            isFinalizar = true;
                        }

                        if (isFinalizar == false)
                        {
                            await EnviarMensagemDoTipoSimples("Aguardando Resposta...", numero, Atendimento, chat);
                            string resposta = await _openAiRequest.PostAsync(_configuration.GetSection("AES").Value, descricaoDaMensagem);
                            await EnviarMensagemDoTipoSimples(resposta, numero, Atendimento, chat);
                        }
                    }

                    //Se o Menu for do tipo de mensagem com multipla escolha ele vai responder com essa resposta
                    if (OptionSelecionada?.Tipo?.Trim()?.ToLower() == nameof(ETipos.mensagemderespostainterativa).Trim()?.ToLower())
                    {
                        await PostAsync(_configuration["BaseUrl"], _configuration["Token"], await MontarMenuParaEnvio(MenuSelecionadoOption, numero, Atendimento, chat));
                    }

                    //Se For Uma Mensagem Simples ele vai responder aqui
                    if (OptionSelecionada?.Tipo?.Trim()?.ToLower() == nameof(ETipos.MensagemDeResposta).Trim()?.ToLower())
                    {
                        await EnviarMensagemDoTipoSimples(OptionSelecionada?.Resposta, numero, Atendimento, chat);
                    }

                    //Se For Uma Mensagem Feita Por Ia ele vai Respoder assim
                    if (OptionSelecionada?.Tipo?.Trim()?.ToLower() == nameof(ETipos.MensagemPorIA).Trim()?.ToLower() && isFinalizar != true)
                    {
                        if (Atendimento != null && Atendimento?.EstadoAtendimento.Trim()?.ToLower() != "GPT".Trim()?.ToLower())
                        {
                            await _atendimentoInterfaceServices.AtualizarEstadoAtendimento(Atendimento, "GPT", null, null);
                        }
                        await EnviarMensagemDoTipoSimples("Aguardando Resposta...", numero, Atendimento, chat);
                        string resposta = await _openAiRequest.PostAsync(_configuration.GetSection("AES").Value, descricaoDaMensagem);
                        await EnviarMensagemDoTipoSimples(resposta, numero, Atendimento, chat);
                        isBotAtendimento = true;
                    }

                    //Se For Uma Mensagem Para conduzir para o atendimento humano
                    if (OptionSelecionada?.Tipo?.Trim()?.ToLower() == nameof(ETipos.RedirecinamentoHumano).Trim()?.ToLower())
                    {
                        if (Atendimento != null && Atendimento?.EstadoAtendimento?.Trim()?.ToLower() != "HUMANO".Trim()?.ToLower())
                        {
                            await _atendimentoInterfaceServices.AtualizarEstadoAtendimento(Atendimento, "HUMANO", Convert.ToInt32(OptionSelecionada?.Resposta), null);
                        }
                        await EnviarMensagemDoTipoSimples("Voce entrou na nossa fila de atendimento por favor aguarde sua vez de ser atendido por um de nossos atendentes!", numero, Atendimento, chat);
                    }

                    //Verifcações do estado para resposta especiais dependendo do estado das variaveis definidas acima
                    if (isFinalizar)
                    {
                        await EnviarMensagemDoTipoSimples("O Atendimento foi Finalizado Se Tiver Mais Alguma Questão Apenas Intereja Novamente!", numero, Atendimento, chat);
                    }

                    if (isBotAtendimento)
                    {
                        await EnviarMensagemDoTipoSimples("Voce entrou no modo de Interação com a IA Faça Uma Pergunta que ela ira te responder!", numero, Atendimento, chat);
                    }

                    //se ocorrer tudo bem apenas ira retornar
                    return "Mensagem Enviada Com Sucesso";
                }

                throw new Exception();
            }
            catch (Exception)
            {
                throw new Exception("Menssagem Vazia Ou Feita Por Bot");
            }
        }
        public string RetornarNumeroDeWhatsappParaNumeroTeste(string contato)
        {
            if (contato == "557988132044")
            {
                contato = "5579988132044";
            }

            if (contato == "557998468046")
            {
                contato = "5579998468046";
            }

            return contato;
        }
        public async Task<string> IsAtendimentoNull(DataAndType Model)
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<string> MontarMenuParaEnvio(MenuDttoGet menuselecionado, string numero, AtendimentoDttoGet Atendimento, ChatsDttoGet chat)
        {
            try
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
                await _MensagemInterfaceServices.SaveMensage(Atendimento.Login.Codigo, chat.Codigo, menuselecionado.Titulo);
                return JsonConvert.SerializeObject(responseObject);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<dynamic> MensagemInicial(DataAndType Model)
        {
            try
            {
                recaiveMensagem.Root dados = Model.Dados;

                var login = await _loginInterfaceServices.RetornarLogIdPorWaID(dados?.entry[0]?.changes[0]?.value?.metadata?.display_phone_number);
                var contato = await _contatoInterfaceServices.RetornarConIdPorWaID(dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id);
                var menuselecionado = await _menuInterfaceServices.PegarMenuInicialPorLogId(login.Codigo);
                var conteudo = dados.entry[0].changes[0].value.messages[0].text.body;

                contato.CodigoWhatsapp = contato.CodigoWhatsapp == "557988132044" || contato.CodigoWhatsapp == "557998468046" ? RetornarNumeroDeWhatsappParaNumeroTeste(contato.CodigoWhatsapp) : contato.CodigoWhatsapp;

                var IsAtendimentoGoing = await _atendimentoInterfaceServices.AtendimentoExiste(login, contato);

                if (IsAtendimentoGoing == null)
                {
                    return await IsAtendimentoNull(Model);
                }

                if (IsAtendimentoGoing.EstadoAtendimento != null)
                {
                    if (IsAtendimentoGoing.EstadoAtendimento.Trim().ToLower() == "GPT".Trim().ToLower())
                    {
                        return await RespostaGpt(IsAtendimentoGoing, conteudo, contato.CodigoWhatsapp, Model);
                    }

                    //como a mensagem ja e salva e o chat ja esta configurado no metodo inicial vou deixar apenas para ele não retornar nada aqui por enquanto
                    if (IsAtendimentoGoing.EstadoAtendimento.Trim().ToLower() == "HUMANO".Trim().ToLower())
                    {
                        throw new NotImplementedException();
                    }
                }
                var chat = await _chatsInterfaceServices.RetornarChatPorAtenId(IsAtendimentoGoing.Codigo);
                await _atendimentoInterfaceServices.AtualizarEstadoAtendimento(IsAtendimentoGoing, "Bot", null, null);
                return await PostAsync(_configuration["BaseUrl"], _configuration["Token"], await MontarMenuParaEnvio(menuselecionado, contato.CodigoWhatsapp, chat.Atendimento, chat));
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
            if (dados.Tipo == ETipoRetornoJson.TipoMultiplaEscolhas)
            {
                return await BotResposta(dados);
            }
            if (dados.Tipo == ETipoRetornoJson.TipoPost)
            {
                return await PostAsync(_configuration["BaseUrl"], _configuration["Token"], JsonConvert.SerializeObject(dados.Dados));
            }
            throw new NotImplementedException();
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
        public async Task<string> EnvioDeMensagensEmMassa(List<ContatoDttoGet> Contatos, string conteudo)
        {
            try
            {
                foreach (var item in Contatos)
                {
                    var chat = await _chatsInterfaceServices.RetornarChatPorConIdELogId(item.Codigo, item.Codigologin);
                    if (chat != null)
                    {
                        if (chat.Atendimento != null)
                        {
                            await EnviarMensagemDoTipoSimples(conteudo, item.CodigoWhatsapp == "557988132044" || item.CodigoWhatsapp == "557998468046" ? RetornarNumeroDeWhatsappParaNumeroTeste(item.CodigoWhatsapp) : item.CodigoWhatsapp, chat.Atendimento, chat);
                        }
                    }                    
                }
                return "Mensagens Enviadas Com Sucesso";
            }
            catch (Exception ex)
            {
                return $"Error Ao Enviar Mensagens: Error{ex.Message}";
            }
        }
    }
}
