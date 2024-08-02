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
using static System.Runtime.InteropServices.JavaScript.JSType;
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
        public MetaRepository(IMetodoCheck metodoCheck, IContatoInterfaceServices contatoInterfaceServices,
            IAtendimentoInterfaceServices atendimentoInterfaceServices, ILoginInterfaceServices
            loginInterfaceServices, IMenuInterfaceServices menuInterfaceServices, IOptionInterfaceServices Option, IConfiguration config, IOpenaiRequest openai, IChatsInterfaceServices chatsInterfaceServices)
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
                    if (item.Atendimento.EstadoAtendimento.ToLower().Trim() != "Finalizado".ToLower().Trim())
                    {
                        var dataMensagem = Convert.ToDateTime(item.Mensagens.LastOrDefault().Data);
                        var dataAtual = DateTime.Now;
                        var diferenca = Math.Abs((dataAtual - dataMensagem).TotalMinutes);
                        string numero = item.Contato.CodigoWhatsapp;
                        if (numero == "557988132044")
                        {
                            numero = "5579988132044";
                        }

                        if (numero == "557998468046")
                        {
                            numero = "5579998468046";
                        }
                        if (dataAtual < dataMensagem)
                        {
                            diferenca -= diferenca * 2;
                        }

                        if (diferenca >= 5 && diferenca <= 10)
                        {
                            var responseObject = new
                            {
                                messaging_product = "whatsapp",
                                recipient_type = "individual",
                                to = numero,
                                type = "text",
                                text = new { preview_url = false, body = "Olá o atendimento ainda não foi finalizado, Se passar mais 10 minutos ele sera automaticamente finalizado!" },
                            };
                            dadosJson = JsonConvert.SerializeObject(responseObject);
                            await PostAsync(_configuration["BaseUrl"], _configuration["Token"], dadosJson);
                        }

                        if (diferenca > 10)
                        {
                            Atendimento NovoAtendimento = new Atendimento
                            {
                                AtenId = item.Atendimento.Codigo,
                                AtenEstado = "Finalizado",
                                AtenData = DateTime.Now,
                                AteId = item?.Atendimento?.Atendente?.Codigo,
                                DepId = item?.Atendimento?.Departamento?.Codigo,
                                LogId = item?.Atendimento?.Login?.Codigo,
                                ConId = item?.Atendimento?.Contato?.Codigo,
                            };
                            using (var newContext = new chatbotContext())
                            {
                                newContext.Atendimentos.Update(NovoAtendimento);
                                await newContext.SaveChangesAsync();
                            }
                            var responseObject = new
                            {
                                messaging_product = "whatsapp",
                                recipient_type = "individual",
                                to = numero,
                                type = "text",
                                text = new { preview_url = false, body = "O atendimento foi finalizado por inatividade." },
                            };
                            dadosJson = JsonConvert.SerializeObject(responseObject);
                            await PostAsync(_configuration["BaseUrl"], _configuration["Token"], dadosJson);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<string> EnviarMensagemDoTipoSimples(string conteudo, string numero)
        {
            try
            {
                var dadosJson = "";
                var responseObject = new
                {
                    messaging_product = "whatsapp",
                    recipient_type = "individual",
                    to = numero,
                    type = "text",
                    text = new { preview_url = false, body = conteudo },
                };
                dadosJson = JsonConvert.SerializeObject(responseObject);
                return await PostAsync(_configuration["BaseUrl"], _configuration["Token"], dadosJson);

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
                //voltar para o fluxo normal se a resposta enviada for sim
                if (Conteudo.Trim().ToLower() == "sim")
                {
                    await _atendimentoInterfaceServices.AtualizarAtendimentoComDttoDeGet(Atendimento);
                    return await MensagemInicial(Model);
                }

                //Enviar Mensagem de Aguardo a Mensagem do Gpt
                await EnviarMensagemDoTipoSimples("Aguardando Resposta...", numero);

                //Enviar Mensagem de Resposta do Gpt
                var resposta = await _openAiRequest.PostAsync(_configuration.GetSection("AES").Value, Conteudo);
                await EnviarMensagemDoTipoSimples(resposta, numero);

                var menuselecionado = await _menuInterfaceServices.PegarMenuDeIaPorLogId(Atendimento.Login.Codigo);
                return await PostAsync(_configuration["BaseUrl"], _configuration["Token"], MontarMenuParaEnvio(menuselecionado, numero));
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
            var numero = Model.Dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id;
            numero = numero == "557988132044" || numero == "557998468046" ? RetornarNumeroDeWhatsappParaNumeroTeste(numero) : numero;
            var Atendimento = await _atendimentoInterfaceServices.ResgatarAtendimentoPorLogIdEContatoWaId(Model.Dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id, Convert.ToInt32(Login?.Codigo));
            var OptionSelecionada = await _optionInterfaceServices.GetPorId(Convert.ToInt32(codigoMensagem));
            MenuDttoGet MenuSelecionadoOption = await _menuInterfaceServices.PegarMenuPorOptionId(Convert.ToInt32(codigoMensagem));
            var dadosJson = "";
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
                            await AtualizarEstadoAtendimento(Atendimento, "Finalizado");
                            isFinalizar = true;
                        }
                    }
                    //Se o atendimento for do tipo Gpt Ele ira checkar internamente e retornara a mensagem da ia corretamente
                    if (Atendimento.EstadoAtendimento == "GPT")
                    {
                        if (descricaoDaMensagem.Trim().ToLower() == "Voltar ao Fluxo de Atendimento Normal".Trim().ToLower())
                        {
                            await AtualizarEstadoAtendimento(Atendimento, "Bot");
                            return await PostAsync(_configuration["BaseUrl"], _configuration["Token"], MontarMenuParaEnvio(await _menuInterfaceServices.PegarMenuInicialPorLogId(Login.Codigo), numero));
                        }

                        if (descricaoDaMensagem.Trim().ToLower() == "Finalizar o Atendimento".Trim().ToLower())
                        {
                            await AtualizarEstadoAtendimento(Atendimento, "Finalizado");
                            dadosJson = EnviarMensagemDoTipoSimples("O Atendimento com IA foi finalizado Obrigado por interagir", numero);
                            isFinalizar = true;
                        }

                        if (isFinalizar == false)
                        {

                            dadosJson = EnviarMensagemDoTipoSimples("Aguardando Resposta...", numero);
                            await PostAsync(_configuration["BaseUrl"], _configuration["Token"], dadosJson);

                            var resposta = await _openAiRequest.PostAsync(_configuration.GetSection("AES").Value, descricaoDaMensagem);
                            dadosJson = EnviarMensagemDoTipoSimples(resposta, numero);
                            await PostAsync(_configuration["BaseUrl"], _configuration["Token"], dadosJson);
                        }
                    }

                    //dar uma olhada para ver se a opção para identificar o gpt vai ser resposta null mesmo ou alguma outra forma para dar uma olhada aqui
                    if (OptionSelecionada?.Resposta == null)
                    {
                        if (Atendimento != null)
                        {
                            await AtualizarEstadoAtendimento(Atendimento, "GPT");
                        }
                    }

                    //Se o Menu for do tipo de mensagem com multipla escolha ele vai responder com essa resposta
                    if (OptionSelecionada?.Tipo?.Trim()?.ToLower() == nameof(ETipos.mensagemderespostainterativa))
                    {
                        dadosJson = MontarMenuParaEnvio(MenuSelecionadoOption, numero);
                    }

                    //Se For Uma Mensagem Simples ele vai responder aqui
                    if (OptionSelecionada.Tipo == nameof(ETipos.MensagemDeResposta))
                    {                        
                        dadosJson = await EnviarMensagemDoTipoSimples(OptionSelecionada?.Resposta, numero);
                    }

                    //Se For Uma Mensagem Feita Por Ia ele vai Respoder assim
                    if (OptionSelecionada.Tipo == nameof(ETipos.MensagemPorIA))
                    {
                        dadosJson = await EnviarMensagemDoTipoSimples("Aguardando Resposta...", numero);
                        var resposta = await _openAiRequest.PostAsync(_configuration.GetSection("AES").Value, descricaoDaMensagem);
                        dadosJson = await EnviarMensagemDoTipoSimples(resposta, numero);
                        isBotAtendimento = true;
                    }

                    //Verifcações do estado para resposta especiais dependendo do estado das variaveis definidas acima
                    if (isFinalizar)
                    {
                        dadosJson = await EnviarMensagemDoTipoSimples("O Atendimento foi Finalizado Se Tiver Mais Alguma Questão Apenas Intereja Novamente!", numero);
                        return await PostAsync(_configuration["BaseUrl"], _configuration["Token"], dadosJson);
                    }

                    if (isBotAtendimento)
                    {
                        dadosJson = await EnviarMensagemDoTipoSimples("Voce entrou no modo de Interação com a IA Faça Uma Pergunta que ela ira te responder!", numero);
                        return await PostAsync(_configuration["BaseUrl"], _configuration["Token"], dadosJson);
                    }

                    //se ocorrer tudo bem apenas ira retornar
                    return await PostAsync(_configuration["BaseUrl"], _configuration["Token"], dadosJson);
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
        public async Task AtualizarEstadoAtendimento(AtendimentoDttoGet IsAtendimentoGoing, string estado)
        {
            try
            {
                IsAtendimentoGoing.EstadoAtendimento = estado;
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
            catch (Exception)
            {

                throw;
            }
        }
        public string MontarMenuParaEnvio(MenuDttoGet menuselecionado, string numero)
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

                if (IsAtendimentoGoing.EstadoAtendimento == "GPT")
                {
                    return await RespostaGpt(IsAtendimentoGoing, conteudo, contato.CodigoWhatsapp, Model);
                }

                await AtualizarEstadoAtendimento(IsAtendimentoGoing, "Bot");

                return await PostAsync(_configuration["BaseUrl"], _configuration["Token"], MontarMenuParaEnvio(menuselecionado, contato.CodigoWhatsapp));
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

    }
}
