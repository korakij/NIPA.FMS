using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class Update20031602 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeltDefect_BlowHole",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "MeltDefect_ChemNG",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "MeltDefect_Chill",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "MeltDefect_HardnessNG",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "MeltDefect_MicroNG",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "MeltDefect_PinHole",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "MeltDefect_Shrinkage",
                table: "Pourings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeltDefect_BlowHole",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MeltDefect_ChemNG",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MeltDefect_Chill",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MeltDefect_HardnessNG",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MeltDefect_MicroNG",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MeltDefect_PinHole",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MeltDefect_Shrinkage",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);
        }
    }
}
