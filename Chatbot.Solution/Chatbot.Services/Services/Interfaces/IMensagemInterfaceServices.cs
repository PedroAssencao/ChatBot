using Chatbot.Infrastructure.Dtto;
using Chatbot.Infrastructure.Services.Interfaces;

namespace Chatbot.Services.Services.Interfaces
{
    public interface IMensagemInterfaceServices : IBaseInterfaceServices<MensagensDttoGet>
    {
        Task<List<MensagensDttoGetForView>> BuscarMensagensDeUmChat(int con, int log);
        Task<MensagensDttoGet> AdicionarPost(MensagensDttoPost Model);
        Task<MensagensDttoGet> AtualizarPut(MensagensDttoPut Model);
        public Task<MensagensDttoGet?> PegarUltimaMensagemDeUmContatoPorLogConWaIdEConWaId(string ConWaID, string LogConWaID);
        public Task<MensagensDttoGet?> BuscarMensagemPorWaId(string waID);
        public Task SaveMensage(int Login, int chat, string descricao);
        public Task<MensagensDttoGetForView> SaveMensageWithCodigoWhatsappId(LoginDttoGet Login, ContatoDttoGet contato, ChatsDttoGet chat, string descricao, string CodigoWhatsapp);
    }
}
