using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplicatie_Web.Migrations
{
    public partial class Studio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudioID",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Studio",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Studioname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studio", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_StudioID",
                table: "Game",
                column: "StudioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Studio_StudioID",
                table: "Game",
                column: "StudioID",
                principalTable: "Studio",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Studio_StudioID",
                table: "Game");

            migrationBuilder.DropTable(
                name: "Studio");

            migrationBuilder.DropIndex(
                name: "IX_Game_StudioID",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "StudioID",
                table: "Game");
        }
    }
}
