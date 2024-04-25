using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Chatbot.API.Models
{
    [Index(nameof(ConId), Name = "IX_Mensagens_con_id")]
    [Index(nameof(LogId), Name = "IX_Mensagens_log_id")]
    public partial class Mensagen
    {
        [Key]
        [Column("mens_id")]
        public int MensId { get; set; }
        [Column("mens_data", TypeName = "datetime")]
        public DateTime? MensData { get; set; }
        [Column("men_tipo")]
        [StringLength(255)]
        [Unicode(false)]
        public string? MenTipo { get; set; }
        [Column("log_id")]
        public int? LogId { get; set; }
        [Column("con_id")]
        public int? ConId { get; set; }
        [Column("mens_descricao")]
        [Unicode(false)]
        public string? MensDescricao { get; set; }

        [ForeignKey(nameof(ConId))]
        [InverseProperty(nameof(Contato.Mensagens))]
        public virtual Contato? Con { get; set; }
        [ForeignKey(nameof(LogId))]
        [InverseProperty(nameof(Login.Mensagens))]
        public virtual Login? Log { get; set; }
    }
}
