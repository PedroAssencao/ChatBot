using Chatbot.API.DAL;
using Chatbot.API.Models;

namespace Chatbot.API.Repository
{
    public class DepartamentoRepository : BaseRepository<Departamento>
    {
        public DepartamentoRepository(chatbotContext chatbotContext) : base(chatbotContext)
        {
        }
    }
}
