using Azure.Core;
using Chatbot.Domain.Models;
using Chatbot.Domain.Models.Enums;
using Chatbot.Domain.Models.JsonMetaApi;
using Chatbot.Infrastructure.Dtto;
using Chatbot.Infrastructure.Meta.Repository.Interfaces;
using Chatbot.Infrastructure.Services.Interfaces;
using Chatbot.Services.Services.Interfaces;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
        public async Task<DataAndType> VerificaçõesIniciais(DataAndType dados)
        {

            try
            {
                ContatoDttoGet contato = await _contatoInterfaceServices.RetornarConIdPorWaID(dados?.Dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id);
                LoginDttoGet Login = await _LoginInterfaceServices.RetornarLogIdPorWaID(dados?.Dados?.entry[0]?.changes[0]?.value?.metadata?.display_phone_number);
                AtendimentoDttoGet Item = await _AtendimentoInterfaceServices.ResgatarAtendimentoPorLogIdEContatoWaId(dados?.Dados?.entry[0].changes[0].value.contacts[0].wa_id, Login.Codigo);
                MensagensDttoGet mensagenPorContato = await _MensagemInterfaceServices.PegarUltimaMensagemDeUmContatoPorLogConWaIdEConWaId(dados?.Dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id, Login?.CodigoWhatsap);
                ChatsDttoGet chat = await _ChatsInterfaceServices.RetornarChatPorAtenId(Item.Codigo);
                contato = contato == null ? contato = await ContatoIsNull(dados, Login) : contato;
                Item = Item == null ? await AtendimentoIsNull(dados, contato, Login) : Item;
                chat = chat == null ? await ChatIsNull(dados, Item) : chat;
                string descricao = dados.Tipo == ETipoRetornoJson.TipoSimples ? Convert.ToString(dados.Dados.entry[0].changes[0].value.messages[0].text.body) : Convert.ToString(dados.Dados.entry[0].changes[0].value.messages[0].interactive.list_reply.description);

                if (contato.BloqueadoStatus == true)
                {
                    return await ContatoIsBlock(dados);
                }

                if (mensagenPorContato != null && mensagenPorContato.Descricao == descricao)
                {
                    //desabilitei a funcao pela instablidade da meta depois vou ver tambem uma maneira melhor de identificar se a mensagem e repetida esse jeito e meio paia
                    //return await MensageIsRepetead(dados);
                    throw new Exception("mensagem repetida");
                }

                await SaveMensage(Login, contato, chat, descricao);

                return dados;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
