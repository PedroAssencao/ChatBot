using Chatbot.API.DAL;
using Chatbot.API.Models;
using System.Linq;

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

        /*Arrumar o Repositorio de Mensagens*/

        public async Task<List<Mensagen>> ListaComObjetos()
        {
            try
            {
                var listaMensagens = await GetAll();
                List<Mensagen> ListaComObjetos = new List<Mensagen>();

                foreach (var item in listaMensagens)
                {
                    Mensagen teste2 = new Mensagen
                    {
                        MensId = item.MensId,
                        MensDescricao = item.MensDescricao,
                        MensData = Convert.ToDateTime(item.MensData),
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
            catch (Exception ex)
            {
                throw new Exception("Error ao carregar a lista de mensagens error: " + ex);
            }

        }

        public async Task<List<Mensagen>> RetornarMensagensPorConIdELogId(int con, int log)
        {
            try
            {
                var listaMensagens = await ListaComObjetos();
                var MensagensFiltradas = listaMensagens.Where(x => x.ConId == con && x.LogId == log && x.MenTipo == "MensagenEnviada").ToList();
                return MensagensFiltradas;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
    

}
