using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chatbot.API.Migrations
{
    public partial class optionsAtt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__atendente__dep_i__6FE99F9F",
                table: "atendentes");

            migrationBuilder.DropForeignKey(
                name: "FK__atendente__log_i__6EF57B66",
                table: "atendentes");

            migrationBuilder.DropForeignKey(
                name: "FK__Atendimen__ate_i__778AC167",
                table: "Atendimento");

            migrationBuilder.DropForeignKey(
                name: "FK__Atendimen__con_i__797309D9",
                table: "Atendimento");

            migrationBuilder.DropForeignKey(
                name: "FK__Atendimen__dep_i__787EE5A0",
                table: "Atendimento");

            migrationBuilder.DropForeignKey(
                name: "FK__Atendimen__log_i__7A672E12",
                table: "Atendimento");

            migrationBuilder.DropForeignKey(
                name: "FK__contatos__log_id__619B8048",
                table: "contatos");

            migrationBuilder.DropForeignKey(
                name: "FK__departame__log_i__6C190EBB",
                table: "departamento");

            migrationBuilder.DropForeignKey(
                name: "FK__Mensagens__con_i__693CA210",
                table: "Mensagens");

            migrationBuilder.DropForeignKey(
                name: "FK__Mensagens__log_i__68487DD7",
                table: "Mensagens");

            migrationBuilder.DropForeignKey(
                name: "FK__menus__log_id__7D439ABD",
                table: "menus");

            migrationBuilder.DropForeignKey(
                name: "FK__options__log_id__09A971A2",
                table: "options");

            migrationBuilder.DropForeignKey(
                name: "FK__options__men_id__07C12930",
                table: "options");

            migrationBuilder.DropForeignKey(
                name: "FK__options__mens_id__08B54D69",
                table: "options");

            migrationBuilder.DropPrimaryKey(
                name: "PK__options__84DB9F9BE51F8316",
                table: "options");

            migrationBuilder.DropIndex(
                name: "IX_options_mens_id",
                table: "options");

            migrationBuilder.DropPrimaryKey(
                name: "PK__menus__387DDE00793E0D6B",
                table: "menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Mensagen__387DDE002B87EB71",
                table: "Mensagens");

            migrationBuilder.DropPrimaryKey(
                name: "PK__login__9E2397E0C0BA34C1",
                table: "login");

            migrationBuilder.DropPrimaryKey(
                name: "PK__departam__BB4BD8F85734EF12",
                table: "departamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK__contatos__081B0F1AE238EAA5",
                table: "contatos");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Atendime__F4B66A4076DC8CE9",
                table: "Atendimento");

            migrationBuilder.DropPrimaryKey(
                name: "PK__atendent__895194D62A291414",
                table: "atendentes");

            migrationBuilder.DropColumn(
                name: "mens_id",
                table: "options");

            migrationBuilder.DropColumn(
                name: "men_Finalizar",
                table: "Mensagens");

            migrationBuilder.DropColumn(
                name: "men_descricao",
                table: "Mensagens");

            migrationBuilder.DropColumn(
                name: "men_resposta",
                table: "Mensagens");

            migrationBuilder.DropColumn(
                name: "men_title",
                table: "Mensagens");

            migrationBuilder.RenameColumn(
                name: "men_Data",
                table: "Mensagens",
                newName: "mens_data");

            migrationBuilder.RenameColumn(
                name: "men_id",
                table: "Mensagens",
                newName: "mens_id");

            migrationBuilder.AddColumn<DateTime>(
                name: "opt_data",
                table: "options",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "opt_descricao",
                table: "options",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "opt_finalizar",
                table: "options",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "opt_resposta",
                table: "options",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "opt_tipo",
                table: "options",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "opt_title",
                table: "options",
                type: "varchar(24)",
                unicode: false,
                maxLength: 24,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "men_title",
                table: "menus",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "mens_descricao",
                table: "Mensagens",
                type: "varchar(max)",
                unicode: false,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__options__84DB9F9BC598D2A7",
                table: "options",
                column: "opt_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__menus__387DDE00860AE6CD",
                table: "menus",
                column: "men_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Mensagen__763E9E0A0EC79D0B",
                table: "Mensagens",
                column: "mens_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__login__9E2397E0969F58EA",
                table: "login",
                column: "log_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__departam__BB4BD8F8671B8661",
                table: "departamento",
                column: "dep_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__contatos__081B0F1A19F19A4D",
                table: "contatos",
                column: "con_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Atendime__F4B66A40AF98F0D3",
                table: "Atendimento",
                column: "aten_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__atendent__895194D66F1FCCAC",
                table: "atendentes",
                column: "ate_id");

            migrationBuilder.AddForeignKey(
                name: "FK__atendente__dep_i__5629CD9C",
                table: "atendentes",
                column: "dep_id",
                principalTable: "departamento",
                principalColumn: "dep_id");

            migrationBuilder.AddForeignKey(
                name: "FK__atendente__log_i__5535A963",
                table: "atendentes",
                column: "log_id",
                principalTable: "login",
                principalColumn: "log_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Atendimen__ate_i__59063A47",
                table: "Atendimento",
                column: "ate_id",
                principalTable: "atendentes",
                principalColumn: "ate_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Atendimen__con_i__5AEE82B9",
                table: "Atendimento",
                column: "con_id",
                principalTable: "contatos",
                principalColumn: "con_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Atendimen__dep_i__59FA5E80",
                table: "Atendimento",
                column: "dep_id",
                principalTable: "departamento",
                principalColumn: "dep_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Atendimen__log_i__5BE2A6F2",
                table: "Atendimento",
                column: "log_id",
                principalTable: "login",
                principalColumn: "log_id");

            migrationBuilder.AddForeignKey(
                name: "FK__contatos__log_id__4BAC3F29",
                table: "contatos",
                column: "log_id",
                principalTable: "login",
                principalColumn: "log_id");

            migrationBuilder.AddForeignKey(
                name: "FK__departame__log_i__52593CB8",
                table: "departamento",
                column: "log_id",
                principalTable: "login",
                principalColumn: "log_id");

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

            migrationBuilder.AddForeignKey(
                name: "FK__menus__log_id__5EBF139D",
                table: "menus",
                column: "log_id",
                principalTable: "login",
                principalColumn: "log_id");

            migrationBuilder.AddForeignKey(
                name: "FK__options__log_id__619B8048",
                table: "options",
                column: "log_id",
                principalTable: "login",
                principalColumn: "log_id");

            migrationBuilder.AddForeignKey(
                name: "FK__options__men_id__628FA481",
                table: "options",
                column: "men_id",
                principalTable: "menus",
                principalColumn: "men_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__atendente__dep_i__5629CD9C",
                table: "atendentes");

            migrationBuilder.DropForeignKey(
                name: "FK__atendente__log_i__5535A963",
                table: "atendentes");

            migrationBuilder.DropForeignKey(
                name: "FK__Atendimen__ate_i__59063A47",
                table: "Atendimento");

            migrationBuilder.DropForeignKey(
                name: "FK__Atendimen__con_i__5AEE82B9",
                table: "Atendimento");

            migrationBuilder.DropForeignKey(
                name: "FK__Atendimen__dep_i__59FA5E80",
                table: "Atendimento");

            migrationBuilder.DropForeignKey(
                name: "FK__Atendimen__log_i__5BE2A6F2",
                table: "Atendimento");

            migrationBuilder.DropForeignKey(
                name: "FK__contatos__log_id__4BAC3F29",
                table: "contatos");

            migrationBuilder.DropForeignKey(
                name: "FK__departame__log_i__52593CB8",
                table: "departamento");

            migrationBuilder.DropForeignKey(
                name: "FK__Mensagens__con_i__4E88ABD4",
                table: "Mensagens");

            migrationBuilder.DropForeignKey(
                name: "FK__Mensagens__log_i__4F7CD00D",
                table: "Mensagens");

            migrationBuilder.DropForeignKey(
                name: "FK__menus__log_id__5EBF139D",
                table: "menus");

            migrationBuilder.DropForeignKey(
                name: "FK__options__log_id__619B8048",
                table: "options");

            migrationBuilder.DropForeignKey(
                name: "FK__options__men_id__628FA481",
                table: "options");

            migrationBuilder.DropPrimaryKey(
                name: "PK__options__84DB9F9BC598D2A7",
                table: "options");

            migrationBuilder.DropPrimaryKey(
                name: "PK__menus__387DDE00860AE6CD",
                table: "menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Mensagen__763E9E0A0EC79D0B",
                table: "Mensagens");

            migrationBuilder.DropPrimaryKey(
                name: "PK__login__9E2397E0969F58EA",
                table: "login");

            migrationBuilder.DropPrimaryKey(
                name: "PK__departam__BB4BD8F8671B8661",
                table: "departamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK__contatos__081B0F1A19F19A4D",
                table: "contatos");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Atendime__F4B66A40AF98F0D3",
                table: "Atendimento");

            migrationBuilder.DropPrimaryKey(
                name: "PK__atendent__895194D66F1FCCAC",
                table: "atendentes");

            migrationBuilder.DropColumn(
                name: "opt_data",
                table: "options");

            migrationBuilder.DropColumn(
                name: "opt_descricao",
                table: "options");

            migrationBuilder.DropColumn(
                name: "opt_finalizar",
                table: "options");

            migrationBuilder.DropColumn(
                name: "opt_resposta",
                table: "options");

            migrationBuilder.DropColumn(
                name: "opt_tipo",
                table: "options");

            migrationBuilder.DropColumn(
                name: "opt_title",
                table: "options");

            migrationBuilder.DropColumn(
                name: "men_title",
                table: "menus");

            migrationBuilder.DropColumn(
                name: "mens_descricao",
                table: "Mensagens");

            migrationBuilder.RenameColumn(
                name: "mens_data",
                table: "Mensagens",
                newName: "men_Data");

            migrationBuilder.RenameColumn(
                name: "mens_id",
                table: "Mensagens",
                newName: "men_id");

            migrationBuilder.AddColumn<int>(
                name: "mens_id",
                table: "options",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "men_Finalizar",
                table: "Mensagens",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "men_descricao",
                table: "Mensagens",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "men_resposta",
                table: "Mensagens",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "men_title",
                table: "Mensagens",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__options__84DB9F9BE51F8316",
                table: "options",
                column: "opt_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__menus__387DDE00793E0D6B",
                table: "menus",
                column: "men_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Mensagen__387DDE002B87EB71",
                table: "Mensagens",
                column: "men_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__login__9E2397E0C0BA34C1",
                table: "login",
                column: "log_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__departam__BB4BD8F85734EF12",
                table: "departamento",
                column: "dep_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__contatos__081B0F1AE238EAA5",
                table: "contatos",
                column: "con_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Atendime__F4B66A4076DC8CE9",
                table: "Atendimento",
                column: "aten_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__atendent__895194D62A291414",
                table: "atendentes",
                column: "ate_id");

            migrationBuilder.CreateIndex(
                name: "IX_options_mens_id",
                table: "options",
                column: "mens_id");

            migrationBuilder.AddForeignKey(
                name: "FK__atendente__dep_i__6FE99F9F",
                table: "atendentes",
                column: "dep_id",
                principalTable: "departamento",
                principalColumn: "dep_id");

            migrationBuilder.AddForeignKey(
                name: "FK__atendente__log_i__6EF57B66",
                table: "atendentes",
                column: "log_id",
                principalTable: "login",
                principalColumn: "log_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Atendimen__ate_i__778AC167",
                table: "Atendimento",
                column: "ate_id",
                principalTable: "atendentes",
                principalColumn: "ate_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Atendimen__con_i__797309D9",
                table: "Atendimento",
                column: "con_id",
                principalTable: "contatos",
                principalColumn: "con_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Atendimen__dep_i__787EE5A0",
                table: "Atendimento",
                column: "dep_id",
                principalTable: "departamento",
                principalColumn: "dep_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Atendimen__log_i__7A672E12",
                table: "Atendimento",
                column: "log_id",
                principalTable: "login",
                principalColumn: "log_id");

            migrationBuilder.AddForeignKey(
                name: "FK__contatos__log_id__619B8048",
                table: "contatos",
                column: "log_id",
                principalTable: "login",
                principalColumn: "log_id");

            migrationBuilder.AddForeignKey(
                name: "FK__departame__log_i__6C190EBB",
                table: "departamento",
                column: "log_id",
                principalTable: "login",
                principalColumn: "log_id");

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

            migrationBuilder.AddForeignKey(
                name: "FK__menus__log_id__7D439ABD",
                table: "menus",
                column: "log_id",
                principalTable: "login",
                principalColumn: "log_id");

            migrationBuilder.AddForeignKey(
                name: "FK__options__log_id__09A971A2",
                table: "options",
                column: "log_id",
                principalTable: "login",
                principalColumn: "log_id");

            migrationBuilder.AddForeignKey(
                name: "FK__options__men_id__07C12930",
                table: "options",
                column: "men_id",
                principalTable: "menus",
                principalColumn: "men_id");

            migrationBuilder.AddForeignKey(
                name: "FK__options__mens_id__08B54D69",
                table: "options",
                column: "mens_id",
                principalTable: "Mensagens",
                principalColumn: "men_id");
        }
    }
}
