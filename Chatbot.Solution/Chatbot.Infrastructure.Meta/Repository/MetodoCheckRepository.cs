using Chatbot.Domain.Models.Enums;
using Chatbot.Domain.Models.JsonMetaApi;
using Chatbot.Infrastructure.Meta.Repository.Interfaces;
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
        public DataAndType VerificarTipoDeRetorno(dynamic Values)
        {
            try
            {
                var dados = TipoMensagemSimples(Values);
                return dados;
            }
            catch (Exception)
            {
                try
                {
                    var dados = TipoMensagemMultiplaEscolha(Values);
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
        public DataAndType TipoMensagemMultiplaEscolha(dynamic Values)
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

        public DataAndType TipoMensagemSimples(dynamic Values)
        {
            try
            {
                var dados = JsonSerializer.Deserialize<recaiveMensagem.Root>(Values.ToString());
                if (dados.entry[0].changes[0].value.messages[0].text == null)
                {
                    throw new Exception("Metodo errado");
                }
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
