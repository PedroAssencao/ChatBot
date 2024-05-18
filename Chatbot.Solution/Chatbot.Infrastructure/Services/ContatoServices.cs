using AutoMapper;
using Chatbot.API.Models;
using Chatbot.API.Repository;
using Chatbot.Infrastructure.Dtto;
using Chatbot.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chatbot.Infrastructure.Services
{
    public class ContatoServices : IContatoInterfaceServices
    {
        protected readonly ContatoRepository _contatoRepository;
        private readonly MapperConfiguration configurationMapper;
        public ContatoServices(ContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
            configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Contato, ContatoDttoGet>();
                cfg.CreateMap<ContatoDttoGet, Contato>();
            });
        }

        public async Task<List<ContatoDttoGet>> GetALl()
        {
            var mapper = configurationMapper.CreateMapper();
            return mapper.Map<List<ContatoDttoGet>>(await _contatoRepository.GetAll());
        }

        public async Task<ContatoDttoGet> GetPorId(int id)
        {
            var mapper = configurationMapper.CreateMapper();
            return mapper.Map<ContatoDttoGet>(await _contatoRepository.GetPorID(id));
        }
        public async Task<ContatoDttoGet> Create(ContatoDttoGet Model)
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
                await _contatoRepository.Update(NewModel);
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
                var mapper = configurationMapper.CreateMapper();
                var model = mapper.Map<ContatoDttoGet>(await _contatoRepository.Delete(id));
                return model;
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


    }
}
