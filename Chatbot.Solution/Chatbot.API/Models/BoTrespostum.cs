using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Chatbot.API.Models
{
    [Table("BoTResposta")]
    public partial class BoTrespostum
    {
        [Key]
        [Column("bot_id")]
        public int BotId { get; set; }
        [Column("bot_timeStamp")]
        [StringLength(255)]
        [Unicode(false)]
        public string? BotTimeStamp { get; set; }
        [Column("cat_wa_id")]
        [StringLength(255)]
        [Unicode(false)]
        public string? CatWaId { get; set; }
    }
}
