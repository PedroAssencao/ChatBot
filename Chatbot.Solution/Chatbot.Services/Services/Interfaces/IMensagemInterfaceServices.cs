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
        public Task<MensagensDttoGet?> BuscarMensagemPorWaId(string waID);
        public Task<MensagensDttoGet?> SaveMensage(int Login, int chat, string descricao);
        public Task SaveMensageWithCodigoWhatsappId(LoginDttoGet Login, ContatoDttoGet contato, ChatsDttoGet chat, string descricao, string CodigoWhatsapp);
    }
}
