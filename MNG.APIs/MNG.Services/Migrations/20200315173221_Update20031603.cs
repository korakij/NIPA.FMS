using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class Update20031603 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Defect_FinDefect_Dent",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_FinDefect_OverGrinding",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_MeltDefect_BlowHole",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_MeltDefect_ChemNG",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_MeltDefect_Chill",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_MeltDefect_HardnessNG",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_MeltDefect_MicroNG",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_MeltDefect_PinHole",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_MeltDefect_Shrinkage",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_MoldDefect_BlowHole",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_MoldDefect_Burr",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_MoldDefect_MissMatch",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_MoldDefect_PinHole",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_MoldDefect_SandBroken",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_MoldDefect_SandDrop",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_PourDefect_BlowHole",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_PourDefect_Chill",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_PourDefect_ColdShut",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_PourDefect_HardnessNG",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_PourDefect_MicroNG",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_PourDefect_PinHole",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_PourDefect_Shrinkage",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defect_PourDefect_Slag",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductNo",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Defect_FinDefect_Dent",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_FinDefect_OverGrinding",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_MeltDefect_BlowHole",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_MeltDefect_ChemNG",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_MeltDefect_Chill",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_MeltDefect_HardnessNG",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_MeltDefect_MicroNG",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_MeltDefect_PinHole",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_MeltDefect_Shrinkage",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_MoldDefect_BlowHole",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_MoldDefect_Burr",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_MoldDefect_MissMatch",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_MoldDefect_PinHole",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_MoldDefect_SandBroken",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_MoldDefect_SandDrop",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_PourDefect_BlowHole",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_PourDefect_Chill",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_PourDefect_ColdShut",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_PourDefect_HardnessNG",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_PourDefect_MicroNG",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_PourDefect_PinHole",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_PourDefect_Shrinkage",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Defect_PourDefect_Slag",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "ProductNo",
                table: "Pourings");
        }
    }
}
