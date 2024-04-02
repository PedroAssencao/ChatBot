﻿// <auto-generated />
using System;
using Chatbot.API.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Chatbot.API.Migrations
{
    [DbContext(typeof(chatbotContext))]
    partial class chatbotContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Chatbot.API.Models.Atendente", b =>
                {
                    b.Property<int>("AteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ate_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AteId"), 1L, 1);

                    b.Property<string>("AteEmail")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ate_email");

                    b.Property<bool?>("AteEstado")
                        .HasColumnType("bit")
                        .HasColumnName("ate_estado");

                    b.Property<string>("AteImg")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("ate_img");

                    b.Property<string>("AteNome")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ate_Nome");

                    b.Property<string>("AteSenha")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ate_senha");

                    b.Property<int?>("DepId")
                        .HasColumnType("int")
                        .HasColumnName("dep_id");

                    b.Property<int?>("LogId")
                        .HasColumnType("int")
                        .HasColumnName("log_id");

                    b.HasKey("AteId")
                        .HasName("PK__atendent__895194D62A291414");

                    b.HasIndex(new[] { "DepId" }, "IX_atendentes_dep_id");

                    b.HasIndex(new[] { "LogId" }, "IX_atendentes_log_id");

                    b.ToTable("atendentes");
                });

            modelBuilder.Entity("Chatbot.API.Models.Atendimento", b =>
                {
                    b.Property<int>("AtenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("aten_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AtenId"), 1L, 1);

                    b.Property<int?>("AteId")
                        .HasColumnType("int")
                        .HasColumnName("ate_id");

                    b.Property<DateTime?>("AtenData")
                        .HasColumnType("datetime")
                        .HasColumnName("aten_data");

                    b.Property<string>("AtenEstado")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("aten_estado");

                    b.Property<int?>("ConId")
                        .HasColumnType("int")
                        .HasColumnName("con_id");

                    b.Property<int?>("DepId")
                        .HasColumnType("int")
                        .HasColumnName("dep_id");

                    b.Property<int?>("LogId")
                        .HasColumnType("int")
                        .HasColumnName("log_id");

                    b.HasKey("AtenId")
                        .HasName("PK__Atendime__F4B66A4076DC8CE9");

                    b.HasIndex(new[] { "AteId" }, "IX_Atendimento_ate_id");

                    b.HasIndex(new[] { "ConId" }, "IX_Atendimento_con_id");

                    b.HasIndex(new[] { "DepId" }, "IX_Atendimento_dep_id");

                    b.HasIndex(new[] { "LogId" }, "IX_Atendimento_log_id");

                    b.ToTable("Atendimento");
                });

            modelBuilder.Entity("Chatbot.API.Models.Contato", b =>
                {
                    b.Property<int>("ConId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("con_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConId"), 1L, 1);

                    b.Property<bool?>("ConBloqueadoStatus")
                        .HasColumnType("bit")
                        .HasColumnName("con_BloqueadoStatus");

                    b.Property<DateTime?>("ConDataCadastro")
                        .HasColumnType("datetime")
                        .HasColumnName("con_DataCadastro");

                    b.Property<string>("ConNome")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("con_nome");

                    b.Property<string>("ConWaId")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("con_WaId");

                    b.Property<int?>("LogId")
                        .HasColumnType("int")
                        .HasColumnName("log_id");

                    b.HasKey("ConId")
                        .HasName("PK__contatos__081B0F1AE238EAA5");

                    b.HasIndex(new[] { "LogId" }, "IX_contatos_log_id");

                    b.ToTable("contatos");
                });

            modelBuilder.Entity("Chatbot.API.Models.Departamento", b =>
                {
                    b.Property<int>("DepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("dep_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepId"), 1L, 1);

                    b.Property<string>("DepDescricao")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("dep_descricao");

                    b.Property<int?>("LogId")
                        .HasColumnType("int")
                        .HasColumnName("log_id");

                    b.HasKey("DepId")
                        .HasName("PK__departam__BB4BD8F85734EF12");

                    b.HasIndex(new[] { "LogId" }, "IX_departamento_log_id");

                    b.ToTable("departamento");
                });

            modelBuilder.Entity("Chatbot.API.Models.Login", b =>
                {
                    b.Property<int>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("log_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LogId"), 1L, 1);

                    b.Property<string>("LogEmail")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("log_email");

                    b.Property<string>("LogImg")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("log_img");

                    b.Property<string>("LogPlano")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("log_plano");

                    b.Property<string>("LogSenha")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("log_senha");

                    b.Property<string>("LogUser")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("log_user");

                    b.Property<string>("LogWaid")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("log_waid");

                    b.HasKey("LogId")
                        .HasName("PK__login__9E2397E0C0BA34C1");

                    b.ToTable("login");
                });

            modelBuilder.Entity("Chatbot.API.Models.Mensagen", b =>
                {
                    b.Property<int>("MenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("men_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenId"), 1L, 1);

                    b.Property<int?>("ConId")
                        .HasColumnType("int")
                        .HasColumnName("con_id");

                    b.Property<int?>("LogId")
                        .HasColumnType("int")
                        .HasColumnName("log_id");

                    b.Property<DateTime?>("MenData")
                        .HasColumnType("datetime")
                        .HasColumnName("men_Data");

                    b.Property<string>("MenDescricao")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("men_descricao");

                    b.Property<string>("MenResposta")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("men_resposta");

                    b.Property<string>("MenTipo")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("men_tipo");

                    b.Property<string>("MenTitle")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("men_title");

                    b.HasKey("MenId")
                        .HasName("PK__Mensagen__387DDE002B87EB71");

                    b.HasIndex(new[] { "ConId" }, "IX_Mensagens_con_id");

                    b.HasIndex(new[] { "LogId" }, "IX_Mensagens_log_id");

                    b.ToTable("Mensagens");
                });

            modelBuilder.Entity("Chatbot.API.Models.Menu", b =>
                {
                    b.Property<int>("MenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("men_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenId"), 1L, 1);

                    b.Property<int?>("LogId")
                        .HasColumnType("int")
                        .HasColumnName("log_id");

                    b.Property<string>("MenBody")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("men_body");

                    b.Property<string>("MenFooter")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("men_footer");

                    b.Property<string>("MenHeader")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("men_header");

                    b.Property<string>("MenTipo")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("men_tipo");

                    b.HasKey("MenId")
                        .HasName("PK__menus__387DDE00793E0D6B");

                    b.HasIndex(new[] { "LogId" }, "IX_menus_log_id");

                    b.ToTable("menus");
                });

            modelBuilder.Entity("Chatbot.API.Models.Option", b =>
                {
                    b.Property<int>("OptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("opt_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OptId"), 1L, 1);

                    b.Property<int?>("LogId")
                        .HasColumnType("int")
                        .HasColumnName("log_id");

                    b.Property<int?>("MenId")
                        .HasColumnType("int")
                        .HasColumnName("men_id");

                    b.Property<int?>("MensId")
                        .HasColumnType("int")
                        .HasColumnName("mens_id");

                    b.HasKey("OptId")
                        .HasName("PK__options__84DB9F9BE51F8316");

                    b.HasIndex(new[] { "LogId" }, "IX_options_log_id");

                    b.HasIndex(new[] { "MenId" }, "IX_options_men_id");

                    b.HasIndex(new[] { "MensId" }, "IX_options_mens_id");

                    b.ToTable("options");
                });

            modelBuilder.Entity("Chatbot.API.Models.Atendente", b =>
                {
                    b.HasOne("Chatbot.API.Models.Departamento", "Dep")
                        .WithMany("Atendentes")
                        .HasForeignKey("DepId")
                        .HasConstraintName("FK__atendente__dep_i__6FE99F9F");

                    b.HasOne("Chatbot.API.Models.Login", "Log")
                        .WithMany("Atendentes")
                        .HasForeignKey("LogId")
                        .HasConstraintName("FK__atendente__log_i__6EF57B66");

                    b.Navigation("Dep");

                    b.Navigation("Log");
                });

            modelBuilder.Entity("Chatbot.API.Models.Atendimento", b =>
                {
                    b.HasOne("Chatbot.API.Models.Atendente", "Ate")
                        .WithMany("Atendimentos")
                        .HasForeignKey("AteId")
                        .HasConstraintName("FK__Atendimen__ate_i__778AC167");

                    b.HasOne("Chatbot.API.Models.Contato", "Con")
                        .WithMany("Atendimentos")
                        .HasForeignKey("ConId")
                        .HasConstraintName("FK__Atendimen__con_i__797309D9");

                    b.HasOne("Chatbot.API.Models.Departamento", "Dep")
                        .WithMany("Atendimentos")
                        .HasForeignKey("DepId")
                        .HasConstraintName("FK__Atendimen__dep_i__787EE5A0");

                    b.HasOne("Chatbot.API.Models.Login", "Log")
                        .WithMany("Atendimentos")
                        .HasForeignKey("LogId")
                        .HasConstraintName("FK__Atendimen__log_i__7A672E12");

                    b.Navigation("Ate");

                    b.Navigation("Con");

                    b.Navigation("Dep");

                    b.Navigation("Log");
                });

            modelBuilder.Entity("Chatbot.API.Models.Contato", b =>
                {
                    b.HasOne("Chatbot.API.Models.Login", "Log")
                        .WithMany("Contatos")
                        .HasForeignKey("LogId")
                        .HasConstraintName("FK__contatos__log_id__619B8048");

                    b.Navigation("Log");
                });

            modelBuilder.Entity("Chatbot.API.Models.Departamento", b =>
                {
                    b.HasOne("Chatbot.API.Models.Login", "Log")
                        .WithMany("Departamentos")
                        .HasForeignKey("LogId")
                        .HasConstraintName("FK__departame__log_i__6C190EBB");

                    b.Navigation("Log");
                });

            modelBuilder.Entity("Chatbot.API.Models.Mensagen", b =>
                {
                    b.HasOne("Chatbot.API.Models.Contato", "Con")
                        .WithMany("Mensagens")
                        .HasForeignKey("ConId")
                        .HasConstraintName("FK__Mensagens__con_i__693CA210");

                    b.HasOne("Chatbot.API.Models.Login", "Log")
                        .WithMany("Mensagens")
                        .HasForeignKey("LogId")
                        .HasConstraintName("FK__Mensagens__log_i__68487DD7");

                    b.Navigation("Con");

                    b.Navigation("Log");
                });

            modelBuilder.Entity("Chatbot.API.Models.Menu", b =>
                {
                    b.HasOne("Chatbot.API.Models.Login", "Log")
                        .WithMany("Menus")
                        .HasForeignKey("LogId")
                        .HasConstraintName("FK__menus__log_id__7D439ABD");

                    b.Navigation("Log");
                });

            modelBuilder.Entity("Chatbot.API.Models.Option", b =>
                {
                    b.HasOne("Chatbot.API.Models.Login", "Log")
                        .WithMany("Options")
                        .HasForeignKey("LogId")
                        .HasConstraintName("FK__options__log_id__09A971A2");

                    b.HasOne("Chatbot.API.Models.Menu", "Men")
                        .WithMany("Options")
                        .HasForeignKey("MenId")
                        .HasConstraintName("FK__options__men_id__07C12930");

                    b.HasOne("Chatbot.API.Models.Mensagen", "Mens")
                        .WithMany("Options")
                        .HasForeignKey("MensId")
                        .HasConstraintName("FK__options__mens_id__08B54D69");

                    b.Navigation("Log");

                    b.Navigation("Men");

                    b.Navigation("Mens");
                });

            modelBuilder.Entity("Chatbot.API.Models.Atendente", b =>
                {
                    b.Navigation("Atendimentos");
                });

            modelBuilder.Entity("Chatbot.API.Models.Contato", b =>
                {
                    b.Navigation("Atendimentos");

                    b.Navigation("Mensagens");
                });

            modelBuilder.Entity("Chatbot.API.Models.Departamento", b =>
                {
                    b.Navigation("Atendentes");

                    b.Navigation("Atendimentos");
                });

            modelBuilder.Entity("Chatbot.API.Models.Login", b =>
                {
                    b.Navigation("Atendentes");

                    b.Navigation("Atendimentos");

                    b.Navigation("Contatos");

                    b.Navigation("Departamentos");

                    b.Navigation("Mensagens");

                    b.Navigation("Menus");

                    b.Navigation("Options");
                });

            modelBuilder.Entity("Chatbot.API.Models.Mensagen", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("Chatbot.API.Models.Menu", b =>
                {
                    b.Navigation("Options");
                });
#pragma warning restore 612, 618
        }
    }
}
