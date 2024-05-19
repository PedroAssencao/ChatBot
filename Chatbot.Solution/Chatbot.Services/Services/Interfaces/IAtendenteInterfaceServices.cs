using Chatbot.Infrastructure.Dtto;
using Chatbot.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Services.Services.Interfaces
{
    public interface IAtendenteInterfaceServices : IBaseInterfaceServices<AtendenteDttoForView>
    {
        Task<AtendenteDttoForView> AdicionarPost(AtendenteDttoForPost Model);
        Task<AtendenteDttoForView> UpdatePost(AtendenteDttoForPut Model);
    }
}
