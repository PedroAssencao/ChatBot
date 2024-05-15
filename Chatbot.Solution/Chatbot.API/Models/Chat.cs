using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Chatbot.API.Models
{
    [Table("chat")]
    public partial class Chat
    {
        public Chat()
        {
            Mensagens = new HashSet<Mensagen>();
        }

        [Key]
        [Column("cha_id")]
        public int ChaId { get; set; }
        [Column("ate_id")]
        public int? AteId { get; set; }
        [Column("log_id")]
        public int? LogId { get; set; }
        [Column("con_id")]
        public int? ConId { get; set; }

        [ForeignKey(nameof(AteId))]
        [InverseProperty(nameof(Atendente.Chats))]
        public virtual Atendente? Ate { get; set; }
        [ForeignKey(nameof(ConId))]
        [InverseProperty(nameof(Contato.Chats))]
        public virtual Contato? Con { get; set; }
        [ForeignKey(nameof(LogId))]
        [InverseProperty(nameof(Login.Chats))]
        public virtual Login? Log { get; set; }
        [InverseProperty(nameof(Mensagen.Cha))]
        public virtual ICollection<Mensagen> Mensagens { get; set; }
    }
}
