using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Chatbot.API.Models
{
    [Table("cadastro")]
    public partial class Cadastro
    {
        [Key]
        [Column("cad_id")]
        public int CadId { get; set; }
        [Column("cat_timeStamp")]
        [StringLength(255)]
        [Unicode(false)]
        public string? CatTimeStamp { get; set; }
        [Column("cat_wa_id")]
        [StringLength(255)]
        [Unicode(false)]
        public string? CatWaId { get; set; }
    }
}
