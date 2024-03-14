using Chatbot.API.DAL;
using Chatbot.API.Models;
using Chatbot.API.Repository;

namespace Chatbot.API.Services
{
    public class CadastroServies : CadastroRepository
    {
        public CadastroServies(chatbotContext chatbotContext) : base(chatbotContext)
        {
        }

        public async Task<Cadastro?> PegarTodosCadastros()
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

        public async Task<Cadastro?> AdicionarCadastro(Cadastro Model)
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

        public async Task<Cadastro?> AtualizarCadastro(Cadastro Model)
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
