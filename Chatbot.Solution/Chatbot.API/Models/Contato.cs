using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Chatbot.API.Models
{
    [Table("contatos")]
    [Index(nameof(LogId), Name = "IX_contatos_log_id")]
    public partial class Contato
    {
        public Contato()
        {
            Atendimentos = new HashSet<Atendimento>();
            Mensagens = new HashSet<Mensagen>();
        }

        [Key]
        [Column("con_id")]
        public int ConId { get; set; }
        [Column("con_WaId")]
        [StringLength(255)]
        [Unicode(false)]
        public string? ConWaId { get; set; }
        [Column("con_nome")]
        [StringLength(255)]
        [Unicode(false)]
        public string? ConNome { get; set; }
        [Column("con_DataCadastro", TypeName = "datetime")]
        public DateTime? ConDataCadastro { get; set; }
        [Column("con_BloqueadoStatus")]
        public bool? ConBloqueadoStatus { get; set; }
        [Column("log_id")]
        public int? LogId { get; set; }

        [ForeignKey(nameof(LogId))]
        [InverseProperty(nameof(Login.Contatos))]
        public virtual Login? Log { get; set; }
        [JsonIgnore]
        [InverseProperty(nameof(Atendimento.Con))]
        public virtual ICollection<Atendimento> Atendimentos { get; set; }
        [JsonIgnore]
        [InverseProperty(nameof(Mensagen.Con))]
        public virtual ICollection<Mensagen> Mensagens { get; set; }
    }
}
