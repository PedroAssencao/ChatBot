using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Chatbot.API.Models
{
    [Table("departamento")]
    [Index(nameof(LogId), Name = "IX_departamento_log_id")]
    public partial class Departamento
    {
        public Departamento()
        {
            Atendentes = new HashSet<Atendente>();
            Atendimentos = new HashSet<Atendimento>();
        }

        [Key]
        [Column("dep_id")]
        public int DepId { get; set; }
        [Column("dep_descricao")]
        [StringLength(255)]
        [Unicode(false)]
        public string? DepDescricao { get; set; }
        [Column("log_id")]
        public int? LogId { get; set; }

        [ForeignKey(nameof(LogId))]
        [InverseProperty(nameof(Login.Departamentos))]
        public virtual Login? Log { get; set; }
        [InverseProperty(nameof(Atendente.Dep))]
        public virtual ICollection<Atendente> Atendentes { get; set; }
        [InverseProperty(nameof(Atendimento.Dep))]
        public virtual ICollection<Atendimento> Atendimentos { get; set; }
    }
}
