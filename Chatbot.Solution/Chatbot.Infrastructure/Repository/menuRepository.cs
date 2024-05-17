using Chatbot.API.DAL;
using Chatbot.API.Models;

namespace Chatbot.API.Repository
{
    public class menuRepository : BaseRepository<Menu>
    {
        public menuRepository(chatbotContext chatbotContext) : base(chatbotContext)
        {
        }

        public async Task<List<Menu>> PegarTodosOsMenusPorLogID(int log)
        {
            try
            {
                var ListaMenus = await GetAll();
                var ListaMenusFiltrada = ListaMenus.FindAll(x => x.LogId == log);
                return ListaMenusFiltrada;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<Menu> PegarMenuPorLogIDEMenuInicial(int log)
        {
            try
            {
                var ListaMenus = await GetAll();
                var ListaMenusFiltrada = ListaMenus.FirstOrDefault(x => x.LogId == log && x.MenTipo == "PrimeiraMensagem");
                return ListaMenusFiltrada;
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
