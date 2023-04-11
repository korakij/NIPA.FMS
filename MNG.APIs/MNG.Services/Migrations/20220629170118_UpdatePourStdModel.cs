using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class UpdatePourStdModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstTemp",
                table: "PourStandards");

            migrationBuilder.DropColumn(
                name: "LastTemp",
                table: "PourStandards");

            migrationBuilder.DropColumn(
                name: "NoOfMoldPerLadle",
                table: "PourStandards");

            migrationBuilder.DropColumn(
                name: "PouringTime",
                table: "PourStandards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "FirstTemp",
                table: "PourStandards",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "LastTemp",
                table: "PourStandards",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "NoOfMoldPerLadle",
                table: "PourStandards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "PouringTime",
                table: "PourStandards",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
