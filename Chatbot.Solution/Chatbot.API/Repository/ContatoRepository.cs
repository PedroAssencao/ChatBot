using Chatbot.API.DAL;
using Chatbot.API.Models;

namespace Chatbot.API.Repository
{
    public class ContatoRepository : BaseRepository<Contato>
    {
        public ContatoRepository(chatbotContext chatbotContext) : base(chatbotContext)
        {
        }

        public async Task<Contato?> RetornarConIdPorWaID(string waID)
        {
            var dados = await GetAll();
            var ContatoEntity = dados.FirstOrDefault(x => x.ConWaId == waID);
            return ContatoEntity;
        }
    }
}
