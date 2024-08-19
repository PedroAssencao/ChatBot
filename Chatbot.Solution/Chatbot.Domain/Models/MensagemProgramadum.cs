using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Chatbot.Domain.Models;

public partial class MensagemProgramadum
{
    [Key]
    [Column("mempro_id")]
    public int MemproId { get; set; }

    [Column("mempro_datacriada", TypeName = "datetime")]
    public DateTime? MemproDatacriada { get; set; }

    [Column("mempro_dataenvio", TypeName = "datetime")]
    public DateTime? MemproDataenvio { get; set; }

    [Column("mempro_descricao")]
    [Unicode(false)]
    public string? MemproDescricao { get; set; }

    [Column("mempro_tipo")]
    [StringLength(255)]
    [Unicode(false)]
    public string? MemproTipo { get; set; }

    [Column("log_id")]
    public int? LogId { get; set; }

    [ForeignKey("LogId")]
    [InverseProperty("MensagemProgramada")]
    public virtual Login? Log { get; set; }
}
