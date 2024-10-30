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
    public class OptionServices : IOptionInterfaceServices
    {
        protected readonly IOptionsInterface _repository;
        protected readonly ILoginInterfaceServices _loginService;
        
        public OptionServices(IOptionsInterface repository, ILoginInterfaceServices loginService)
        {
            _repository = repository;
            _loginService = loginService;
        }

        public async Task<List<OptionDttoGet>> GetALl()
        {
            try
            {
                var dados = await _repository.GetALl();
                List<OptionDttoGet> List = new List<OptionDttoGet>();
                foreach (var item in dados)
                {
                    OptionDttoGet Model = new OptionDttoGet
                    {
                        Codigo = item.OptId,
                        CodigoMenu = item.MenId,
                        Data = item.OptData,
                        Titulo = item.OptTitle,
                        Tipo = item.OptTipo,
                        Descricao = item.OptDescricao,
                        Resposta = item.OptResposta,
                        Finalizar = item.OptFinalizar,
                        Login = await _loginService.GetPorIdLoginView(Convert.ToInt32(item.LogId))
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

        public async Task<OptionDttoGet> GetPorId(int id)
        {
            try
            {
                var item = await _repository.GetPorId(id);
                if (item == null)
                {
                    return null;
                }
                OptionDttoGet Model = new OptionDttoGet
                {
                    Codigo = item.OptId,
                    CodigoMenu = item.MenId,
                    Data = item.OptData,
                    Titulo = item.OptTitle,
                    Tipo = item.OptTipo,
                    Descricao = item.OptDescricao,
                    Resposta = item.OptResposta,
                    Finalizar = item.OptFinalizar,
                    Login = await _loginService.GetPorIdLoginView(Convert.ToInt32(item.LogId))
                };
                return Model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<OptionDttoGetForMenu>> GetPorIdForMenu(int id)
        {
            try
            {
                var Model = await _repository.GetALl();
                var Lista = Model.Where(x => x.MenId == id).ToList();
                List<OptionDttoGetForMenu> List = new List<OptionDttoGetForMenu>();
                foreach (var item in Lista)
                {
                    OptionDttoGetForMenu NewModel = new OptionDttoGetForMenu
                    {
                        Codigo = item.OptId,
                        CodigoMenu = item.MenId,
                        Titulo = item.OptTitle,
                        Tipo = item.OptTipo,
                        Descricao = item.OptDescricao,
                        Resposta = item.OptResposta,
                        Finalizar = item.OptFinalizar,
                    };
                    List.Add(NewModel);
                }
                return List;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<OptionDttoGet> AdicionarPost(OptionDttoPost Model)
        {
            try
            {
                Option NewModel = new Option
                {
                    OptDescricao = Model.Descricao,
                    OptTitle = Model.Titulo,
                    OptResposta = Model.Resposta,
                    OptTipo = Model.Tipo,
                    OptFinalizar = Model.Finalizar,
                    OptData = Model.Data,
                    LogId = Model.CodigoLogin,
                    MenId = Model.CodigoMenu
                };

                if (NewModel == null)
                {
                    throw new Exception("Entrada Vazia");
                }

                var item = await _repository.Adicionar(NewModel);
                OptionDttoGet ViewModel = new OptionDttoGet
                {
                    Codigo = item.OptId,
                    CodigoMenu = item.MenId,
                    Data = item.OptData,
                    Titulo = item.OptTitle,
                    Tipo = item.OptTipo,
                    Descricao = item.OptDescricao,
                    Resposta = item.OptResposta,
                    Finalizar = item.OptFinalizar,
                    Login = item.LogId == null ? null : await _loginService.GetPorIdLoginView(Convert.ToInt32(item.LogId))
                };
                return ViewModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OptionDttoGet> AtualizarPost(OptionDttoPut Model)
        {
            try
            {
                Option NewModel = new Option
                {
                    OptId = Model.Codigo,
                    OptDescricao = Model.Descricao,
                    OptTitle = Model.Titulo,
                    OptResposta = Model.Resposta,
                    OptTipo = Model.Tipo,
                    OptFinalizar = Model.Finalizar,
                    OptData = Model.Data,
                    LogId = Model.CodigoLogin,
                    MenId = Model.CodigoMenu
                };
                var item = await _repository.update(NewModel);
                OptionDttoGet ViewModel = new OptionDttoGet
                {
                    Codigo = item.OptId,
                    CodigoMenu = item.MenId,
                    Data = item.OptData,
                    Titulo = item.OptTitle,
                    Tipo = item.OptTipo,
                    Descricao = item.OptDescricao,
                    Resposta = item.OptResposta,
                    Finalizar = item.OptFinalizar,
                    Login = await _loginService.GetPorIdLoginView(item.OptId)
                };
                return ViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OptionDttoGet> Delete(int id)
        {
            try
            {
                var item = await _repository.delete(id);
                OptionDttoGet Model = new OptionDttoGet
                {
                    Codigo = item.OptId,
                    CodigoMenu = item.MenId,
                    Data = item.OptData,
                    Titulo = item.OptTitle,
                    Tipo = item.OptTipo,
                    Descricao = item.OptDescricao,
                    Resposta = item.OptResposta,
                    Finalizar = item.OptFinalizar,
                    Login = await _loginService.GetPorIdLoginView(Convert.ToInt32(item.LogId))

                };
                return Model;
            }
            catch (Exception)
            {
                throw;
            }
        }



        //metodos que ficaram sobrando
        public Task<OptionDttoGet> Create(OptionDttoGet Model)
        {
            throw new NotImplementedException();
        }
        public Task<OptionDttoGet> Update(OptionDttoGet Model)
        {
            throw new NotImplementedException();
        }
    }
}
