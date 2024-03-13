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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
