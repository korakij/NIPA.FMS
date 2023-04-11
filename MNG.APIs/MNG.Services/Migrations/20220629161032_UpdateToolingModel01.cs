using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class UpdateToolingModel01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FirstTemp",
                table: "Toolings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastTemp",
                table: "Toolings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoOfMoldPerLadle",
                table: "Toolings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PouringTime",
                table: "Toolings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TappingWg",
                table: "PourStandards",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstTemp",
                table: "Toolings");

            migrationBuilder.DropColumn(
                name: "LastTemp",
                table: "Toolings");

            migrationBuilder.DropColumn(
                name: "NoOfMoldPerLadle",
                table: "Toolings");

            migrationBuilder.DropColumn(
                name: "PouringTime",
                table: "Toolings");

            migrationBuilder.DropColumn(
                name: "TappingWg",
                table: "PourStandards");
        }
    }
}
