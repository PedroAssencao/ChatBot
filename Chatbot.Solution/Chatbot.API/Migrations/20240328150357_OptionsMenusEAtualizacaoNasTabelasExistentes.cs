using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chatbot.API.Migrations
{
    public partial class OptionsMenusEAtualizacaoNasTabelasExistentes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "log_waid",
                table: "login",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "menus",
                columns: table => new
                {
                    men_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    men_header = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    men_footer = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    men_body = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    log_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__menus__387DDE00793E0D6B", x => x.men_id);
                    table.ForeignKey(
                        name: "FK__menus__log_id__7D439ABD",
                        column: x => x.log_id,
                        principalTable: "login",
                        principalColumn: "log_id");
                });

            migrationBuilder.CreateTable(
                name: "options",
                columns: table => new
                {
                    opt_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    men_id = table.Column<int>(type: "int", nullable: true),
                    mens_id = table.Column<int>(type: "int", nullable: true),
                    log_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__options__84DB9F9BE51F8316", x => x.opt_id);
                    table.ForeignKey(
                        name: "FK__options__log_id__09A971A2",
                        column: x => x.log_id,
                        principalTable: "login",
                        principalColumn: "log_id");
                    table.ForeignKey(
                        name: "FK__options__men_id__07C12930",
                        column: x => x.men_id,
                        principalTable: "menus",
                        principalColumn: "men_id");
                    table.ForeignKey(
                        name: "FK__options__mens_id__08B54D69",
                        column: x => x.mens_id,
                        principalTable: "Mensagens",
                        principalColumn: "men_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_menus_log_id",
                table: "menus",
                column: "log_id");

            migrationBuilder.CreateIndex(
                name: "IX_options_log_id",
                table: "options",
                column: "log_id");

            migrationBuilder.CreateIndex(
                name: "IX_options_men_id",
                table: "options",
                column: "men_id");

            migrationBuilder.CreateIndex(
                name: "IX_options_mens_id",
                table: "options",
                column: "mens_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "options");

            migrationBuilder.DropTable(
                name: "menus");

            migrationBuilder.DropColumn(
                name: "log_waid",
                table: "login");
        }
    }
}
