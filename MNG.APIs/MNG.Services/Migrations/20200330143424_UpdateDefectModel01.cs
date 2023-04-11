using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class UpdateDefectModel01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Defect_CoreDefect_CoreBroken",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_CoreDefect_CoreDeform",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_CoreDefect_Total",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_CoreDefect_WetCore",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Defect_CoreDefect_CoreBroken",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_CoreDefect_CoreDeform",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_CoreDefect_Total",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_CoreDefect_WetCore",
                table: "Pourings");
        }
    }
}
