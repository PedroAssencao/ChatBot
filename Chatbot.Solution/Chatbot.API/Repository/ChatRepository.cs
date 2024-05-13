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
        public ChatRepository(chatbotContext chatbotContext, MensagemRepository mensagemRepository, atendentesRepostiroy atendentesRepository, ContatoRepository contatoRepository) : base(chatbotContext)
        {
            _mensagemRepository = mensagemRepository;
            _atendentesRepository = atendentesRepository;
            _contatoRepository = contatoRepository;
        }

        public async Task<List<ChatDttoGet>> BuscarChatsComObjetos()
        {
            var dados = await GetAll();
            List<ChatDttoGet> Lista = new List<ChatDttoGet>();
            foreach (var item in dados)
            {
                ChatDttoGet Model = new ChatDttoGet
                {
                    cha_id = item.ChaId,
                    Atendente = await _atendentesRepository.GetPorID(Convert.ToInt32(item.AteId)),
                    Contato = await _contatoRepository.GetPorID(Convert.ToInt32(item.ConId)),
                    Mensagens = await _mensagemRepository.GetAll()
                };
            }
            return Lista;
        }


    }
}
