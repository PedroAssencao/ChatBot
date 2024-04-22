using Chatbot.API.DAL;
using Chatbot.API.Models;

namespace Chatbot.API.Repository
{
    public class optionsRepository : BaseRepository<Option>
    {
        protected readonly menuRepository _menuRepository;
        protected readonly MensagemRepository _mensagenRepository;
        protected readonly LoginRepository _loginRepository;
        public optionsRepository(chatbotContext chatbotContext, menuRepository menuRepository, MensagemRepository mensagenRepository, LoginRepository loginRepository) : base(chatbotContext)
        {
            _menuRepository = menuRepository;
            _mensagenRepository = mensagenRepository;
            _loginRepository = loginRepository;
        }

        public async Task<List<Option>> RetonarOptionComMenu()
        {
            try
            {
                var dados = await GetAll();
                List<Option> ListaComObjetos = new List<Option>();
                foreach (var item in dados)
                {
                    Option option = new Option
                    {
                        OptId = item.OptId,
                        MenId = item.MenId,
                        MensId = item.MensId,
                        LogId = item.LogId,
                        Mens = await _mensagenRepository.GetPorID(Convert.ToInt32(item.MensId)),
                        Men = await _menuRepository.GetPorID(Convert.ToInt32(item.MenId)),
                        Log = await _loginRepository.GetPorID(Convert.ToInt32(item.LogId)),
                    };
                    ListaComObjetos.Add(option);
                }

                return ListaComObjetos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um error ao tentar formar lista error: " + ex); 
            }
         
        }

        public async Task<List<Option>> RetornarTodasASOptionPorLOgId(int log)
        {
            try
            {
                var lista = await RetonarOptionComMenu();
                var ListaFiltrada = lista.FindAll(x => x.LogId == log);
                return ListaFiltrada;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Option> CriarOptionsPassandoMensagem(Mensagen Mensagem, Option Model)
        {
            try
            {
                await _mensagenRepository.Adicionar(Mensagem);
                await Adicionar(Model);
                return Model;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
