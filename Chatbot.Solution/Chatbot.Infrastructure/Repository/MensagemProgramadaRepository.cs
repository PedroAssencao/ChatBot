using Chatbot.API.DAL;
using Chatbot.API.Repository;
using Chatbot.Domain.Models;
using Chatbot.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Infrastructure.Repository
{
    public class MensagemProgramadaRepository : BaseRepository<MensagemProgramadum>, IMensagemProgramadaInterface
    {
        public MensagemProgramadaRepository(chatbotContext chatbotContext) : base(chatbotContext)
        {
        }

        public async Task<List<MensagemProgramadum>> GetALl() => await GetAll();
        public async Task<MensagemProgramadum> GetPorId(int id) => await GetPorID(id);
        public async Task<MensagemProgramadum> Create(MensagemProgramadum Model) => await Adicionar(Model);
        public async Task<MensagemProgramadum> update(MensagemProgramadum Model) => await Update(Model);
        public async Task<MensagemProgramadum> delete(int id) => await Delete(id);
    }

}

