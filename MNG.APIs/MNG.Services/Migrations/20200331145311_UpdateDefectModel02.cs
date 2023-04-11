using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class UpdateDefectModel02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Defect_DefectRate",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Defect_DefectWeightRate",
                table: "Pourings",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_TotalDefect",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Defect_TotalDefectWeight",
                table: "Pourings",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_TotalNumber",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Defect_TotalWeight",
                table: "Pourings",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Defect_DefectRate",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_DefectWeightRate",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_TotalDefect",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_TotalDefectWeight",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_TotalNumber",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_TotalWeight",
                table: "Pourings");
        }
    }
}
