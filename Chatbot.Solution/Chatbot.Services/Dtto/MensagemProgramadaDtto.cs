using Chatbot.Infrastructure.Dtto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Services.Dtto
{
    public class MensagemProgramadaDtto
    {
        public class MensagemProgramadaDttoGet
        {
            public int Codigo { get; set; }
            public DateTime? DataCriada { get; set; }
            public DateTime? DataEnvio { get; set; }
            public string? Descricao { get; set; }
            public string? TipoDaMensagem { get; set; }
            public LoginDttoGetForView? Login { get; set; }
        }
        public class MensagemProgramadaDttoPost
        {
            public DateTime? DataCriada { get; set; }
            public DateTime? DataEnvio { get; set; }
            public string? Descricao { get; set; }
            public string? TipoDaMensagem { get; set; }
            public int? CodigoLogin { get; set; }
        }
    }
}
