using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class AddDefect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Defect_FinDefect_Deform",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_MoldDefect_ChillMismatch",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_MoldDefect_CoreMismatch",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Defect_FinDefect_Deform",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_MoldDefect_ChillMismatch",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_MoldDefect_CoreMismatch",
                table: "Pourings");
        }
    }
}
