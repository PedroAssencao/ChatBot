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
    public class OptionDttoGet
    {
        public int Codigo { get; set; }
        public int? MenId { get; set; }
        public LoginDttoGet? Login { get; set; }
        public DateTime? Data { get; set; }
        public string? Descricao { get; set; }
        public bool? Finalizar { get; set; }
        public string? Resposta { get; set; }
        public string? Tipo { get; set; }
        public string? Titulo { get; set; }
    }
    public class OptionDttoGetForMenu
    {
        public int Codigo { get; set; }
        public int? CodigoMenu { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public string? Resposta { get; set; }
        public string? Tipo { get; set; }
        public bool? Finalizar { get; set; }
    }

}
