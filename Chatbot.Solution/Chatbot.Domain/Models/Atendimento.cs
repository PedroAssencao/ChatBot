using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Chatbot.API.Models
{
    [Table("Atendimento")]
    [Index(nameof(AteId), Name = "IX_Atendimento_ate_id")]
    [Index(nameof(ConId), Name = "IX_Atendimento_con_id")]
    [Index(nameof(DepId), Name = "IX_Atendimento_dep_id")]
    [Index(nameof(LogId), Name = "IX_Atendimento_log_id")]
    public partial class Atendimento
    {
        [Key]
        [Column("aten_id")]
        public int AtenId { get; set; }
        [Column("aten_estado")]
        [StringLength(255)]
        [Unicode(false)]
        public string? AtenEstado { get; set; }
        [Column("aten_data", TypeName = "datetime")]
        public DateTime? AtenData { get; set; }
        [Column("ate_id")]
        public int? AteId { get; set; }
        [Column("dep_id")]
        public int? DepId { get; set; }
        [Column("con_id")]
        public int? ConId { get; set; }
        [Column("log_id")]
        public int? LogId { get; set; }

        [ForeignKey(nameof(AteId))]
        [InverseProperty(nameof(Atendente.Atendimentos))]
        public virtual Atendente? Ate { get; set; }
        [ForeignKey(nameof(ConId))]
        [InverseProperty(nameof(Contato.Atendimentos))]
        public virtual Contato? Con { get; set; }
        [ForeignKey(nameof(DepId))]
        [InverseProperty(nameof(Departamento.Atendimentos))]
        public virtual Departamento? Dep { get; set; }
        [ForeignKey(nameof(LogId))]
        [InverseProperty(nameof(Login.Atendimentos))]
        public virtual Login? Log { get; set; }
    }
}
