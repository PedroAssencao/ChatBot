using Chatbot.API.DAL;
using Chatbot.API.Models;

namespace Chatbot.API.Repository
{
    public class LoginRepository : BaseRepository<Login>
    {
        public LoginRepository(chatbotContext chatbotContext) : base(chatbotContext)
        {
        }

        public async Task<Login?> RetornarLogIdPorWaID(string waID)
        {
            try
            {
                if (waID == null)
                {
                    throw new Exception("Informe um Whatsapp Id");
                }
                else
                {
                    var dados = await GetAll();
                    var LoginEntity = dados.FirstOrDefault(x => x.LogWaid == waID);
                    return LoginEntity;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
   
        }
    }
}
