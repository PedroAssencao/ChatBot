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

            modelBuilder.Entity("Chatbot.API.Models.BoTrespostum", b =>
                {
                    b.Property<int>("BotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("bot_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BotId"), 1L, 1);

                    b.Property<string>("BotTimeStamp")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("bot_timeStamp");

                    b.Property<string>("CatWaId")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("cat_wa_id");

                    b.HasKey("BotId")
                        .HasName("PK__BoTRespo__310884E0F06C7421");

                    b.ToTable("BoTResposta");
                });

            modelBuilder.Entity("Chatbot.API.Models.Cadastro", b =>
                {
                    b.Property<int>("CadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cad_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CadId"), 1L, 1);

                    b.Property<string>("CatTimeStamp")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("cat_timeStamp");

                    b.Property<string>("CatWaId")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("cat_wa_id");

                    b.HasKey("CadId")
                        .HasName("PK__cadastro__39523F7CBD4EBC79");

                    b.ToTable("cadastro");
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

                    b.HasIndex("LogId");

                    b.ToTable("contatos");
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
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("con_id");

                    b.Property<int?>("LogId")
                        .IsRequired()
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

                    b.HasIndex("ConId");

                    b.HasIndex("LogId");

                    b.ToTable("Mensagens");
                });

            modelBuilder.Entity("Chatbot.API.Models.Contato", b =>
                {
                    b.HasOne("Chatbot.API.Models.Login", "Log")
                        .WithMany("Contatos")
                        .HasForeignKey("LogId")
                        .HasConstraintName("FK__contatos__log_id__619B8048");

                    b.Navigation("Log");
                });

            modelBuilder.Entity("Chatbot.API.Models.Mensagen", b =>
                {
                    b.HasOne("Chatbot.API.Models.Contato", "Con")
                        .WithMany("Mensagens")
                        .HasForeignKey("ConId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Mensagens__con_i__693CA210");

                    b.HasOne("Chatbot.API.Models.Login", "Log")
                        .WithMany("Mensagens")
                        .HasForeignKey("LogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Mensagens__log_i__68487DD7");

                    b.Navigation("Con");

                    b.Navigation("Log");
                });

            modelBuilder.Entity("Chatbot.API.Models.Contato", b =>
                {
                    b.Navigation("Mensagens");
                });

            modelBuilder.Entity("Chatbot.API.Models.Login", b =>
                {
                    b.Navigation("Contatos");

                    b.Navigation("Mensagens");
                });
#pragma warning restore 612, 618
        }
    }
}
