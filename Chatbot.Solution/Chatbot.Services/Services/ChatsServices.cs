using Chatbot.API.DAL;

using Chatbot.API.Repository;
using Chatbot.Infrastructure.Dtto;
using Chatbot.Infrastructure.Interfaces;
using Chatbot.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Infrastructure.Services
{
    internal class ChatsServices : IChatsInterfaceServices
    {
   

        public Task<List<ChatsDttoGet>> GetALl()
        {
            //var dados = await _chatRepository.GetAll();
            //List<ChatsDttoGet> Lista = new List<ChatsDttoGet>();
            //foreach (var item in dados)
            //{
            //    ChatsDttoGet Model = new ChatsDttoGet
            //    {
            //        Codigo = item.ChaId,
            //        Atendente = await _atendentesRepository.GetPorID(Convert.ToInt32(item.AteId)),
            //        Con = await _contatoRepository.GetPorID(Convert.ToInt32(item.ConId)),
            //        Mensagens = await _mensagemRepository.RetornarMensagensPorChat(Convert.ToInt32(item.ChaId), Convert.ToInt32(item.LogId))
            //    };
            //    Lista.Add(Model);
            //}
            //return Lista;
            throw new NotImplementedException();
        }

        public Task<ChatsDttoGet> GetPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ChatsDttoGet> Create(ChatsDttoGet Model)
        {
            throw new NotImplementedException();
        }

        public Task<ChatsDttoGet> Update(ChatsDttoGet Model)
        {
            throw new NotImplementedException();
        }

        public Task<ChatsDttoGet> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
