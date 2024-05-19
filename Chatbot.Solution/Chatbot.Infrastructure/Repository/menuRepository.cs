using Chatbot.API.DAL;
using Chatbot.API.Models;
using Chatbot.Infrastructure.Repository.Interfaces;

namespace Chatbot.API.Repository
{
    public class menuRepository : BaseRepository<Menu>, IMenuInterface
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


        public async Task<List<Menu>> GetALl() => await GetAll();
        public async Task<Menu> GetPorId(int id) => await GetPorID(id);
        public async Task<Menu> Create(Menu Model) => await Create(Model);
        public async Task<Menu> update(Menu Model) => await Update(Model);
        public async Task<Menu> delete(int id) => await Delete(id);
    }
}
