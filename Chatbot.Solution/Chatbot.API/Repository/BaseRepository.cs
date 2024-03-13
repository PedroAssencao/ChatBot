using Chatbot.API.DAL;
using Microsoft.EntityFrameworkCore;

namespace Chatbot.API.Repository
{
    public class BaseRepository<T> where T : class
    {
        private readonly chatbotContext _chatbotContext;
        public BaseRepository(chatbotContext chatbotContext)
        {
            _chatbotContext = chatbotContext;
        }

        public async Task<List<T>> GetAll() 
        {
            dynamic dados = null;

            try
            {
                dados = await _chatbotContext.Set<T>().ToListAsync();
            }
            catch (Exception)
            {
                dados = null;
            }

            return dados;

        }

        public async Task<T> Adicionar(T Model) 
        {
            await _chatbotContext.AddAsync(Model);
            await _chatbotContext.SaveChangesAsync();
            return Model;
        }

        public async Task<T> Update(T model)
        {
            _chatbotContext.Update(model);
            await _chatbotContext.SaveChangesAsync();
            return model;
        }

    }
}
