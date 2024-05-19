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
    public class MensagemServices : IMensagemInterfaceServices
    {
        protected readonly IMensagemInterface _repository;
        protected readonly IContatoInterfaceServices _contatoRepository;

        public MensagemServices(IMensagemInterface repository, IContatoInterfaceServices contatoRepository)
        {
            _repository = repository;
            _contatoRepository = contatoRepository;
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
                        Contato = await _contatoRepository.GetPorId(Convert.ToInt32(item.ConId)),
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

        public Task<MensagensDttoGet> GetPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MensagensDttoGetForView>> BuscarMensagensDeUmChat(int con, int log)
        {
            throw new NotImplementedException();
        }

        public Task<MensagensDttoGet> Create(MensagensDttoGet Model)
        {
            throw new NotImplementedException();
        }

        public Task<MensagensDttoGet> Update(MensagensDttoGet Model)
        {
            throw new NotImplementedException();
        }

        public Task<MensagensDttoGet> Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
