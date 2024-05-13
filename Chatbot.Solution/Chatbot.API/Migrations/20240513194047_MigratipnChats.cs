using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chatbot.API.Migrations
{
    public partial class MigratipnChats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chat",
                columns: table => new
                {
                    cha_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ate_id = table.Column<int>(type: "int", nullable: true),
                    con_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__chat__5AF8FDEA08FBB41E", x => x.cha_id);
                    table.ForeignKey(
                        name: "FK__chat__ate_id__02FC7413",
                        column: x => x.ate_id,
                        principalTable: "atendentes",
                        principalColumn: "ate_id");
                    table.ForeignKey(
                        name: "FK__chat__con_id__03F0984C",
                        column: x => x.con_id,
                        principalTable: "contatos",
                        principalColumn: "con_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_chat_ate_id",
                table: "chat",
                column: "ate_id");

            migrationBuilder.CreateIndex(
                name: "IX_chat_con_id",
                table: "chat",
                column: "con_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chat");
        }
    }
}
