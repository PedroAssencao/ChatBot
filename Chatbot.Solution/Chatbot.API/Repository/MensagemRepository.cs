using Chatbot.API.DAL;
using Chatbot.API.Dttos;
using Chatbot.API.Models;

namespace Chatbot.API.Repository
{
    public class MensagemRepository : BaseRepository<Mensagen>
    {
        protected readonly LoginRepository _LoginRepository;
        protected readonly ContatoRepository _ContatoRepository;

        public MensagemRepository(chatbotContext chatbotContext, LoginRepository login, ContatoRepository contato) : base(chatbotContext)
        {
            _LoginRepository = login;
            _ContatoRepository = contato;
        }
        public async Task<List<Mensagen>> ListaComObjetos()
        {

            var listaMensagens = await GetAll();
            List<Mensagen> ListaComObjetos = new List<Mensagen>();

            foreach (var item in listaMensagens)
            {
                Mensagen teste2 = new Mensagen
                {
                    MenId = item.MenId,
                    MenDescricao = item.MenDescricao,
                    MenResposta = item.MenResposta,
                    MenTitle = item.MenTitle,
                    MenData = Convert.ToDateTime(item.MenData),
                    MenTipo = item.MenTipo,
                    LogId = item.LogId,
                    ConId = item.ConId,
                    Log = await _LoginRepository.GetPorID(Convert.ToInt32(item.LogId)),
                    Con = await _ContatoRepository.GetPorID(Convert.ToInt32(item.ConId))
                };
                ListaComObjetos.Add(teste2);
            }

            return ListaComObjetos;

        }
    }
    

}
