
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
        public string CriptografaSenha(string senha)
        {
            var a = Encoding.UTF8.GetBytes(senha);
            var b = Convert.ToBase64String(a);
            return b;
        }

        public string? DescriptografaSenha(string senha)
        {
            var c = Convert.FromBase64String(senha);
            var d = Encoding.UTF8.GetString(c);
            return d;
        }
    }

    public class LoginDttoPost
    {
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string CriptografaSenha(string senha)
        {
            var a = Encoding.UTF8.GetBytes(senha);
            var b = Convert.ToBase64String(a);
            return b;
        }

        public string DescriptografaSenha(string senha)
        {
            var c = Convert.FromBase64String(senha);
            var d = Encoding.UTF8.GetString(c);
            return d;
        }
    }

}
