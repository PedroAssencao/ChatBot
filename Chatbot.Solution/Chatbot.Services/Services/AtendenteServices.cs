using Chatbot.Domain.Models;
using Chatbot.Infrastructure.Dtto;
using Chatbot.Infrastructure.Repository.Interfaces;
using Chatbot.Services.Services.Interfaces;
using Microsoft.Extensions.Logging.Abstractions;
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

        public async Task<List<AtendenteDttoGet>> GetALl()
        {
            try
            {
                var dados = await _repository.GetALl();
                List<AtendenteDttoGet> List = new List<AtendenteDttoGet>();
                foreach (var item in dados)
                {
                    AtendenteDttoGet Model = new AtendenteDttoGet
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

        public async Task<AtendenteDttoGet> GetPorId(int id)
        {
            try
            {
                var dados = await _repository.GetPorId(id);

                AtendenteDttoGet Model = new AtendenteDttoGet
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
        
        public async Task<AtendenteDttoGet> AdicionarPost(AtendenteDttoForPost Model)
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
                AtendenteDttoGet ViewModel = new AtendenteDttoGet
                {
                    Codigo = dados.AteId,
                    Nome = dados.AteNome,
                    EstadoAtendente = dados.AteEstado,
                    Departamento = dados.DepId == null ? null : await _departamento.GetPorId(Convert.ToInt32(dados.DepId)),
                    Login = dados.LogId == null ? null : await _login.GetPorIdLoginView(Convert.ToInt32(dados.LogId))
                };
                return ViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AtendenteDttoGet> UpdatePost(AtendenteDttoForPut Model)
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
                AtendenteDttoGet ViewModel = new AtendenteDttoGet
                {
                    Codigo = dados.AteId,
                    Nome = dados.AteNome,
                    EstadoAtendente = dados.AteEstado,
                    Departamento = dados.DepId == null ? null : await _departamento.GetPorId(Convert.ToInt32(dados.DepId)),
                    Login = dados.LogId == null ? null : await _login.GetPorIdLoginView(Convert.ToInt32(dados.LogId))
                };
                return ViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AtendenteDttoGet> Delete(int id)
        {
            try
            {
                var dados = await _repository.delete(id);
                AtendenteDttoGet ViewModel = new AtendenteDttoGet
                {
                    Codigo = dados.AteId,
                    Nome = dados.AteNome,
                    EstadoAtendente = dados.AteEstado,
                    Departamento = dados.DepId == null ? null : await _departamento.GetPorId(Convert.ToInt32(dados.DepId)),
                    Login = dados.LogId == null ? null : await _login.GetPorIdLoginView(Convert.ToInt32(dados.LogId))
                };
                return ViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //ver oque fazer depois com esses metodos que ficaramSobrando
        public Task<AtendenteDttoGet> Create(AtendenteDttoGet Model)
        {
            throw new NotImplementedException();
        }

        public Task<AtendenteDttoGet> Update(AtendenteDttoGet Model)
        {
            throw new NotImplementedException();
        }
    }
}
