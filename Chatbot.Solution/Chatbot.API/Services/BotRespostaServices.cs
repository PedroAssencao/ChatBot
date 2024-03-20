using Chatbot.API.DAL;
using Chatbot.API.Models;
using Chatbot.API.Repository;

namespace Chatbot.API.Services
{
    public class BotRespostaServices : BotRespostaRepository
    {
        public BotRespostaServices(chatbotContext chatbotContext) : base(chatbotContext)
        {
        }


        public async Task<List<BoTrespostum>?> PegarTodosBotResposta()
        {
            dynamic? dados = null;

            try
            {
                dados = await GetAll();
            }
            catch (Exception)
            {
                dados = null;
            }

            return dados;
        }

        public async Task<BoTrespostum?> AdicionarBotResposta(BoTrespostum Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new Exception("Dados Vazios Ou Incompletos");
                }

                await Adicionar(Model);
                return Model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BoTrespostum?> AtualizarBoTrespostum(BoTrespostum? Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new Exception("Dados Vazios Ou Incompletos");
                }

                await Update(Model);
                return Model;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
