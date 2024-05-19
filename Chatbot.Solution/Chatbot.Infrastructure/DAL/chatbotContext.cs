using Microsoft.EntityFrameworkCore;
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
        public virtual DbSet<Chat> Chats { get; set; } = null!;
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
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-02BUU56;Initial Catalog=chatbot;Integrated Security=True;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atendente>(entity =>
            {
                entity.HasKey(e => e.AteId)
                    .HasName("PK__atendent__895194D66F1FCCAC");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Atendentes)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("FK__atendente__dep_i__5629CD9C");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.Atendentes)
                    .HasForeignKey(d => d.LogId)
                    .HasConstraintName("FK__atendente__log_i__5535A963");
            });

            modelBuilder.Entity<Atendimento>(entity =>
            {
                entity.HasKey(e => e.AtenId)
                    .HasName("PK__Atendime__F4B66A40AF98F0D3");

                entity.HasOne(d => d.Ate)
                    .WithMany(p => p.Atendimentos)
                    .HasForeignKey(d => d.AteId)
                    .HasConstraintName("FK__Atendimen__ate_i__59063A47");

                entity.HasOne(d => d.Con)
                    .WithMany(p => p.Atendimentos)
                    .HasForeignKey(d => d.ConId)
                    .HasConstraintName("FK__Atendimen__con_i__5AEE82B9");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Atendimentos)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("FK__Atendimen__dep_i__59FA5E80");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.Atendimentos)
                    .HasForeignKey(d => d.LogId)
                    .HasConstraintName("FK__Atendimen__log_i__5BE2A6F2");
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.HasKey(e => e.ChaId)
                    .HasName("PK__chat__5AF8FDEA98C97753");

                entity.HasOne(d => d.Ate)
                    .WithMany(p => p.Chats)
                    .HasForeignKey(d => d.AteId)
                    .HasConstraintName("FK__chat__ate_id__5DCAEF64");

                entity.HasOne(d => d.Con)
                    .WithMany(p => p.Chats)
                    .HasForeignKey(d => d.ConId)
                    .HasConstraintName("FK__chat__con_id__5FB337D6");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.Chats)
                    .HasForeignKey(d => d.LogId)
                    .HasConstraintName("FK__chat__log_id__5EBF139D");
            });

            modelBuilder.Entity<Contato>(entity =>
            {
                entity.HasKey(e => e.ConId)
                    .HasName("PK__contatos__081B0F1A19F19A4D");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.Contatos)
                    .HasForeignKey(d => d.LogId)
                    .HasConstraintName("FK__contatos__log_id__4BAC3F29");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.DepId)
                    .HasName("PK__departam__BB4BD8F8671B8661");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.Departamentos)
                    .HasForeignKey(d => d.LogId)
                    .HasConstraintName("FK__departame__log_i__52593CB8");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__login__9E2397E0969F58EA");
            });

            modelBuilder.Entity<Mensagen>(entity =>
            {
                entity.HasKey(e => e.MensId)
                    .HasName("PK__Mensagen__763E9E0AF88E2D22");

                entity.HasOne(d => d.Cha)
                    .WithMany(p => p.Mensagens)
                    .HasForeignKey(d => d.ChaId)
                    .HasConstraintName("FK__Mensagens__cha_i__6477ECF3");

                entity.HasOne(d => d.Con)
                    .WithMany(p => p.Mensagens)
                    .HasForeignKey(d => d.ConId)
                    .HasConstraintName("FK__Mensagens__con_i__628FA481");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.Mensagens)
                    .HasForeignKey(d => d.LogId)
                    .HasConstraintName("FK__Mensagens__log_i__6383C8BA");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.MenId)
                    .HasName("PK__menus__387DDE00860AE6CD");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.LogId)
                    .HasConstraintName("FK__menus__log_id__5EBF139D");
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.HasKey(e => e.OptId)
                    .HasName("PK__options__84DB9F9BC598D2A7");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.Options)
                    .HasForeignKey(d => d.LogId)
                    .HasConstraintName("FK__options__log_id__619B8048");

                entity.HasOne(d => d.Men)
                    .WithMany(p => p.Options)
                    .HasForeignKey(d => d.MenId)
                    .HasConstraintName("FK__options__men_id__628FA481");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
