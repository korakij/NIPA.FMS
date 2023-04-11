using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class update050301 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Kanbans_TestChemicalCompositionCode",
                table: "Kanbans");

            migrationBuilder.CreateIndex(
                name: "IX_Kanbans_TestChemicalCompositionCode",
                table: "Kanbans",
                column: "TestChemicalCompositionCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Kanbans_TestChemicalCompositionCode",
                table: "Kanbans");

            migrationBuilder.CreateIndex(
                name: "IX_Kanbans_TestChemicalCompositionCode",
                table: "Kanbans",
                column: "TestChemicalCompositionCode");
        }
    }
}
