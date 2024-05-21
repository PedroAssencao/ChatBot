using Chatbot.Domain.Models.Enums;
using Chatbot.Domain.Models.JsonMetaApi;
using Chatbot.Infrastructure.Dtto;
using Chatbot.Infrastructure.Meta.Repository.Interfaces;
using Chatbot.Infrastructure.Services.Interfaces;
using Chatbot.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
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
        public MetodoCheckRepository(IContatoInterfaceServices contatoInterfaceServices, IMensagemInterfaceServices mensagemInterfaceServices, ILoginInterfaceServices loginInterfaceServices, IAtendimentoInterfaceServices atendimentoInterfaceServices)
        {
            _contatoInterfaceServices = contatoInterfaceServices;
            _MensagemInterfaceServices = mensagemInterfaceServices;
            _LoginInterfaceServices = loginInterfaceServices;
            _AtendimentoInterfaceServices = atendimentoInterfaceServices;
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
                return Model;
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
                var contato = await _contatoInterfaceServices.RetornarConIdPorWaID(dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id);
                var Login = await _LoginInterfaceServices.RetornarLogIdPorWaID(dados?.entry[0]?.changes[0]?.value?.metadata?.display_phone_number);
                var Mensagens = await _MensagemInterfaceServices.GetALl();
                if (contato == null)
                {
                    ContatoDttoGet newModel = new ContatoDttoGet
                    {
                        CodigoWhatsapp = dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id,
                        DataCadastro = DateTime.Now,
                        BloqueadoStatus = false,
                        Nome = dados?.entry[0]?.changes[0]?.value?.contacts[0].profile[0].name,
                        Codigologin = Login.Codigo

                    };
                    contato = newModel;
                    await _contatoInterfaceServices.Create(newModel);
                }

                if (contato.BloqueadoStatus == true)
                {
                    var responseObject = new
                    {
                        messaging_product = "whatsapp",
                        recipient_type = "individual",
                        to = dados?.entry[0]?.changes[0]?.value?.contacts[0].wa_id,
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
                if (Mensagens.LastOrDefault(x => x.Descricao == dados.entry[0].changes[0].value.messages[0].text).Descricao == dados.entry[0].changes[0].value.messages[0].text)
                {
                    throw new Exception("Mensagem Repetida");
                }
                else
                {
                    MensagensDttoPost NewModel = new MensagensDttoPost
                    {
                        CodigoLogin = Login.Codigo,
                        CodigoContato = contato.Codigo,
                        CodigoChat = 1,
                        Data = DateTime.Now,
                        Descricao = dados.entry[0].changes[0].value.messages[0].text,
                        TipoDaMensagem = "MensagemEnviada"
                    };
                    await _MensagemInterfaceServices.AdicionarPost(NewModel);
                }
                var mensagen = await _MensagemInterfaceServices.GetALl();
                DataAndType Model = new DataAndType
                {
                    Tipo = ETipoRetornoJson.TipoSimples,
                    Dados = dados
                };
                return Model;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
