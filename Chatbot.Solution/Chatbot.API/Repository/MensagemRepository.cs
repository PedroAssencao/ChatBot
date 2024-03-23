using Chatbot.API.DAL;
using Chatbot.API.Models;

namespace Chatbot.API.Repository
{
    public class MensagemRepository : BaseRepository<Mensagen>
    {
        public MensagemRepository(chatbotContext chatbotContext) : base(chatbotContext)
        {
        }
    }
}
