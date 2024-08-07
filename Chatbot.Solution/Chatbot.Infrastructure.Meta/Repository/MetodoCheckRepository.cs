using Chatbot.Domain.Models.Enums;
using Chatbot.Domain.Models.JsonMetaApi;
using Chatbot.Infrastructure.Dtto;
using Chatbot.Infrastructure.Meta.Repository.Interfaces;
using Chatbot.Infrastructure.Services.Interfaces;
using Chatbot.Services.Services.Interfaces;
using System.Text.Json;
namespace Chatbot.Infrastructure.Meta.Repository
{
    public class MetodoCheckRepository : IMetodoCheck
    {
        protected readonly IContatoInterfaceServices _contatoInterfaceServices;
        protected readonly IMensagemInterfaceServices _MensagemInterfaceServices;
        protected readonly ILoginInterfaceServices _LoginInterfaceServices;
        protected readonly IAtendimentoInterfaceServices _AtendimentoInterfaceServices;
        private readonly IChatsInterfaceServices _ChatsInterfaceServices;
        public MetodoCheckRepository(IContatoInterfaceServices contatoInterfaceServices, IMensagemInterfaceServices mensagemInterfaceServices, ILoginInterfaceServices loginInterfaceServices,
            IAtendimentoInterfaceServices atendimentoInterfaceServices, IChatsInterfaceServices chatsInterfaceServices)
        {
            _contatoInterfaceServices = contatoInterfaceServices;
            _MensagemInterfaceServices = mensagemInterfaceServices;
            _LoginInterfaceServices = loginInterfaceServices;
            _AtendimentoInterfaceServices = atendimentoInterfaceServices;
            _ChatsInterfaceServices = chatsInterfaceServices;
        }

