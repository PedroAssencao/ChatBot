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
        [Column("men_id")]
        public int MenId { get; set; }
        [Column("men_descricao")]
        [StringLength(255)]
        [Unicode(false)]
        public string? MenDescricao { get; set; }
        [Column("men_resposta")]
        [StringLength(255)]
        [Unicode(false)]
        public string? MenResposta { get; set; }
        [Column("men_title")]
        [StringLength(255)]
        [Unicode(false)]
        public string? MenTitle { get; set; }
        [Column("men_Data", TypeName = "datetime")]
        public DateTime? MenData { get; set; }
        [Column("men_tipo")]
        [StringLength(255)]
        [Unicode(false)]
        public string? MenTipo { get; set; }
        [Column("log_id")]
        public int? LogId { get; set; }
        [Column("con_id")]
        public int? ConId { get; set; }

        [ForeignKey(nameof(ConId))]
        [InverseProperty(nameof(Contato.Mensagens))]
        public virtual Contato? Con { get; set; }
        [ForeignKey(nameof(LogId))]
        [InverseProperty(nameof(Login.Mensagens))]
        public virtual Login? Log { get; set; }
    }
}
