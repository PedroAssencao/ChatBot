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
            try
            {
                if (waID == null)
                {
                    throw new Exception("informe um Id do whatsapp");
                }
                else
                {
                    var dados = await GetAll();
                    var ContatoEntity = dados.FirstOrDefault(x => x.ConWaId == waID);
                    return ContatoEntity;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ocorreu um error ao tentar fazer a requisição" + ex);
            }
 
        }
    }
}
