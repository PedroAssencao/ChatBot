using Chatbot.Infrastructure.Dtto;
using Chatbot.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Services.Services.Interfaces
{
    public interface IMensagemInterfaceServices : IBaseInterfaceServices<MensagensDttoGet>
    {
        Task<List<MensagensDttoGetForView>> BuscarMensagensDeUmChat(int con, int log);
        Task<MensagensDttoGet> AdicionarPost(MensagensDttoPost Model);
        Task<MensagensDttoGet> AtualizarPut(MensagensDttoPut Model);
        public Task<MensagensDttoGet?> PegarUltimaMensagemDeUmContatoPorLogConWaIdEConWaId(string ConWaID, string LogConWaID);
    }
}
