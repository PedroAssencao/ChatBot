using Chatbot.API.DAL;
using Chatbot.API.Models;
using Chatbot.Infrastructure.Repository.Interfaces;

namespace Chatbot.API.Repository
{
    public class AtendimentoRepository : BaseRepository<Atendimento>, IAtendimentoInterface
    {
        protected readonly LoginRepository _loginRepository;
        protected readonly ContatoRepository _contatoRepository;
        protected readonly DepartamentoRepository _departamentoRepository;
        protected readonly atendentesRepostiroy _atendentesRepostiroy;

        public AtendimentoRepository(chatbotContext chatbotContext, LoginRepository loginRepository, ContatoRepository contatoRepository, DepartamentoRepository departamentoRepository, atendentesRepostiroy atendentesRepostiroy) : base(chatbotContext)
        {
            _loginRepository = loginRepository;
            _contatoRepository = contatoRepository;
            _departamentoRepository = departamentoRepository;
            _atendentesRepostiroy = atendentesRepostiroy;
        }

        public async Task<List<Atendimento>> AtendimentoComObjetos()
        {
            try
            {
                List<Atendimento> ListaComObjetos = new List<Atendimento>();

                var BuscarTodos = await GetAll();

                foreach (var item in BuscarTodos)
                {
                    Atendimento NovoAtendimento = new Atendimento
                    {
                        AtenId = item.AtenId,
                        AtenData = item.AtenData,
                        AtenEstado = item.AtenEstado,
                        Ate = await _atendentesRepostiroy.GetPorID(Convert.ToInt32(item.AteId)),
                        Log = await _loginRepository.GetPorID(Convert.ToInt32(item.LogId)),
                        Con = await _contatoRepository.GetPorID(Convert.ToInt32(item.ConId)),
                        Dep = await _departamentoRepository.GetPorID(Convert.ToInt32(item.DepId)),
                    };
                    ListaComObjetos.Add(NovoAtendimento);
                }

                return ListaComObjetos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um error ao tentar buscar Atendimentos" + ex);
            }
       
        }

        public async Task<List<Atendimento>> BuscarTodosAtendimentosPorLogId(int logid)
        {
            try
            {
                var TodosAtendimentos = await AtendimentoComObjetos();
                var AtendimentosFiltrados = TodosAtendimentos.Where(x => x?.Log?.LogId == logid).ToList();
                return AtendimentosFiltrados;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<List<Atendimento>> GetALl() => await GetAll();
        public async Task<Atendimento> GetPorId(int id) => await GetPorID(id);
        public async Task<Atendimento> Create(Atendimento Model) => await Adicionar(Model);
        public async Task<Atendimento> update(Atendimento Model) => await Update(Model);
        public async Task<Atendimento> delete(int id) => await Delete(id);
    }
}
