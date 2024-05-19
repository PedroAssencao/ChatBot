using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Chatbot.API;

[Table("login")]
public partial class Login
{
    [Key]
    [Column("log_id")]
    public int LogId { get; set; }

    [Column("log_user")]
    [StringLength(255)]
    [Unicode(false)]
    public string? LogUser { get; set; }

    [Column("log_email")]
    [StringLength(255)]
    [Unicode(false)]
    public string? LogEmail { get; set; }

    [Column("log_senha")]
    [StringLength(255)]
    [Unicode(false)]
    public string? LogSenha { get; set; }

    [Column("log_img")]
    [Unicode(false)]
    public string? LogImg { get; set; }

    [Column("log_plano")]
    [StringLength(255)]
    [Unicode(false)]
    public string? LogPlano { get; set; }

    [Column("log_waid")]
    [StringLength(255)]
    [Unicode(false)]
    public string? LogWaid { get; set; }

    [InverseProperty("Log")]
    public virtual ICollection<Atendente> Atendentes { get; set; } = new List<Atendente>();

    [InverseProperty("Log")]
    public virtual ICollection<Atendimento> Atendimentos { get; set; } = new List<Atendimento>();

    [InverseProperty("Log")]
    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();

    [InverseProperty("Log")]
    public virtual ICollection<Contato> Contatos { get; set; } = new List<Contato>();

    [InverseProperty("Log")]
    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();

    [InverseProperty("Log")]
    public virtual ICollection<Mensagen> Mensagens { get; set; } = new List<Mensagen>();

    [InverseProperty("Log")]
    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();

    [InverseProperty("Log")]
    public virtual ICollection<Option> Options { get; set; } = new List<Option>();
}
