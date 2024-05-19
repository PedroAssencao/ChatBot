
using AutoMapper;
using Chatbot.API.Repository;
using Chatbot.Domain.Models;
using Chatbot.Infrastructure.Dtto;
using Chatbot.Infrastructure.Repository.Interfaces;
using Chatbot.Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Chatbot.Infrastructure.Services
{
    public class ContatoServices : IContatoInterfaceServices
    {
        protected readonly IContatosInterface _contatoRepository;
        public ContatoServices(IContatosInterface contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<List<ContatoDttoGet>> GetALl()
        {
            try
            {
                var dados = await _contatoRepository.GetALl();
                List<ContatoDttoGet> List = new List<ContatoDttoGet>();
                foreach (var item in dados)
                {
                    ContatoDttoGet NewModel = new ContatoDttoGet
                    {
                        Codigo = item.ConId,
                        CodigoWhatsapp = item.ConWaId,
                        Nome = item.ConNome,
                        DataCadastro = item.ConDataCadastro,
                        BloqueadoStatus = item.ConBloqueadoStatus,
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

        public async Task<ContatoDttoGet> GetPorId(int id)
        {
            try
            {
                var Model = await _contatoRepository.GetPorId(id);
                ContatoDttoGet NewModel = new ContatoDttoGet
                {
                    Codigo = Model.ConId,
                    CodigoWhatsapp = Model.ConWaId,
                    Nome = Model.ConNome,
                    DataCadastro = Model.ConDataCadastro,
                    BloqueadoStatus = Model.ConBloqueadoStatus,
                };
                return NewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ContatoDttoGet> Create(ContatoDttoGet Model)
        {
            try
            {
                Contato NewModel = new Contato
                {
                    ConId = Model.Codigo,
                    ConNome = Model.Nome,
                    ConDataCadastro = Model.DataCadastro,
                    ConWaId = Model.CodigoWhatsapp,
                    ConBloqueadoStatus = Model.BloqueadoStatus
                };
                await _contatoRepository.Adicionar(NewModel);
                return Model;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<ContatoDttoGet> Update(ContatoDttoGet Model)
        {
            try
            {
                Contato NewModel = new Contato
                {
                    ConId = Model.Codigo,
                    ConNome = Model.Nome,
                    ConDataCadastro = Model.DataCadastro,
                    ConWaId = Model.CodigoWhatsapp,
                    ConBloqueadoStatus = Model.BloqueadoStatus
                };
                await _contatoRepository.update(NewModel);
                return Model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ContatoDttoGet> Delete(int id)
        {
            try
            {
                var model = await _contatoRepository.delete(id);
                ContatoDttoGet NewModel = new ContatoDttoGet
                {
                    Codigo = model.ConId,
                    CodigoWhatsapp = model.ConWaId,
                    Nome = model.ConNome,
                    DataCadastro = model.ConDataCadastro,
                    BloqueadoStatus = model.ConBloqueadoStatus,
                };
                return NewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ContatoDttoGet> RetornarConIdPorWaID(string waID)
        {
            try
            {
                if (waID == null)
                {
                    throw new Exception("informe um Id do whatsapp");
                }
                else
                {
                    var dados = await GetALl();
                    var ContatoEntity = dados.FirstOrDefault(x => x.CodigoWhatsapp == waID);
                    if (ContatoEntity != null)
                    {
                        return ContatoEntity;
                    }
                    else
                    {
                        throw new Exception("Id Não Encontrado");
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("ocorreu um error ao tentar fazer a requisição" + ex.Message);
            }

        }

        public async Task<ContatoDttoGetForView> GetContatoForViewPorId(int id)
        {
            try
            {
                var Model = await _contatoRepository.GetPorId(id);
                ContatoDttoGetForView NewModel = new ContatoDttoGetForView
                {
                    Codigo = Model.ConId,
                    Nome = Model.ConNome,
                    CodigoWhatsapp = Model.ConWaId,
                };
                return NewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
