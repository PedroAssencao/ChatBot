using Chatbot.API.DAL;
using Chatbot.API.Models;

namespace Chatbot.API.Repository
{
    public class atendentesRepostiroy : BaseRepository<Atendente>
    {
        public atendentesRepostiroy(chatbotContext chatbotContext) : base(chatbotContext)
        {
        }
    }
}
