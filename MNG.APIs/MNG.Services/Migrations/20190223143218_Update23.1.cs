using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class Update231 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TestTime",
                table: "TestChemicalCompositions",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "StopTime",
                table: "Chargings",
                newName: "MaxTempTime");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Chargings",
                newName: "ChargeTime");

            migrationBuilder.RenameColumn(
                name: "KwHr",
                table: "Chargings",
                newName: "StartKwHr");

            migrationBuilder.AddColumn<float>(
                name: "KwHr",
                table: "Kanbans",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "MaxTemp",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "MaxTempKwHr",
                table: "Chargings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KwHr",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "MaxTemp",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "MaxTempKwHr",
                table: "Chargings");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "TestChemicalCompositions",
                newName: "TestTime");

            migrationBuilder.RenameColumn(
                name: "StartKwHr",
                table: "Chargings",
                newName: "KwHr");

            migrationBuilder.RenameColumn(
                name: "MaxTempTime",
                table: "Chargings",
                newName: "StopTime");

            migrationBuilder.RenameColumn(
                name: "ChargeTime",
                table: "Chargings",
                newName: "StartTime");
        }
    }
}
