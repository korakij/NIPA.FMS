using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class Update20021001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ChillMax",
                table: "PourStandards",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Magnesium",
                table: "PourStandards",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Copper",
                table: "Kanbans",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Inoculant",
                table: "Kanbans",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Magnesium",
                table: "Kanbans",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Tin",
                table: "Kanbans",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "WireInoculant",
                table: "Kanbans",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "WireMagnesium",
                table: "Kanbans",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChillMax",
                table: "PourStandards");

            migrationBuilder.DropColumn(
                name: "Magnesium",
                table: "PourStandards");

            migrationBuilder.DropColumn(
                name: "Copper",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Inoculant",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Magnesium",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Tin",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "WireInoculant",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "WireMagnesium",
                table: "Kanbans");
        }
    }
}
