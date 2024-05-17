﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Chatbot.API.Models
{
    public partial class Mensagen
    {
        [Key]
        [Column("mens_id")]
        public int MensId { get; set; }
        [Column("mens_data", TypeName = "datetime")]
        public DateTime? MensData { get; set; }
        [Column("mens_descricao")]
        [Unicode(false)]
        public string? MensDescricao { get; set; }
        [Column("men_tipo")]
        [StringLength(255)]
        [Unicode(false)]
        public string? MenTipo { get; set; }
        [Column("con_id")]
        public int? ConId { get; set; }
        [Column("log_id")]
        public int? LogId { get; set; }
        [Column("cha_id")]
        public int? ChaId { get; set; }

        [ForeignKey(nameof(ChaId))]
        [InverseProperty(nameof(Chat.Mensagens))]
        public virtual Chat? Cha { get; set; }
        [ForeignKey(nameof(ConId))]
        [InverseProperty(nameof(Contato.Mensagens))]
        public virtual Contato? Con { get; set; }
        [ForeignKey(nameof(LogId))]
        [InverseProperty(nameof(Login.Mensagens))]
        public virtual Login? Log { get; set; }
    }
}
