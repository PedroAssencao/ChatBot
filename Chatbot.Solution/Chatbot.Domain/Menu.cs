using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Chatbot.API;

[Table("menus")]
public partial class Menu
{
    [Key]
    [Column("men_id")]
    public int MenId { get; set; }

    [Column("men_title")]
    [StringLength(255)]
    [Unicode(false)]
    public string? MenTitle { get; set; }

    [Column("men_header")]
    [StringLength(255)]
    [Unicode(false)]
    public string? MenHeader { get; set; }

    [Column("men_footer")]
    [StringLength(255)]
    [Unicode(false)]
    public string? MenFooter { get; set; }

    [Column("men_body")]
    [StringLength(255)]
    [Unicode(false)]
    public string? MenBody { get; set; }

    [Column("log_id")]
    public int? LogId { get; set; }

    [ForeignKey("LogId")]
    [InverseProperty("Menus")]
    public virtual Login? Log { get; set; }

    [InverseProperty("Men")]
    public virtual ICollection<Option> Options { get; set; } = new List<Option>();
}
