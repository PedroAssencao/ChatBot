using Chatbot.API.DAL;
using Chatbot.API.Models;

namespace Chatbot.API.Repository
{
    public class menuRepository : BaseRepository<Menu>
    {
        public menuRepository(chatbotContext chatbotContext) : base(chatbotContext)
        {
        }
    }
}
