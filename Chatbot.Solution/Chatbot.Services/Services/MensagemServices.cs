using Chatbot.Domain.Models;
using Chatbot.Domain.Models.Enums;
using Chatbot.Infrastructure.Dtto;
using Chatbot.Infrastructure.Repository.Interfaces;
using Chatbot.Infrastructure.Services.Interfaces;
using Chatbot.Services.Services.Interfaces;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Chatbot.Services.Services
{
    public class MensagemServices : IMensagemInterfaceServices
    {
        protected readonly IMensagemInterface _repository;
        protected readonly IContatoInterfaceServices _contatoRepository;
        protected readonly ILoginInterfaceServices _loginInterfaceRepository;

        public MensagemServices(IMensagemInterface repository, IContatoInterfaceServices contatoRepository, ILoginInterfaceServices loginInterfaceRepository)
        {
            _repository = repository;
            _contatoRepository = contatoRepository;
            _loginInterfaceRepository = loginInterfaceRepository;
        }

        public async Task<List<MensagensDttoGet>> GetALl()
        {
            try
            {
                var dados = await _repository.GetALl();
                List<MensagensDttoGet> list = new List<MensagensDttoGet>();
                foreach (var item in dados)
                {
                    MensagensDttoGet Model = new MensagensDttoGet
                    {
                        Codigo = item.MensId,
                        Data = item.MensData,
                        TipoDaMensagem = item.MenTipo,
                        Descricao = item.MensDescricao,
                        CodigoChat = Convert.ToInt32(item.ChaId),
                        Contato = item.ConId == null ? null : await _contatoRepository.GetContatoForViewPorId(Convert.ToInt32(item.ConId)),
                        Login = item.LogId == null ? null : await _loginInterfaceRepository.GetPorIdLoginView(Convert.ToInt32(item.LogId)),
                    };
                    list.Add(Model);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MensagensDttoGet> GetPorId(int id)
        {
            try
            {
                var item = await _repository.GetPorId(id);
                MensagensDttoGet Model = new MensagensDttoGet
                {
                    Codigo = item.MensId,
                    Data = item.MensData,
                    TipoDaMensagem = item.MenTipo,
                    Descricao = item.MensDescricao,
                    CodigoChat = Convert.ToInt32(item.ChaId),
                    Contato = item.ConId == null ? null : await _contatoRepository.GetContatoForViewPorId(Convert.ToInt32(item.ConId)),
                    Login = item.LogId == null ? null : await _loginInterfaceRepository.GetPorIdLoginView(Convert.ToInt32(item.LogId)),
                };
                return Model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<MensagensDttoGetForView>> BuscarMensagensDeUmChat(int cha, int log)
        {
            try
            {
                var dados = await _repository.GetALl();
                var dadosFiltrados = dados.Where(x => x.ChaId == cha && x.MenTipo == nameof(ETipos.MensagemEnviada)).ToList();
                List<MensagensDttoGetForView> list = new List<MensagensDttoGetForView>();
                foreach (var item in dadosFiltrados)
                {
                    MensagensDttoGetForView Model = new MensagensDttoGetForView
                    {
                        Codigo = item.MensId,
                        Data = item.MensData,
                        Descricao = item.MensDescricao,
                        Contato = item.ConId == null ? null : await _contatoRepository.GetContatoForViewPorId(Convert.ToInt32(item.ConId))
                    };
                    list.Add(Model);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MensagensDttoGet?> PegarUltimaMensagemDeUmContatoPorLogConWaIdEConWaId(string ConWaID, string LogConWaID)
        {
            try
            {
                var dados = await GetALl();
                var item = dados.LastOrDefault(x => x?.Contato?.CodigoWhatsapp == ConWaID && x?.Login?.CodigoWhatsapp == LogConWaID && x.TipoDaMensagem == nameof(ETipos.MensagemEnviada));
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MensagensDttoGet> AdicionarPost(MensagensDttoPost Model)
        {
            try
            {
                Mensagen NewModel = new Mensagen
                {
                    MensData = Model.Data,
                    MensDescricao = Model.Descricao,
                    MenTipo = Model.TipoDaMensagem,
                    ChaId = Model.CodigoChat,
                    LogId = Model.CodigoLogin,
                    ConId = Model.CodigoContato
                };
                var item = await _repository.Adicionar(NewModel);
                MensagensDttoGet ViewModel = new MensagensDttoGet
                {
                    Codigo = item.MensId,
                    Data = item.MensData,
                    TipoDaMensagem = item.MenTipo,
                    Descricao = item.MensDescricao,
                    CodigoChat = item.ChaId == null ? 0 : Convert.ToInt32(item.ChaId),
                    Contato = item.ConId == null ? null : await _contatoRepository.GetContatoForViewPorId(Convert.ToInt32(item.ConId)),
                    Login = item.LogId == null ? null : await _loginInterfaceRepository.GetPorIdLoginView(Convert.ToInt32(item.LogId)),
                };
                return ViewModel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MensagensDttoGet> AtualizarPut(MensagensDttoPut Model)
        {
            try
            {
                Mensagen NewModel = new Mensagen
                {
                    MensId = Model.Codigo,
                    MensData = Model.Data,
                    MensDescricao = Model.Descricao,
                    MenTipo = Model.TipoDaMensagem,
                    ChaId = Model.CodigoChat,
                    LogId = Model.CodigoLogin,
                    ConId = Model.CodigoContato
                };
                var item = await _repository.update(NewModel);
                MensagensDttoGet ViewModel = new MensagensDttoGet
                {
                    Codigo = item.MensId,
                    Data = item.MensData,
                    TipoDaMensagem = item.MenTipo,
                    Descricao = item.MensDescricao,
                    CodigoChat = Convert.ToInt32(item.ChaId),
                    Contato = item.ConId == null ? null : await _contatoRepository.GetContatoForViewPorId(Convert.ToInt32(item.ConId)),
                    Login = item.LogId == null ? null : await _loginInterfaceRepository.GetPorIdLoginView(Convert.ToInt32(item.LogId)),
                };
                return ViewModel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MensagensDttoGet> Delete(int id)
        {
            try
            {
                var item = await _repository.delete(id);
                MensagensDttoGet ViewModel = new MensagensDttoGet
                {
                    Codigo = item.MensId,
                    Data = item.MensData,
                    TipoDaMensagem = item.MenTipo,
                    Descricao = item.MensDescricao,
                    CodigoChat = Convert.ToInt32(item.ChaId),
                    Contato = item.ConId == null ? null : await _contatoRepository.GetContatoForViewPorId(Convert.ToInt32(item.ConId)),
                    Login = item.LogId == null ? null : await _loginInterfaceRepository.GetPorIdLoginView(Convert.ToInt32(item.LogId)),
                };
                return ViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //não utilizados
        public Task<MensagensDttoGet> Create(MensagensDttoGet Model)
        {
            throw new NotImplementedException();
        }

        public Task<MensagensDttoGet> Update(MensagensDttoGet Model)
        {
            throw new NotImplementedException();
        }

    }
}
