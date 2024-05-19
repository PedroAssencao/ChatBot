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
    public class LoginDttoGetForView
    {
        public int Codigo { get; set; } 
        public string? Usuario { get; set; }
        public string? CodigoWhatsapp { get; set; }
    }

    public class LoginDttoGet
    {
        public int Codigo { get; set; }
        public string? CodigoWhatsap { get; set; }

        public string? Usuario { get; set; }
        public string? Email { get; set; }
    
        public string? Senha { get; set; }
    
        public string? Imagem { get; set; }
    
        public string? Plano { get; set; }

    }
}
