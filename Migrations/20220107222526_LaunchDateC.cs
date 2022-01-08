using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplicatie_Web.Migrations
{
    public partial class LaunchDateC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublishingDate",
                table: "Game",
                newName: "LaunchDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LaunchDate",
                table: "Game",
                newName: "PublishingDate");
        }
    }
}
