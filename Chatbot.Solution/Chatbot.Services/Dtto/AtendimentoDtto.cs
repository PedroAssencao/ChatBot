
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
    public class AtendimentoDttoGet
    {
        public int Codigo { get; set; }
        public string? EstadoAtendimento { get; set; }
        public DateTime? Data { get; set; }
        public AtendenteDttoGet? Atendente { get; set; }
        public DepartamentoDttoGet? Departamento { get; set; }
        public ContatoDttoGetForView? Contato { get; set; }
        public LoginDttoGetForView? Login { get; set; }
    }

    public class AtendimentoDttoPost
    {
        public string? EstadoAtendimento { get; set; }
        public DateTime? Data { get; set; }
        public int? CodigoAtendente { get; set; }
        public int? CodigoDepartamento { get; set; }
        public int? CodigoContato { get; set; }
        public int? CodigoLogin { get; set; }
    }
    public class AtendimentoDttoPut
    {
        public int Codigo { get; set; }
        public string? EstadoAtendimento { get; set; }
        public DateTime? Data { get; set; }
        public int? CodigoAtendente { get; set; }
        public int? CodigoDepartamento { get; set; }
        public int? CodigoContato { get; set; }
        public int? CodigoLogin { get; set; }
    }

}
