using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class AddDefect1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Defect_EngDefect_AirPocket",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_EngDefect_MissedIdentifer",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_EngDefect_WornTooling",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Defect_EngDefect_AirPocket",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_EngDefect_MissedIdentifer",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_EngDefect_WornTooling",
                table: "Pourings");
        }
    }
}
