using Chatbot.Domain.Models;
using Chatbot.Infrastructure.Dtto;
using Chatbot.Infrastructure.Repository.Interfaces;
using Chatbot.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Services.Services
{
    public class AtendenteServices : IAtendenteInterfaceServices
    {
        protected readonly IAtendeteInterface _repository;
        protected readonly IDepartamentoInterfaceServices _departamento;
        protected readonly ILoginInterfaceServices _login;

        public AtendenteServices(IAtendeteInterface repository, IDepartamentoInterfaceServices departamento, ILoginInterfaceServices login)
        {
            _repository = repository;
            _departamento = departamento;
            _login = login;
        }

        public async Task<List<AtendenteDttoForView>> GetALl()
        {
            try
            {
                var dados = await _repository.GetALl();
                List<AtendenteDttoForView> List = new List<AtendenteDttoForView>();
                foreach (var item in dados)
                {
                    AtendenteDttoForView Model = new AtendenteDttoForView
                    {
                        Codigo = item.AteId,
                        Nome = item.AteNome,
                        EstadoAtendente = item.AteEstado,
                        Login = await _login.GetPorIdLoginView(Convert.ToInt32(item.LogId)),
                        Departamento = await _departamento.GetPorId(Convert.ToInt32(item.DepId)),
                    };
                    List.Add(Model);
                }
                return List;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AtendenteDttoForView> GetPorId(int id)
        {
            try
            {
                var dados = await _repository.GetPorId(id);

                AtendenteDttoForView Model = new AtendenteDttoForView
                {
                    Codigo = dados.AteId,
                    Nome = dados.AteNome,
                    EstadoAtendente = dados.AteEstado,
                    Login = await _login.GetPorIdLoginView(Convert.ToInt32(dados.LogId)),
                    Departamento = await _departamento.GetPorId(Convert.ToInt32(dados.DepId)),
                };

                return Model;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public async Task<AtendenteDttoForView> AdicionarPost(AtendenteDttoForPost Model)
        {
            try
            {
                Atendente NewModel = new Atendente
                {
                    AteNome = Model.Nome,
                    AteEmail = Model.Email,
                    AteSenha = Model.Senha,
                    AteImg = Model.Imagem,
                    AteEstado = Model.EstadoAtendente,
                    DepId = Model.CodigoDepartamento,
                    LogId = Model.CodigoLogin
                };
                var dados = await _repository.Adicionar(NewModel);
                AtendenteDttoForView ViewModel = new AtendenteDttoForView
                {
                    Codigo = dados.AteId,
                    Nome = dados.AteNome,
                    EstadoAtendente = dados.AteEstado,
                    Departamento = await _departamento.GetPorId(Convert.ToInt32(dados.DepId)),
                    Login = await _login.GetPorIdLoginView(Convert.ToInt32(dados.LogId))
                };
                return ViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AtendenteDttoForView> UpdatePost(AtendenteDttoForPut Model)
        {
            try
            {
                Atendente NewModel = new Atendente
                {
                    AteId = Model.Codigo,
                    AteNome = Model.Nome,
                    AteEmail = Model.Email,
                    AteSenha = Model.Senha,
                    AteImg = Model.Imagem,
                    AteEstado = Model.EstadoAtendente,
                    DepId = Model.CodigoDepartamento,
                    LogId = Model.CodigoLogin
                };
                var dados = await _repository.update(NewModel);
                AtendenteDttoForView ViewModel = new AtendenteDttoForView
                {
                    Codigo = dados.AteId,
                    Nome = dados.AteNome,
                    EstadoAtendente = dados.AteEstado,
                    Departamento = await _departamento.GetPorId(Convert.ToInt32(dados.DepId)),
                    Login = await _login.GetPorIdLoginView(Convert.ToInt32(dados.LogId))
                };
                return ViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AtendenteDttoForView> Delete(int id)
        {
            try
            {
                var dados = await _repository.delete(id);
                AtendenteDttoForView model = new AtendenteDttoForView
                {
                    Codigo = dados.AteId,
                    Nome = dados.AteNome,
                    EstadoAtendente = dados.AteEstado,
                    Departamento = await _departamento.GetPorId(id),
                    Login = await _login.GetPorIdLoginView(id)
                };
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //ver oque fazer depois com esses metodos que ficaramSobrando
        public Task<AtendenteDttoForView> Create(AtendenteDttoForView Model)
        {
            throw new NotImplementedException();
        }

        public Task<AtendenteDttoForView> Update(AtendenteDttoForView Model)
        {
            throw new NotImplementedException();
        }
    }
}
