using Chatbot.API.DAL;
using Chatbot.API.Models;
using Chatbot.Infrastructure.Repository.Interfaces;

namespace Chatbot.API.Repository
{
    public class ContatoRepository : BaseRepository<Contato>, IContatosInterface
    {
        public ContatoRepository(chatbotContext chatbotContext) : base(chatbotContext)
        {
        }

        public async Task<List<Contato>> GetALl() => await GetAll();
        public async Task<Contato> GetPorId(int id) => await GetPorID(id);
        public async Task<Contato> Create(Contato Model) => await Create(Model);
        public async Task<Contato> update(Contato Model) => await Update(Model);
        public async Task<Contato> delete(int id) => await Delete(id);
    }
}