        //ver maneira melhor de fazer esse metodo fica muito dificil de ler com esse monte de try aninhado porem por enquanto funciona
        public async Task<DataAndType> VerificarTipoDeRetorno(dynamic Values)
        {
            try
            {
                var dados = await TipoMensagemSimples(Values);
                return dados;
            }
            catch (Exception)
            {
                try
                {
                    var dados = await TipoMensagemMultiplaEscolha(Values);
                    return dados;
                }
                catch (Exception)
                {
                    try
                    {
                        var dados = TipomensagemDeStatus(Values);
                        return dados;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Metodo não Identificado");
                    }
                }
            }
        }
        public DataAndType TipomensagemDeStatus(dynamic Values)
        {
            //mensagem que atualiza o status de uma mensagem porem como ainda não foi implementado ele vai para analise ainda
            try
            {
                var dados = JsonSerializer.Deserialize<recaiveStatusMensagem.Root>(Values.ToString());
                DataAndType Model = new DataAndType
                {
                    Tipo = ETipoRetornoJson.TipoStatus,
                    Dados = dados
                };
                return Model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<DataAndType> TipoMensagemMultiplaEscolha(dynamic Values)
        {
            //metodo feito para identificar se o objeto recebido e uma resposta a um menu ou seja uma mensagem de multipla escolha
            try
            {
                var dados = JsonSerializer.Deserialize<recaiveMensagemWithMultipleOption.Root>(Values.ToString());
                if (dados.entry[0].changes[0].value.messages[0].interactive.list_reply.description == null)
                {
                    throw new Exception("Metodo errado");
                }
                DataAndType Model = new DataAndType
                {
                    Tipo = ETipoRetornoJson.TipoMultiplaEscolhas,
                    Dados = dados
                };
                return await VerificaçõesIniciais(Model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<DataAndType> TipoMensagemSimples(dynamic Values)
        {
            //metodo feito para verificar se o tipo da mensagem recebida e apenas um texto
            try
            {
                var dados = JsonSerializer.Deserialize<recaiveMensagem.Root>(Values.ToString());
                if (dados.entry[0].changes[0].value.messages == null || dados.entry[0].changes[0].value.messages[0].text == null)
                {
                    throw new Exception("Metodo errado");
                }

                DataAndType Model = new DataAndType
                {
                    Tipo = ETipoRetornoJson.TipoSimples,
                    Dados = dados
                };
                return await VerificaçõesIniciais(Model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ContatoDttoGet> ContatoIsNull(DataAndType dados, LoginDttoGet Login)
        {
            //se o contato não existir esse metodo vai crialo
            try
            {
                ContatoDttoGet newModel = new ContatoDttoGet
                {
                    CodigoWhatsapp = dados.Dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id,
                    DataCadastro = DateTime.Now,
                    BloqueadoStatus = false,
                    Nome = dados.Dados?.entry[0]?.changes[0]?.value?.contacts[0].profile.name,
                    Codigologin = Login.Codigo

                };
                var viewmodel = await _contatoInterfaceServices.CreateComCodigo(newModel);
                ContatoDttoGet bababa = new ContatoDttoGet
                {
                    Codigo = viewmodel.Codigo,
                    Codigologin = viewmodel.Codigologin,
                    CodigoWhatsapp = viewmodel.CodigoWhatsapp,
                    BloqueadoStatus = viewmodel.BloqueadoStatus,
                    DataCadastro = viewmodel.DataCadastro,
                    Nome = viewmodel.Nome,
                };
                return bababa;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<AtendimentoDttoGet> AtendimentoIsNull(DataAndType dados, ContatoDttoGet contato, LoginDttoGet Login)
        {
            //caso o atendimento não exista esse metodo vai crialo
            try
            {
                AtendimentoDttoPost NovoAtendimento = new AtendimentoDttoPost
                {
                    EstadoAtendimento = null,
                    Data = DateTime.Now,
                    CodigoAtendente = null,
                    CodigoDepartamento = null,
                    CodigoLogin = Login?.Codigo,
                    CodigoContato = contato?.Codigo,
                };
                var viewmodel = await _AtendimentoInterfaceServices.AdicionarPost(NovoAtendimento);
                AtendimentoDttoGet bababa = new AtendimentoDttoGet
                {
                    Codigo = viewmodel.Codigo,
                    Contato = viewmodel.Contato,
                    Atendente = viewmodel.Atendente,
                    Data = viewmodel.Data,
                    Departamento = viewmodel.Departamento,
                    EstadoAtendimento = viewmodel.EstadoAtendimento,
                    Login = viewmodel.Login
                };
                return bababa;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<ChatsDttoGet> ChatIsNull(DataAndType dados, AtendimentoDttoGet Item)
        {
            //se o chat da pessoa não existir no sistema esse metodo criara ele
            try
            {
                ChatsDttoPost ChatModel = new ChatsDttoPost
                {
                    CodigoAtendente = Item.Atendente == null ? null : Item.Atendente.Codigo,
                    CodigoAtendimento = Item.Codigo == null ? null : Item.Codigo,
                    CodigoContato = Item.Contato == null ? null : Item.Contato.Codigo,
                    CodigoLogin = Item.Login == null ? null : Item.Login.Codigo
                };
                return await _ChatsInterfaceServices.AdicionarPost(ChatModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<DataAndType?> ContatoIsBlock(DataAndType dados)
        {
            //metodo para enviar um alerta ao lead caso seu contato tenha sido bloqueado pelo client
            try
            {
                var responseObject = new
                {
                    messaging_product = "whatsapp",
                    recipient_type = "individual",
                    to = dados.Dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id,
                    type = "text",
                    text = new { preview_url = false, body = "Seu Contato Esta Bloqueado" }
                };
                DataAndType newmodel = new DataAndType
                {
                    Tipo = ETipoRetornoJson.TipoPost,
                    Dados = responseObject
                };
                return newmodel;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<DataAndType> MensageIsRepetead(DataAndType dados)
        {
            //metodo para analise feito para enviar um alarme em caso da mensagem ser repetida
            try
            {
                var responseObject = new
                {
                    messaging_product = "whatsapp",
                    recipient_type = "individual",
                    to = dados.Dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id,
                    type = "text",
                    text = new { preview_url = false, body = "Mensagem Repetida" }
                };
                DataAndType newmodel = new DataAndType
                {
                    Tipo = ETipoRetornoJson.TipoPost,
                    Dados = responseObject
                };
                return newmodel;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task SaveMensage(LoginDttoGet Login, ContatoDttoGet contato, ChatsDttoGet chat, string descricao)
        {
            //metodo feito apenas para salvar a mensagem recebida caso passe em todas as verificações iniciais
            try
            {
                MensagensDttoPost NewModel = new MensagensDttoPost
                {
                    CodigoLogin = Login.Codigo,
                    CodigoContato = contato.Codigo,
                    CodigoChat = chat.Codigo,
                    Data = DateTime.Now,
                    Descricao = descricao,
                    TipoDaMensagem = "MensagemEnviada"
                };
                await _MensagemInterfaceServices.AdicionarPost(NewModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool IsDifferenceLessThanFiveMinutes(long timestamp, DateTime dateTime)
        {
            // Converte o timestamp para DateTime em UTC
            DateTime dateTimeFromTimestamp = DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime;

            // Converte dateTime para UTC
            DateTime dateTimeInUtc = dateTime.ToUniversalTime();
            DateTime dateTimeFromTimestampToUtc = dateTimeFromTimestamp.ToUniversalTime();

            // Calcula a diferença entre as duas datas
            TimeSpan difference = dateTimeFromTimestampToUtc - dateTimeInUtc;

            // Verifica se a diferença é menor que 5 minutos
            return Math.Abs(difference.TotalMinutes) < 5;
        }
        public async Task<DataAndType> VerificaçõesIniciais(DataAndType dados)
        {

            try
            {
                //Pegando informações iniciais
                ContatoDttoGet contato = await _contatoInterfaceServices.RetornarConIdPorWaID(dados?.Dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id);
                LoginDttoGet Login = await _LoginInterfaceServices.RetornarLogIdPorWaID(dados?.Dados?.entry[0]?.changes[0]?.value?.metadata?.display_phone_number);
                AtendimentoDttoGet Item = await _AtendimentoInterfaceServices.ResgatarAtendimentoPorLogIdEContatoWaId(dados?.Dados?.entry[0].changes[0].value.contacts[0].wa_id, Login.Codigo);
                MensagensDttoGet mensagenPorContato = await _MensagemInterfaceServices.PegarUltimaMensagemDeUmContatoPorLogConWaIdEConWaId(dados?.Dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id, Login?.CodigoWhatsap);
                ChatsDttoGet chat = await _ChatsInterfaceServices.RetornarChatPorAtenId(Item != null ? Item.Codigo : 0);

                //checkando para ver se e necessario criar alguma dessas informações
                contato = contato == null ? contato = await ContatoIsNull(dados, Login) : contato;
                Item = Item == null ? await AtendimentoIsNull(dados, contato, Login) : Item;
                chat = chat == null ? await ChatIsNull(dados, Item) : chat;
                string descricao = dados.Tipo == ETipoRetornoJson.TipoSimples ? Convert.ToString(dados.Dados.entry[0].changes[0].value.messages[0].text.body) : Convert.ToString(dados.Dados.entry[0].changes[0].value.messages[0].interactive.list_reply.description);

                //verificar se o contato esta bloqueado antes de enviar alguma mensagem
                if (contato.BloqueadoStatus == true)
                {
                    return await ContatoIsBlock(dados);
                }
                
                //verficar se a mensagem e repetida 
                if (mensagenPorContato != null && IsDifferenceLessThanFiveMinutes(Convert.ToInt64(dados.Dados.entry[0].changes[0].value.messages[0].timestamp), Convert.ToDateTime(mensagenPorContato.Data)))
                {
                    if (mensagenPorContato.Descricao == descricao)
                    {
                        //desabilitei a funcao pela instablidade da meta depois vou ver tambem uma maneira melhor de identificar se a mensagem e repetida esse jeito e meio paia
                        //return await MensageIsRepetead(dados); esse metodo faz com que quando ele indetificar uma mensagemm repetida ele mandar diretamente no chat
                        throw new Exception("mensagem repetida");
                    }

                }

                //se tudo ocorrer bem salvar a mensagem e continuar
                await SaveMensage(Login, contato, chat, descricao);

                return dados;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu Algum Erro ao enviar a mensagem {ex.Message}");
            }
        }
    }
}
