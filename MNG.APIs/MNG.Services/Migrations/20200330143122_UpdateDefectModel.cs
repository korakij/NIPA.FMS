using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class UpdateDefectModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Defect_EngDefect_Total",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_FinDefect_Total",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_MoldDefect_Total",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_PourDefect_Total",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Defect_EngDefect_Total",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_FinDefect_Total",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_MoldDefect_Total",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_PourDefect_Total",
                table: "Pourings");
        }
    }
}
