using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class AddGoodNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Defect_TotalGood",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Defect_TotalGoodWeight",
                table: "Pourings",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Defect_TotalGood",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_TotalGoodWeight",
                table: "Pourings");
        }
    }
}
