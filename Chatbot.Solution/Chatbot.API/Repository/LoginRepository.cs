using Chatbot.API.DAL;
using Chatbot.API.Models;

namespace Chatbot.API.Repository
{
    public class LoginRepository : BaseRepository<Login>
    {
        public LoginRepository(chatbotContext chatbotContext) : base(chatbotContext)
        {
        }
    }
}
