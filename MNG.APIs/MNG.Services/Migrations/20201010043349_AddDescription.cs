using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class AddDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ChemicalCompositionsInLadles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ChemicalCompositionsInFurnaces",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ChemicalCompositionsInLadles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ChemicalCompositionsInFurnaces");
        }
    }
}
