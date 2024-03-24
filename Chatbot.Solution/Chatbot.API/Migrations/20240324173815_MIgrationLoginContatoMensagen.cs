using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chatbot.API.Migrations
{
    public partial class MIgrationLoginContatoMensagen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "login",
                columns: table => new
                {
                    log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    log_email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    log_senha = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    log_img = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    log_plano = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    log_user = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__login__9E2397E0C0BA34C1", x => x.log_id);
                });

            migrationBuilder.CreateTable(
                name: "contatos",
                columns: table => new
                {
                    con_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    con_WaId = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    con_nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    con_DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    con_BloqueadoStatus = table.Column<bool>(type: "bit", nullable: true),
                    log_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__contatos__081B0F1AE238EAA5", x => x.con_id);
                    table.ForeignKey(
                        name: "FK__contatos__log_id__619B8048",
                        column: x => x.log_id,
                        principalTable: "login",
                        principalColumn: "log_id");
                });

            migrationBuilder.CreateTable(
                name: "Mensagens",
                columns: table => new
                {
                    men_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    men_descricao = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    men_resposta = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    men_title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    men_Data = table.Column<DateTime>(type: "datetime", nullable: true),
                    men_tipo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    log_id = table.Column<int>(type: "int", nullable: false),
                    con_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Mensagen__387DDE002B87EB71", x => x.men_id);
                    table.ForeignKey(
                        name: "FK__Mensagens__con_i__693CA210",
                        column: x => x.con_id,
                        principalTable: "contatos",
                        principalColumn: "con_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Mensagens__log_i__68487DD7",
                        column: x => x.log_id,
                        principalTable: "login",
                        principalColumn: "log_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contatos_log_id",
                table: "contatos",
                column: "log_id");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagens_con_id",
                table: "Mensagens",
                column: "con_id");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagens_log_id",
                table: "Mensagens",
                column: "log_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mensagens");

            migrationBuilder.DropTable(
                name: "contatos");

            migrationBuilder.DropTable(
                name: "login");
        }
    }
}
