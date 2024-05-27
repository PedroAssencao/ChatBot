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

        public async Task<DataAndType> VerificaçõesIniciais(DataAndType dados)
        {

            try
            {
                //transformar em metodo - start
                ContatoDttoGet contato = await _contatoInterfaceServices.RetornarConIdPorWaID(dados?.Dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id);
                LoginDttoGet Login = await _LoginInterfaceServices.RetornarLogIdPorWaID(dados?.Dados?.entry[0]?.changes[0]?.value?.metadata?.display_phone_number);
                List<MensagensDttoGet> Mensagens = await _MensagemInterfaceServices.GetALl();
                List<AtendimentoDttoGet> dadosAtendimento = await _AtendimentoInterfaceServices.GetALl();
                List<ChatsDttoGet> Chats = await _ChatsInterfaceServices.GetALl();
                AtendimentoDttoGet Item = dadosAtendimento.FirstOrDefault(x => x?.Contato?.CodigoWhatsapp == dados.Dados?.entry[0].changes[0].value.contacts[0].wa_id && x?.Login?.Codigo == Login?.Codigo);
                AtendimentoDttoGet newItem = new AtendimentoDttoGet();
                ChatsDttoGet newChat = new ChatsDttoGet();
                if (contato == null)
                {
                    ContatoDttoGet newModel = new ContatoDttoGet
                    {
                        CodigoWhatsapp = dados.Dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id,
                        DataCadastro = DateTime.Now,
                        BloqueadoStatus = false,
                        Nome = dados.Dados?.entry[0]?.changes[0]?.value?.contacts[0].profile.name,
                        Codigologin = Login.Codigo

                    };
                    var viewmodel = await _contatoInterfaceServices.Create(newModel);
                    ContatoDttoGet bababa = new ContatoDttoGet
                    {
                        Codigo = viewmodel.Codigo,
                        Codigologin = viewmodel.Codigologin,
                        CodigoWhatsapp = viewmodel.CodigoWhatsapp,
                        BloqueadoStatus = viewmodel.BloqueadoStatus,
                        DataCadastro = viewmodel.DataCadastro,
                        Nome = viewmodel.Nome,
                    };
                    contato = bababa;
                }

                if (Item == null)
                {
                    AtendimentoDttoPost NovoAtendimento = new AtendimentoDttoPost
                    {
                        EstadoAtendimento = "Bot",
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
                    newItem = bababa;

                }

                var chatExiste = Chats.FirstOrDefault(x => x?.Atendimento?.Codigo == newItem.Codigo);

                if (chatExiste == null)
                {
                    if (Item == null)
                    {
                        Item = newItem;
                    }
                    ChatsDttoPost ChatModel = new ChatsDttoPost
                    {
                        CodigoAtendente = Item.Atendente == null ? null : Item.Atendente.Codigo,
                        CodigoAtendimento = Item.Codigo == null ? null : Item.Codigo,
                        CodigoContato = Item.Contato == null ? null : Item.Contato.Codigo,
                        CodigoLogin = Item.Login == null ? null : Item.Login.Codigo
                    };
                    var ChatPostModel = await _ChatsInterfaceServices.AdicionarPost(ChatModel);
                    newChat = ChatPostModel;
                }
                else
                {
                    newChat = chatExiste;
                }

                var mensagenPorContato = Mensagens.LastOrDefault(x => x.Contato?.CodigoWhatsapp == Convert.ToString(dados.Dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id) &&
                    x?.Login?.CodigoWhatsapp == Login?.CodigoWhatsap && x?.TipoDaMensagem == nameof(ETipos.MensagemEnviada));

                if (contato.BloqueadoStatus == true)
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
                if (mensagenPorContato != null)
                {
                    var descricao = dados.Tipo == ETipoRetornoJson.TipoSimples ? Convert.ToString(dados.Dados.entry[0].changes[0].value.messages[0].text.body) : Convert.ToString(dados.Dados.entry[0].changes[0].value.messages[0].interactive.list_reply.description);
                    if (mensagenPorContato.Descricao == descricao)
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
                    else
                    {
                        MensagensDttoPost NewModel = new MensagensDttoPost
                        {
                            CodigoLogin = Login.Codigo,
                            CodigoContato = contato.Codigo,
                            CodigoChat = newChat.Codigo,
                            Data = DateTime.Now,
                            Descricao = descricao,
                            TipoDaMensagem = "MensagemEnviada"
                        };
                        await _MensagemInterfaceServices.AdicionarPost(NewModel);
                    }
                }
                else
                {
                    MensagensDttoPost NewModel = new MensagensDttoPost
                    {
                        CodigoLogin = Login.Codigo,
                        CodigoContato = contato.Codigo,
                        CodigoChat = newChat.Codigo,
                        Data = DateTime.Now,
                        Descricao = Convert.ToString(dados.Dados.entry[0].changes[0].value.messages[0].text.body),
                        TipoDaMensagem = "MensagemEnviada"
                    };
                    await _MensagemInterfaceServices.AdicionarPost(NewModel);
                }

                if (Item?.EstadoAtendimento == "Bot")
                {
                    return dados;
                }

                if (Item?.EstadoAtendimento == "Finalizado")
                {
                    AtendimentoDttoPut NewModel = new AtendimentoDttoPut
                    {
                        Codigo = Item.Codigo,
                        EstadoAtendimento = "Bot",
                        Data = DateTime.Now,
                        CodigoAtendente = null,
                        CodigoDepartamento = null,
                        CodigoLogin = Convert.ToInt32(Item?.Login?.Codigo),
                        CodigoContato = Convert.ToInt32(Item?.Contato?.Codigo),
                    };
                    var viewmodel = await _AtendimentoInterfaceServices.AtualizarPut(NewModel);
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
                }

                return dados;

                //transformar em metodo - end
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
