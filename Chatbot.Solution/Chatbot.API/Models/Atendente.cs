using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Chatbot.API.Models
{
    [Table("atendentes")]
    public partial class Atendente
    {
        public Atendente()
        {
            Atendimentos = new HashSet<Atendimento>();
        }

        [Key]
        [Column("ate_id")]
        public int AteId { get; set; }
        [Column("ate_email")]
        [StringLength(255)]
        [Unicode(false)]
        public string? AteEmail { get; set; }
        [Column("ate_Nome")]
        [StringLength(255)]
        [Unicode(false)]
        public string? AteNome { get; set; }
        [Column("ate_img")]
        [Unicode(false)]
        public string? AteImg { get; set; }
        [Column("ate_senha")]
        [StringLength(255)]
        [Unicode(false)]
        public string? AteSenha { get; set; }
        [Column("ate_estado")]
        public bool? AteEstado { get; set; }
        [Column("log_id")]
        public int? LogId { get; set; }
        [Column("dep_id")]
        public int? DepId { get; set; }

        [ForeignKey(nameof(DepId))]
        [InverseProperty(nameof(Departamento.Atendentes))]
        public virtual Departamento? Dep { get; set; }
        [ForeignKey(nameof(LogId))]
        [InverseProperty(nameof(Login.Atendentes))]
        public virtual Login? Log { get; set; }
        [InverseProperty(nameof(Atendimento.Ate))]
        public virtual ICollection<Atendimento> Atendimentos { get; set; }
    }
}
