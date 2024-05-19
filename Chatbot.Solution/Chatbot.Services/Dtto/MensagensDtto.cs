
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Infrastructure.Dtto
{
    public class MensagensDttoGetForView
    {
        public int Codigo { get; set; }
        public DateTime? Data { get; set; }
        public string? Descricao { get; set; }
        public ContatoDttoGet? Contato { get; set; }
    }

    public class MensagensDttoGet
    {
        public int Codigo { get; set; }
        public DateTime? Data { get; set; }
        public string? Descricao { get; set; }
        public string? TipoDaMensagem { get; set; }
        public ContatoDttoGetForView? Contato { get; set; }
        public LoginDttoGetForView? Login { get; set; }
        public ChatsDttoGetForMensagens? Chat { get; set; }
    }

}
