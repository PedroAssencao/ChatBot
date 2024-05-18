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
    public class AtendimentoDttoForView
    {
        public int Codigo { get; set; }
        public string? EstadoAtendimento { get; set; }
        public DateTime? Data { get; set; }
        public DepartamentoDttoGet? Departamento { get; set; }
    }
}
