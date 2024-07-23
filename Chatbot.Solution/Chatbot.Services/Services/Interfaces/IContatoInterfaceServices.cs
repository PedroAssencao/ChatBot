using Chatbot.Infrastructure.Dtto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Infrastructure.Services.Interfaces
{
    public interface IContatoInterfaceServices : IBaseInterfaceServices<ContatoDttoGet>
    {
        public Task<ContatoDttoGet> RetornarConIdPorWaID(string waid);
        public Task<ContatoDttoGetForView> GetContatoForViewPorId(int id);
        public Task<ContatoDttoGet> CreateComCodigo(ContatoDttoGet Model);
    }
}
