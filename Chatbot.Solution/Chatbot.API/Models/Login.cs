﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Chatbot.API.Models
{
    [Table("login")]
    public partial class Login
    {
        public Login()
        {
            Atendentes = new HashSet<Atendente>();
            Atendimentos = new HashSet<Atendimento>();
            Contatos = new HashSet<Contato>();
            Departamentos = new HashSet<Departamento>();
            Mensagens = new HashSet<Mensagen>();
        }

        [Key]
        [Column("log_id")]
        public int LogId { get; set; }
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
        [Column("log_user")]
        [StringLength(255)]
        [Unicode(false)]
        public string? LogUser { get; set; }

        [InverseProperty(nameof(Atendente.Log))]
        public virtual ICollection<Atendente> Atendentes { get; set; }
        [InverseProperty(nameof(Atendimento.Log))]
        public virtual ICollection<Atendimento> Atendimentos { get; set; }
        [InverseProperty(nameof(Contato.Log))]
        public virtual ICollection<Contato> Contatos { get; set; }
        [InverseProperty(nameof(Departamento.Log))]
        public virtual ICollection<Departamento> Departamentos { get; set; }
        [InverseProperty(nameof(Mensagen.Log))]
        public virtual ICollection<Mensagen> Mensagens { get; set; }
    }
}
