
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Infrastructure.Dtto
{
    public class ChatsDttoGet
    {
        public int Codigo { get; set; }
        public AtendenteDttoGet? Atendente { get; set; }
        public AtendimentoDttoGet? Atendimento { get; set; }
        public ContatoDttoGetForView? Contato { get; set; }
        public List<MensagensDttoGetForView>? Mensagens { get; set; }

    }

    public class ChatsDttoGetForMensagens
    {
        public int Codigo { get; set; }
        public AtendimentoDttoGet? Atendente { get; set; }
        public AtendimentoDttoGet? Atendimento { get; set; }
        public ContatoDttoGetForView? Contato { get; set; }

    }
}
