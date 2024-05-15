using Chatbot.API.DAL;
using Chatbot.API.Dtto;
using Chatbot.API.Models;

namespace Chatbot.API.Repository
{
    public class ChatRepository : BaseRepository<Chat>
    {
        protected readonly MensagemRepository _mensagemRepository;
        protected readonly atendentesRepostiroy _atendentesRepository;
        protected readonly ContatoRepository _contatoRepository;
        protected readonly LoginRepository _loginRepository;
        public ChatRepository(chatbotContext chatbotContext, MensagemRepository mensagemRepository, atendentesRepostiroy atendentesRepository, ContatoRepository contatoRepository, LoginRepository loginRepository) : base(chatbotContext)
        {
            _mensagemRepository = mensagemRepository;
            _atendentesRepository = atendentesRepository;
            _contatoRepository = contatoRepository;
            _loginRepository = loginRepository;
        }

        public async Task<List<Chat>> BuscarChatsComObjetos()
        {
            var dados = await GetAll();
            List<Chat> Lista = new List<Chat>();
            foreach (var item in dados)
            {
                Chat Model = new Chat
                {
                    ChaId = item.ChaId,
                    AteId = item.AteId,
                    ConId = item.ConId,
                    LogId = item.LogId,
                    Log = await _loginRepository.GetPorID(Convert.ToInt32(item.LogId)),
                    Ate = await _atendentesRepository.GetPorID(Convert.ToInt32(item.AteId)),
                    Con = await _contatoRepository.GetPorID(Convert.ToInt32(item.ConId)),
                    Mensagens = await _mensagemRepository.RetornarMensagensPorChat(Convert.ToInt32(item.ChaId), Convert.ToInt32(item.LogId))
                };
                Lista.Add(Model);
            }
            return Lista;
        }


    }
}
