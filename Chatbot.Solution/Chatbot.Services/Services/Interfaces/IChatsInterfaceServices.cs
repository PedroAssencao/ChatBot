
using Chatbot.Infrastructure.Dtto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Infrastructure.Services.Interfaces
{
    public interface IChatsInterfaceServices : IBaseInterfaceServices<ChatsDttoGet>
    {
        Task<ChatsDttoGetForMensagens> BuscarChatParaMensagen(int id);
        Task<ChatsDttoGet> AdicionarPost(ChatsDttoPost Model);
        Task<ChatsDttoGet> AtualziarPut(ChatsDttoPut Model);
         Task<dynamic> CompararData();
    }
}
