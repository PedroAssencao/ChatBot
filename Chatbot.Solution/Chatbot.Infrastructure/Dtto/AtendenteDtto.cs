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
    public class AtendenteDttoForView
    {
        public int Codigo { get; set; }
        public string? Nome { get; set; }
        public bool? EstadoAtendente { get; set; }
        public DepartamentoDttoGet? Departamento { get; set; }
    }
}
