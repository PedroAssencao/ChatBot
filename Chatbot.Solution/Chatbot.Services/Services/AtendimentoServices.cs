using Chatbot.Domain.Models;
using Chatbot.Infrastructure.Dtto;
using Chatbot.Infrastructure.Repository.Interfaces;
using Chatbot.Infrastructure.Services.Interfaces;
using Chatbot.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Services.Services
{
    public class AtendimentoServices : IAtendimentoInterfaceServices
    {
        protected readonly IAtendimentoInterface _repository;
        protected readonly IAtendenteInterfaceServices _Atendente;
        protected readonly ILoginInterfaceServices _login;
        protected readonly IContatoInterfaceServices _contato;
        protected readonly IDepartamentoInterfaceServices _departamento;

        public AtendimentoServices(IAtendimentoInterface repository, IAtendenteInterfaceServices atendente, ILoginInterfaceServices login, IContatoInterfaceServices contato, IDepartamentoInterfaceServices departamento)
        {
            _repository = repository;
            _Atendente = atendente;
            _login = login;
            _contato = contato;
            _departamento = departamento;
        }
        public async Task<List<AtendimentoDttoGet>> GetALl()
        {
            try
            {
                var dados = await _repository.GetALl();
                List<AtendimentoDttoGet> List = new List<AtendimentoDttoGet>();
                foreach (var item in dados)
                {
                    AtendimentoDttoGet ViewModel = new AtendimentoDttoGet
                    {
                        Codigo = item.AtenId,
                        Data = item.AtenData,
                        EstadoAtendimento = item.AtenEstado,
                        Atendente = item.AteId == null ? null : await _Atendente.GetPorId(Convert.ToInt32(item.AteId)),
                        Contato = item.ConId == null ? null : await _contato.GetContatoForViewPorId(Convert.ToInt32(item.ConId)),
                        Departamento = item.DepId == null ? null : await _departamento.GetPorId(Convert.ToInt32(item.DepId)),
                        Login = item.LogId == null ? null : await _login.GetPorIdLoginView(Convert.ToInt32(item.LogId))
                    };
                    List.Add(ViewModel);
                }
                return List;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AtualizarAtendimentoComDttoDeGet(AtendimentoDttoGet Atendimento)
        {
            try
            {
                AtendimentoDttoPut NewModel = new AtendimentoDttoPut
                {
                    Codigo = Atendimento.Codigo,
                    CodigoAtendente = null,
                    CodigoDepartamento = null,
                    Data = DateTime.Now,
                    EstadoAtendimento = null,
                    CodigoContato = Atendimento.Contato.Codigo,
                    CodigoLogin = Atendimento.Login.Codigo
                };
                await AtualizarPut(NewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AtendimentoDttoGet> GetPorId(int id)
        {
            try
            {
                var item = await _repository.GetPorId(id);
                AtendimentoDttoGet ViewModel = new AtendimentoDttoGet
                {
                    Codigo = item.AtenId,
                    Data = item.AtenData,
                    EstadoAtendimento = item.AtenEstado,
                    Atendente = item.AteId == null ? null : await _Atendente.GetPorId(Convert.ToInt32(item.AteId)),
                    Contato = item.ConId == null ? null : await _contato.GetContatoForViewPorId(Convert.ToInt32(item.ConId)),
                    Departamento = item.DepId == null ? null : await _departamento.GetPorId(Convert.ToInt32(item.DepId)),
                    Login = item.LogId == null ? null : await _login.GetPorIdLoginView(Convert.ToInt32(item.LogId))
                };
                return ViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<AtendimentoDttoGet>> RetornarTodosAtendimentosPorLogId(int id)
        {
            try
            {
                var dados = await _repository.GetALl();
                var dadosFiltrados = dados.Where(x => x.LogId == id).ToList();
                List<AtendimentoDttoGet> List = new List<AtendimentoDttoGet>();
                foreach (var item in dadosFiltrados)
                {
                    AtendimentoDttoGet ViewModel = new AtendimentoDttoGet
                    {
                        Codigo = item.AtenId,
                        Data = item.AtenData,
                        EstadoAtendimento = item.AtenEstado,
                        Atendente = item.AteId == null ? null : await _Atendente.GetPorId(Convert.ToInt32(item.AteId)),
                        Contato = item.ConId == null ? null : await _contato.GetContatoForViewPorId(Convert.ToInt32(item.ConId)),
                        Departamento = item.DepId == null ? null : await _departamento.GetPorId(Convert.ToInt32(item.DepId)),
                        Login = item.LogId == null ? null : await _login.GetPorIdLoginView(Convert.ToInt32(item.LogId))
                    };
                    List.Add(ViewModel);
                }
                return List;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AtendimentoDttoGet> AtendimentoExiste(LoginDttoGet login, ContatoDttoGet contato)
        {
            try
            {
                var dados = await GetALl();
                return dados.Where(x => x.EstadoAtendimento == null || x.EstadoAtendimento.Trim().ToLower() == "Finalizado".Trim().ToLower() || x.EstadoAtendimento.Trim().ToLower() == "GPT".Trim().ToLower() || x.EstadoAtendimento.Trim().ToLower() == "HUMANO".Trim().ToLower()).FirstOrDefault(x => x.Contato.Codigo == contato.Codigo && x.Login.Codigo == login.Codigo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AtendimentoDttoGet> AdicionarPost(AtendimentoDttoPost Model)
        {
            try
            {
                Atendimento NewModel = new Atendimento
                {
                    AtenData = Model.Data,
                    AtenEstado = Model.EstadoAtendimento,
                    LogId = Model.CodigoLogin,
                    ConId = Model.CodigoContato,
                    DepId = Model.CodigoDepartamento,
                    AteId = Model.CodigoAtendente
                };

                var item = await _repository.Adicionar(NewModel);

                AtendimentoDttoGet ViewModel = new AtendimentoDttoGet
                {
                    Codigo = item.AtenId,
                    Data = item.AtenData,
                    EstadoAtendimento = item.AtenEstado,
                    Atendente = item.AteId == null ? null : await _Atendente.GetPorId(Convert.ToInt32(item.AteId)),
                    Contato = item.ConId == null ? null : await _contato.GetContatoForViewPorId(Convert.ToInt32(item.ConId)),
                    Departamento = item.DepId == null ? null : await _departamento.GetPorId(Convert.ToInt32(item.DepId)),
                    Login = item.LogId == null ? null : await _login.GetPorIdLoginView(Convert.ToInt32(item.LogId))
                };
                return ViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AtendimentoDttoGet> AtualizarPut(AtendimentoDttoPut Model)
        {
            try
            {
                Atendimento NewModel = new Atendimento
                {
                    AtenId = Model.Codigo,
                    AtenData = Model.Data,
                    AtenEstado = Model.EstadoAtendimento,
                    LogId = Model.CodigoLogin,
                    ConId = Model.CodigoContato,
                    DepId = Model.CodigoDepartamento,
                    AteId = Model.CodigoAtendente == null ? null : Convert.ToInt32(Model.CodigoAtendente)
                };
                var item = await _repository.update(NewModel);
                AtendimentoDttoGet ViewModel = new AtendimentoDttoGet
                {
                    Codigo = item.AtenId,
                    Data = item.AtenData,
                    EstadoAtendimento = item.AtenEstado,
                    Atendente = item.AteId == null ? null : await _Atendente.GetPorId(Convert.ToInt32(item.AteId)),
                    Contato = item.ConId == null ? null : await _contato.GetContatoForViewPorId(Convert.ToInt32(item.ConId)),
                    Departamento = item.DepId == null ? null : await _departamento.GetPorId(Convert.ToInt32(item.DepId)),
                    Login = item.LogId == null ? null : await _login.GetPorIdLoginView(Convert.ToInt32(item.LogId))
                };
                return ViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AtendimentoDttoGet?> ResgatarAtendimentoPorLogIdEContatoWaId(string ConWaId, int LogId)
        {
            try
            {
                var TodosAtendimentosPorLogin = await RetornarTodosAtendimentosPorLogId(LogId);
                var item = TodosAtendimentosPorLogin.FirstOrDefault(x => x?.Contato?.CodigoWhatsapp == ConWaId && x?.Login?.Codigo == LogId);
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        

        public async Task<AtendimentoDttoGet> Delete(int id)
        {
            try
            {
                var item = await _repository.delete(id);
                AtendimentoDttoGet ViewModel = new AtendimentoDttoGet
                {
                    Codigo = item.AtenId,
                    Data = item.AtenData,
                    EstadoAtendimento = item.AtenEstado,
                    Atendente = await _Atendente.GetPorId(Convert.ToInt32(item.AteId)),
                    Contato = await _contato.GetContatoForViewPorId(Convert.ToInt32(item.ConId)),
                    Departamento = await _departamento.GetPorId(Convert.ToInt32(item.DepId)),
                    Login = await _login.GetPorIdLoginView(Convert.ToInt32(item.LogId))
                };
                return ViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodos Não utilizados
        public Task<AtendimentoDttoGet> Create(AtendimentoDttoGet Model)
        {
            throw new NotImplementedException();
        }

        public Task<AtendimentoDttoGet> Update(AtendimentoDttoGet Model)
        {
            throw new NotImplementedException();
        }

    }
}
