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

        public virtual DbSet<Atendente> Atendentes { get; set; } = null!;
        public virtual DbSet<Atendimento> Atendimentos { get; set; } = null!;
        public virtual DbSet<Contato> Contatos { get; set; } = null!;
        public virtual DbSet<Departamento> Departamentos { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Mensagen> Mensagens { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Option> Options { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Chinook");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atendente>(entity =>
            {
                entity.HasKey(e => e.AteId)
                    .HasName("PK__atendent__895194D62A291414");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Atendentes)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("FK__atendente__dep_i__6FE99F9F");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.Atendentes)
                    .HasForeignKey(d => d.LogId)
                    .HasConstraintName("FK__atendente__log_i__6EF57B66");
            });

            modelBuilder.Entity<Atendimento>(entity =>
            {
                entity.HasKey(e => e.AtenId)
                    .HasName("PK__Atendime__F4B66A4076DC8CE9");

                entity.HasOne(d => d.Ate)
                    .WithMany(p => p.Atendimentos)
                    .HasForeignKey(d => d.AteId)
                    .HasConstraintName("FK__Atendimen__ate_i__778AC167");

                entity.HasOne(d => d.Con)
                    .WithMany(p => p.Atendimentos)
                    .HasForeignKey(d => d.ConId)
                    .HasConstraintName("FK__Atendimen__con_i__797309D9");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Atendimentos)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("FK__Atendimen__dep_i__787EE5A0");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.Atendimentos)
                    .HasForeignKey(d => d.LogId)
                    .HasConstraintName("FK__Atendimen__log_i__7A672E12");
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

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.DepId)
                    .HasName("PK__departam__BB4BD8F85734EF12");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.Departamentos)
                    .HasForeignKey(d => d.LogId)
                    .HasConstraintName("FK__departame__log_i__6C190EBB");
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
                    .HasConstraintName("FK__Mensagens__con_i__693CA210");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.Mensagens)
                    .HasForeignKey(d => d.LogId)
                    .HasConstraintName("FK__Mensagens__log_i__68487DD7");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.MenId)
                    .HasName("PK__menus__387DDE00793E0D6B");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.LogId)
                    .HasConstraintName("FK__menus__log_id__7D439ABD");
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.HasKey(e => e.OptId)
                    .HasName("PK__options__84DB9F9BE51F8316");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.Options)
                    .HasForeignKey(d => d.LogId)
                    .HasConstraintName("FK__options__log_id__09A971A2");

                entity.HasOne(d => d.Men)
                    .WithMany(p => p.Options)
                    .HasForeignKey(d => d.MenId)
                    .HasConstraintName("FK__options__men_id__07C12930");

                entity.HasOne(d => d.Mens)
                    .WithMany(p => p.Options)
                    .HasForeignKey(d => d.MensId)
                    .HasConstraintName("FK__options__mens_id__08B54D69");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
