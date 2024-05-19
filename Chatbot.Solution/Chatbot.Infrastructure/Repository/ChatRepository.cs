using Chatbot.API.DAL;
using Chatbot.API.Models;
using Chatbot.Infrastructure.Interfaces;

namespace Chatbot.API.Repository
{
    public class ChatRepository : BaseRepository<Chat>, IChatsInterface
    {
  
        public ChatRepository(chatbotContext chatbotContext) : base(chatbotContext)
        {
            
        }

        public async Task<List<Chat>> GetALl() => await GetAll();
        public async Task<Chat> GetPorId(int id) => await GetPorID(id);
        public async Task<Chat> Create(Chat Model) => await Adicionar(Model);
        public async Task<Chat> update(Chat Model) => await update(Model);
        public async Task<Chat> delete(int id) => await delete(id);



        //public async Task<List<Chat>> BuscarChatsComObjetos()
        //{
        //    var dados = await GetAll();
        //    List<Chat> Lista = new List<Chat>();
        //    foreach (var item in dados)
        //    {
        //        Chat Model = new Chat
        //        {
        //            ChaId = item.ChaId,
        //            AteId = item.AteId,
        //            ConId = item.ConId,
        //            LogId = item.LogId,
        //            Log = await _loginRepository.GetPorID(Convert.ToInt32(item.LogId)),
        //            Ate = await _atendentesRepository.GetPorID(Convert.ToInt32(item.AteId)),
        //            Con = await _contatoRepository.GetPorID(Convert.ToInt32(item.ConId)),
        //            Mensagens = await _mensagemRepository.RetornarMensagensPorChat(Convert.ToInt32(item.ChaId), Convert.ToInt32(item.LogId))
        //        };
        //        Lista.Add(Model);
        //    }
        //    return Lista;
        //}


        //public async Task<Chat?> BuscarChatPorId(int id)
        //{
        //    var dados = await BuscarChatsComObjetos();
        //    var listaFiltrada = dados.FirstOrDefault(x => x.ChaId == id);
        //    return listaFiltrada;
        //}

    }
}
