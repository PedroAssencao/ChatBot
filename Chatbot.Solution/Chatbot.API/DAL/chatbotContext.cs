using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Chatbot.API.Models;

namespace Chatbot.API.DAL
{
    public partial class chatbotContext : DbContext
    {
        public chatbotContext()
        {
        }

        public chatbotContext(DbContextOptions<chatbotContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BoTrespostum> BoTresposta { get; set; } = null!;
        public virtual DbSet<Cadastro> Cadastros { get; set; } = null!;
        public virtual DbSet<Contato> Contatos { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Mensagen> Mensagens { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Chinook");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoTrespostum>(entity =>
            {
                entity.HasKey(e => e.BotId)
                    .HasName("PK__BoTRespo__310884E0F06C7421");
            });

            modelBuilder.Entity<Cadastro>(entity =>
            {
                entity.HasKey(e => e.CadId)
                    .HasName("PK__cadastro__39523F7CBD4EBC79");
            });

            modelBuilder.Entity<Contato>(entity =>
            {
                entity.HasKey(e => e.ConId)
                    .HasName("PK__contatos__081B0F1AE238EAA5");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.Contatos)
                    .HasForeignKey(d => d.LogId)
                    .HasConstraintName("FK__contatos__log_id__619B8048");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__login__9E2397E0C0BA34C1");
            });

            modelBuilder.Entity<Mensagen>(entity =>
            {
                entity.HasKey(e => e.MenId)
                    .HasName("PK__Mensagen__387DDE002B87EB71");

                entity.HasOne(d => d.Con)
                    .WithMany(p => p.Mensagens)
                    .HasForeignKey(d => d.ConId)
                    .HasConstraintName("FK__Mensagens__con_i__693CA210")
                    .IsRequired();

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.Mensagens)
                    .HasForeignKey(d => d.LogId)
                    .HasConstraintName("FK__Mensagens__log_i__68487DD7")
                    .IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
