using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chatbot.API.Migrations
{
    public partial class atualizacaoChatEMensagens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__chat__ate_id__02FC7413",
                table: "chat");

            migrationBuilder.DropForeignKey(
                name: "FK__chat__con_id__03F0984C",
                table: "chat");

            migrationBuilder.DropForeignKey(
                name: "FK__Mensagens__con_i__4E88ABD4",
                table: "Mensagens");

            migrationBuilder.DropForeignKey(
                name: "FK__Mensagens__log_i__4F7CD00D",
                table: "Mensagens");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Mensagen__763E9E0A0EC79D0B",
                table: "Mensagens");

            migrationBuilder.DropPrimaryKey(
                name: "PK__chat__5AF8FDEA08FBB41E",
                table: "chat");

            migrationBuilder.AddColumn<int>(
                name: "cha_id",
                table: "Mensagens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "log_id",
                table: "chat",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Mensagen__763E9E0AF88E2D22",
                table: "Mensagens",
                column: "mens_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__chat__5AF8FDEA98C97753",
                table: "chat",
                column: "cha_id");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagens_cha_id",
                table: "Mensagens",
                column: "cha_id");

            migrationBuilder.CreateIndex(
                name: "IX_chat_log_id",
                table: "chat",
                column: "log_id");

            migrationBuilder.AddForeignKey(
                name: "FK__chat__ate_id__5DCAEF64",
                table: "chat",
                column: "ate_id",
                principalTable: "atendentes",
                principalColumn: "ate_id");

            migrationBuilder.AddForeignKey(
                name: "FK__chat__con_id__5FB337D6",
                table: "chat",
                column: "con_id",
                principalTable: "contatos",
                principalColumn: "con_id");

            migrationBuilder.AddForeignKey(
                name: "FK__chat__log_id__5EBF139D",
                table: "chat",
                column: "log_id",
                principalTable: "login",
                principalColumn: "log_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Mensagens__cha_i__6477ECF3",
                table: "Mensagens",
                column: "cha_id",
                principalTable: "chat",
                principalColumn: "cha_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Mensagens__con_i__628FA481",
                table: "Mensagens",
                column: "con_id",
                principalTable: "contatos",
                principalColumn: "con_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Mensagens__log_i__6383C8BA",
                table: "Mensagens",
                column: "log_id",
                principalTable: "login",
                principalColumn: "log_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__chat__ate_id__5DCAEF64",
                table: "chat");

            migrationBuilder.DropForeignKey(
                name: "FK__chat__con_id__5FB337D6",
                table: "chat");

            migrationBuilder.DropForeignKey(
                name: "FK__chat__log_id__5EBF139D",
                table: "chat");

            migrationBuilder.DropForeignKey(
                name: "FK__Mensagens__cha_i__6477ECF3",
                table: "Mensagens");

            migrationBuilder.DropForeignKey(
                name: "FK__Mensagens__con_i__628FA481",
                table: "Mensagens");

            migrationBuilder.DropForeignKey(
                name: "FK__Mensagens__log_i__6383C8BA",
                table: "Mensagens");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Mensagen__763E9E0AF88E2D22",
                table: "Mensagens");

            migrationBuilder.DropIndex(
                name: "IX_Mensagens_cha_id",
                table: "Mensagens");

            migrationBuilder.DropPrimaryKey(
                name: "PK__chat__5AF8FDEA98C97753",
                table: "chat");

            migrationBuilder.DropIndex(
                name: "IX_chat_log_id",
                table: "chat");

            migrationBuilder.DropColumn(
                name: "cha_id",
                table: "Mensagens");

            migrationBuilder.DropColumn(
                name: "log_id",
                table: "chat");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Mensagen__763E9E0A0EC79D0B",
                table: "Mensagens",
                column: "mens_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__chat__5AF8FDEA08FBB41E",
                table: "chat",
                column: "cha_id");

            migrationBuilder.AddForeignKey(
                name: "FK__chat__ate_id__02FC7413",
                table: "chat",
                column: "ate_id",
                principalTable: "atendentes",
                principalColumn: "ate_id");

            migrationBuilder.AddForeignKey(
                name: "FK__chat__con_id__03F0984C",
                table: "chat",
                column: "con_id",
                principalTable: "contatos",
                principalColumn: "con_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Mensagens__con_i__4E88ABD4",
                table: "Mensagens",
                column: "con_id",
                principalTable: "contatos",
                principalColumn: "con_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Mensagens__log_i__4F7CD00D",
                table: "Mensagens",
                column: "log_id",
                principalTable: "login",
                principalColumn: "log_id");
        }
    }
}
