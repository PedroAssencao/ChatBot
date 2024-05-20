using Chatbot.Domain.Models.JsonMetaApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Chatbot.Infrastructure.Meta.Repository.Interfaces
{
    public interface IMetodoCheck
    {
        DataAndType VerificarTipoDeRetorno(dynamic Values);
        DataAndType TipoMensagemSimples(dynamic Values);
        DataAndType TipoMensagemMultiplaEscolha(dynamic Values);
        DataAndType TipomensagemDeStatus(dynamic Model);
    }
}
