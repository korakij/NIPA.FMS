using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class UpdatePourStd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "CuTol",
                table: "PourStandards",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "InoculantTol",
                table: "PourStandards",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MagnesiumTol",
                table: "PourStandards",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "SnTol",
                table: "PourStandards",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "WiredInocTol",
                table: "PourStandards",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "WiredMgTol",
                table: "PourStandards",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CuTol",
                table: "PourStandards");

            migrationBuilder.DropColumn(
                name: "InoculantTol",
                table: "PourStandards");

            migrationBuilder.DropColumn(
                name: "MagnesiumTol",
                table: "PourStandards");

            migrationBuilder.DropColumn(
                name: "SnTol",
                table: "PourStandards");

            migrationBuilder.DropColumn(
                name: "WiredInocTol",
                table: "PourStandards");

            migrationBuilder.DropColumn(
                name: "WiredMgTol",
                table: "PourStandards");
        }
    }
}
