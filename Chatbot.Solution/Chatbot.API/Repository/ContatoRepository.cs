using Chatbot.API.DAL;
using Chatbot.API.Models;

namespace Chatbot.API.Repository
{
    public class ContatoRepository : BaseRepository<Contato>
    {
        public ContatoRepository(chatbotContext chatbotContext) : base(chatbotContext)
        {
        }
    }
}
