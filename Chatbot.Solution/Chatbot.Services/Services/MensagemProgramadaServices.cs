using Chatbot.API.Repository;
using Chatbot.Domain.Models.Enums;
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
using static Chatbot.Services.Dtto.MensagemProgramadaDtto;
using Chatbot.Services.Dtto;

namespace Chatbot.Services.Services
{
    public class MensagemProgramadaServices: IMensagemProgramadaServices
    {
        protected readonly IMensagemProgramadaInterface _repository;
        protected readonly ILoginInterfaceServices _loginInterfaceRepository;

        public MensagemProgramadaServices(IMensagemProgramadaInterface repository, ILoginInterfaceServices loginInterfaceRepository)
        {
            _repository = repository;
            _loginInterfaceRepository = loginInterfaceRepository;
        }

        public async Task<List<MensagemProgramadaDttoGet>> GetALl()
        {
            try
            {
                var dados = await _repository.GetALl();
                List<MensagemProgramadaDttoGet> list = new List<MensagemProgramadaDttoGet>();
                foreach (var item in dados)
                {
                    MensagemProgramadaDttoGet Model = new MensagemProgramadaDttoGet
                    {
                        Codigo = item.MemproId,
                        DataCriada = item.MemproDatacriada,
                        DataEnvio = item.MemproDataenvio,
                        TipoDaMensagem = item.MemproTipo,
                        Descricao = item.MemproDescricao,
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

        public async Task<MensagemProgramadaDttoGet> GetPorId(int id)
        {
            try
            {
                var item = await _repository.GetPorId(id);
                MensagemProgramadaDttoGet Model = new MensagemProgramadaDttoGet
                {
                    Codigo = item.MemproId,
                    DataCriada = item.MemproDatacriada,
                    DataEnvio = item.MemproDataenvio,
                    TipoDaMensagem = item.MemproTipo,
                    Descricao = item.MemproDescricao,
                    Login = item.LogId == null ? null : await _loginInterfaceRepository.GetPorIdLoginView(Convert.ToInt32(item.LogId)),
                };
                return Model;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<MensagemProgramadaDttoGet> AdicionarPost(MensagemProgramadaDttoPost Model)
        {
            try
            {
                MensagemProgramadum NewModel = new MensagemProgramadum
                {
                    MemproDatacriada = Model.DataCriada,
                    MemproDataenvio = Model.DataEnvio,
                    MemproDescricao = Model.Descricao,
                    MemproTipo = Model.TipoDaMensagem,
                    LogId = Model.CodigoLogin,
                };
                var item = await _repository.Adicionar(NewModel);
                MensagemProgramadaDttoGet ViewModel = new MensagemProgramadaDttoGet
                {
                    Codigo = item.MemproId,
                    DataCriada = item.MemproDatacriada,
                    DataEnvio = item.MemproDataenvio,
                    TipoDaMensagem = item.MemproTipo,
                    Descricao = item.MemproDescricao,
                    Login = item.LogId == null ? null : await _loginInterfaceRepository.GetPorIdLoginView(Convert.ToInt32(item.LogId)),
                };
                return ViewModel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<MensagemProgramadaDttoPost> Create(MensagemProgramadaDttoPost Model)
        {
            throw new NotImplementedException();
        }

        Task<List<MensagemProgramadaDtto>> IBaseInterfaceServices<MensagemProgramadaDtto>.GetALl()
        {
            throw new NotImplementedException();
        }

        Task<MensagemProgramadaDtto> IBaseInterfaceServices<MensagemProgramadaDtto>.GetPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MensagemProgramadaDtto> Create(MensagemProgramadaDtto Model)
        {
            throw new NotImplementedException();
        }

        public Task<MensagemProgramadaDtto> Update(MensagemProgramadaDtto Model)
        {
            throw new NotImplementedException();
        }

        public Task<MensagemProgramadaDtto> Delete(int id)
        {
            throw new NotImplementedException();
        }



        //public async Task<MensagensDttoGet> AtualizarPut(MensagensDttoPut Model)
        //{
        //    try
        //    {
        //        Mensagen NewModel = new Mensagen
        //        {
        //            MensId = Model.Codigo,
        //            MensData = Model.Data,
        //            MensDescricao = Model.Descricao,
        //            MenTipo = Model.TipoDaMensagem,
        //            mensWaId = Model.CodigoWhatsapp,
        //            ChaId = Model.CodigoChat,
        //            LogId = Model.CodigoLogin,
        //            ConId = Model.CodigoContato
        //        };
        //        var item = await _repository.update(NewModel);
        //        MensagensDttoGet ViewModel = new MensagensDttoGet
        //        {
        //            Codigo = item.MensId,
        //            Data = item.MensData,
        //            TipoDaMensagem = item.MenTipo,
        //            Descricao = item.MensDescricao,
        //            CodigoWhatsapp = item.mensWaId,
        //            CodigoChat = Convert.ToInt32(item.ChaId),
        //            Contato = item.ConId == null ? null : await _contatoRepository.GetContatoForViewPorId(Convert.ToInt32(item.ConId)),
        //            Login = item.LogId == null ? null : await _loginInterfaceRepository.GetPorIdLoginView(Convert.ToInt32(item.LogId)),
        //        };
        //        return ViewModel;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public async Task<MensagensDttoGet> Delete(int id)
        //{
        //    try
        //    {
        //        var item = await _repository.GetPorId(id);

        //        MensagensDttoGet ViewModel = new MensagensDttoGet
        //        {
        //            Codigo = item.MensId,
        //            Data = item.MensData,
        //            TipoDaMensagem = item.MenTipo,
        //            Descricao = item.MensDescricao,
        //            CodigoWhatsapp = item.mensWaId,
        //            CodigoChat = Convert.ToInt32(item.ChaId),
        //            Contato = item.ConId == null ? null : await _contatoRepository.GetContatoForViewPorId(Convert.ToInt32(item.ConId)),
        //            Login = item.LogId == null ? null : await _loginInterfaceRepository.GetPorIdLoginView(Convert.ToInt32(item.LogId)),
        //        };
        //        await _repository.delete(ViewModel.Codigo);
        //        return ViewModel;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        ////não utilizados
        //public Task<MensagensDttoGet> Create(MensagensDttoGet Model)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<MensagensDttoGet> Update(MensagensDttoGet Model)
        //{
        //    throw new NotImplementedException();
        //}

    }
}

   
