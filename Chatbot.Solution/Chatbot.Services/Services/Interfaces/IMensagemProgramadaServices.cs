using Chatbot.Infrastructure.Services.Interfaces;
using Chatbot.Services.Dtto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Chatbot.Services.Dtto.MensagemProgramadaDtto;

namespace Chatbot.Services.Services.Interfaces
{
    public interface IMensagemProgramadaServices : IBaseInterfaceServices<MensagemProgramadaDtto>
    {
        Task<List<MensagemProgramadaDttoGet>> GetALl();
        Task<MensagemProgramadaDttoGet> GetPorId(int id);
        Task<MensagemProgramadaDttoPost> Create(MensagemProgramadaDttoPost Model);
        //Task<MensagemProgramadaDtto> Update(MensagemProgramadaDtto Model);
        //Task<MensagemProgramadaDtto> Delete(int id);
    }
}
