using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Chatbot.API.Models
{
    [Table("options")]
    [Index(nameof(LogId), Name = "IX_options_log_id")]
    [Index(nameof(MenId), Name = "IX_options_men_id")]
    [Index(nameof(MensId), Name = "IX_options_mens_id")]
    public partial class Option
    {
        [Key]
        [Column("opt_id")]
        public int OptId { get; set; }
        [Column("men_id")]
        public int? MenId { get; set; }
        [Column("mens_id")]
        public int? MensId { get; set; }
        [Column("log_id")]
        public int? LogId { get; set; }

        [ForeignKey(nameof(LogId))]
        [InverseProperty(nameof(Login.Options))]
        public virtual Login? Log { get; set; }
        [ForeignKey(nameof(MenId))]
        [InverseProperty(nameof(Menu.Options))]
        public virtual Menu? Men { get; set; }
        [ForeignKey(nameof(MensId))]
        [InverseProperty(nameof(Mensagen.Options))]
        public virtual Mensagen? Mens { get; set; }
    }
}
