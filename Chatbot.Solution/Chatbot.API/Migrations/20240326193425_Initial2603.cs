using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chatbot.API.Migrations
{
    public partial class Initial2603 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Mensagens__con_i__693CA210",
                table: "Mensagens");

            migrationBuilder.DropForeignKey(
                name: "FK__Mensagens__log_i__68487DD7",
                table: "Mensagens");

            migrationBuilder.DropTable(
                name: "BoTResposta");

            migrationBuilder.DropTable(
                name: "cadastro");

            migrationBuilder.AlterColumn<int>(
                name: "log_id",
                table: "Mensagens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "con_id",
                table: "Mensagens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    dep_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dep_descricao = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    log_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__departam__BB4BD8F85734EF12", x => x.dep_id);
                    table.ForeignKey(
                        name: "FK__departame__log_i__6C190EBB",
                        column: x => x.log_id,
                        principalTable: "login",
                        principalColumn: "log_id");
                });

            migrationBuilder.CreateTable(
                name: "atendentes",
                columns: table => new
                {
                    ate_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ate_email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ate_Nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ate_img = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ate_senha = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ate_estado = table.Column<bool>(type: "bit", nullable: true),
                    log_id = table.Column<int>(type: "int", nullable: true),
                    dep_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__atendent__895194D62A291414", x => x.ate_id);
                    table.ForeignKey(
                        name: "FK__atendente__dep_i__6FE99F9F",
                        column: x => x.dep_id,
                        principalTable: "departamento",
                        principalColumn: "dep_id");
                    table.ForeignKey(
                        name: "FK__atendente__log_i__6EF57B66",
                        column: x => x.log_id,
                        principalTable: "login",
                        principalColumn: "log_id");
                });

            migrationBuilder.CreateTable(
                name: "Atendimento",
                columns: table => new
                {
                    aten_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aten_estado = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    aten_data = table.Column<DateTime>(type: "datetime", nullable: true),
                    ate_id = table.Column<int>(type: "int", nullable: true),
                    dep_id = table.Column<int>(type: "int", nullable: true),
                    con_id = table.Column<int>(type: "int", nullable: true),
                    log_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Atendime__F4B66A4076DC8CE9", x => x.aten_id);
                    table.ForeignKey(
                        name: "FK__Atendimen__ate_i__778AC167",
                        column: x => x.ate_id,
                        principalTable: "atendentes",
                        principalColumn: "ate_id");
                    table.ForeignKey(
                        name: "FK__Atendimen__con_i__797309D9",
                        column: x => x.con_id,
                        principalTable: "contatos",
                        principalColumn: "con_id");
                    table.ForeignKey(
                        name: "FK__Atendimen__dep_i__787EE5A0",
                        column: x => x.dep_id,
                        principalTable: "departamento",
                        principalColumn: "dep_id");
                    table.ForeignKey(
                        name: "FK__Atendimen__log_i__7A672E12",
                        column: x => x.log_id,
                        principalTable: "login",
                        principalColumn: "log_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_atendentes_dep_id",
                table: "atendentes",
                column: "dep_id");

            migrationBuilder.CreateIndex(
                name: "IX_atendentes_log_id",
                table: "atendentes",
                column: "log_id");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_ate_id",
                table: "Atendimento",
                column: "ate_id");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_con_id",
                table: "Atendimento",
                column: "con_id");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_dep_id",
                table: "Atendimento",
                column: "dep_id");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_log_id",
                table: "Atendimento",
                column: "log_id");

            migrationBuilder.CreateIndex(
                name: "IX_departamento_log_id",
                table: "departamento",
                column: "log_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Mensagens__con_i__693CA210",
                table: "Mensagens",
                column: "con_id",
                principalTable: "contatos",
                principalColumn: "con_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Mensagens__log_i__68487DD7",
                table: "Mensagens",
                column: "log_id",
                principalTable: "login",
                principalColumn: "log_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Mensagens__con_i__693CA210",
                table: "Mensagens");

            migrationBuilder.DropForeignKey(
                name: "FK__Mensagens__log_i__68487DD7",
                table: "Mensagens");

            migrationBuilder.DropTable(
                name: "Atendimento");

            migrationBuilder.DropTable(
                name: "atendentes");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.AlterColumn<int>(
                name: "log_id",
                table: "Mensagens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "con_id",
                table: "Mensagens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BoTResposta",
                columns: table => new
                {
                    bot_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bot_timeStamp = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    cat_wa_id = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BoTRespo__310884E0F06C7421", x => x.bot_id);
                });

            migrationBuilder.CreateTable(
                name: "cadastro",
                columns: table => new
                {
                    cad_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cat_timeStamp = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    cat_wa_id = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cadastro__39523F7CBD4EBC79", x => x.cad_id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK__Mensagens__con_i__693CA210",
                table: "Mensagens",
                column: "con_id",
                principalTable: "contatos",
                principalColumn: "con_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Mensagens__log_i__68487DD7",
                table: "Mensagens",
                column: "log_id",
                principalTable: "login",
                principalColumn: "log_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
