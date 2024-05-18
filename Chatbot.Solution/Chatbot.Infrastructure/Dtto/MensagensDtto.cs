using Chatbot.API.Models;
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
    }

    public class MensagensDttoGet
    {
        public int Codigo { get; set; }
        public DateTime? Data { get; set; }
        public string? Descricao { get; set; }
        public string? TipoDaMensagem { get; set; }
        public ContatoDttoGet? Contato { get; set; }
        public LoginDttoGet? Login { get; set; }
        public ChatsDttoGet? Chat { get; set; }
    }

}
