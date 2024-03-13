﻿// <auto-generated />
using Chatbot.API.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Chatbot.API.Migrations
{
    [DbContext(typeof(chatbotContext))]
    [Migration("20240313201403_BotResposta")]
    partial class BotResposta
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
#pragma warning restore 612, 618
        }
    }
}
