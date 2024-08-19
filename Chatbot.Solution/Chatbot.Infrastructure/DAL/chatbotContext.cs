using System;
using System.Collections.Generic;
using Chatbot.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Chatbot.API.DAL;

public partial class chatbotContext : DbContext
{
    public chatbotContext()
    {
    }

    public chatbotContext(DbContextOptions<chatbotContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Atendente> Atendentes { get; set; }

    public virtual DbSet<Atendimento> Atendimentos { get; set; }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<Contato> Contatos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<MensagemProgramadum> MensagemProgramada { get; set; }

    public virtual DbSet<Mensagen> Mensagens { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Option> Options { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Chinook");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Atendente>(entity =>
        {
            entity.HasKey(e => e.AteId).HasName("PK__atendent__895194D61DCECD42");

            entity.HasOne(d => d.Dep).WithMany(p => p.Atendentes)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_departamento");

            entity.HasOne(d => d.Log).WithMany(p => p.Atendentes)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_login");
        });

        modelBuilder.Entity<Atendimento>(entity =>
        {
            entity.HasKey(e => e.AtenId).HasName("PK__Atendime__F4B66A4003AC6F42");

            entity.HasOne(d => d.Ate).WithMany(p => p.Atendimentos)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_atendentes");

            entity.HasOne(d => d.Con).WithMany(p => p.Atendimentos)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_contatos");

            entity.HasOne(d => d.Dep).WithMany(p => p.Atendimentos)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_departamento_atendimento");

            entity.HasOne(d => d.Log).WithMany(p => p.Atendimentos)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_login_atendimento");
        });

        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasKey(e => e.ChaId).HasName("PK__chat__5AF8FDEA0118BE72");

            entity.HasOne(d => d.Ate).WithMany(p => p.Chats)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_atendentes_chat");

            entity.HasOne(d => d.Aten).WithMany(p => p.Chats)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_atendimento_chat");

            entity.HasOne(d => d.Con).WithMany(p => p.Chats)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_contatos_chat");

            entity.HasOne(d => d.Log).WithMany(p => p.Chats)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_login_chat");
        });

        modelBuilder.Entity<Contato>(entity =>
        {
            entity.HasKey(e => e.ConId).HasName("PK__contatos__081B0F1A719B7A4E");

            entity.HasOne(d => d.Log).WithMany(p => p.Contatos)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_login_contatos");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.DepId).HasName("PK__departam__BB4BD8F85FDF82CD");

            entity.HasOne(d => d.Log).WithMany(p => p.Departamentos)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_login_departamento");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__login__9E2397E034D38445");
        });

        modelBuilder.Entity<MensagemProgramadum>(entity =>
        {
            entity.HasKey(e => e.MemproId).HasName("PK__Mensagem__DCF4E3C8E6762059");

            entity.HasOne(d => d.Log).WithMany(p => p.MensagemProgramada)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_login_mensagemprogramada");
        });

        modelBuilder.Entity<Mensagen>(entity =>
        {
            entity.HasKey(e => e.MensId).HasName("PK__Mensagen__763E9E0A525F8A04");

            entity.HasOne(d => d.Cha).WithMany(p => p.Mensagens)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_chat_mensagens");

            entity.HasOne(d => d.Con).WithMany(p => p.Mensagens)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_contatos_mensagens");

            entity.HasOne(d => d.Log).WithMany(p => p.Mensagens)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_login_mensagens");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenId).HasName("PK__menus__387DDE0096350796");

            entity.HasOne(d => d.Log).WithMany(p => p.Menus)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_login_menus");
        });

        modelBuilder.Entity<Option>(entity =>
        {
            entity.HasKey(e => e.OptId).HasName("PK__options__84DB9F9B8BB66F03");

            entity.HasOne(d => d.Log).WithMany(p => p.Options)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_login_options");

            entity.HasOne(d => d.Men).WithMany(p => p.Options)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_menus_options");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
