using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class AddTestChemicalCompositionModel7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kanban_TestChemicalCompositions_TestChemicalCompositionCode",
                table: "Kanban");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kanban",
                table: "Kanban");

            migrationBuilder.RenameTable(
                name: "Kanban",
                newName: "Kanbans");

            migrationBuilder.RenameIndex(
                name: "IX_Kanban_TestChemicalCompositionCode",
                table: "Kanbans",
                newName: "IX_Kanbans_TestChemicalCompositionCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kanbans",
                table: "Kanbans",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Kanbans_TestChemicalCompositions_TestChemicalCompositionCode",
                table: "Kanbans",
                column: "TestChemicalCompositionCode",
                principalTable: "TestChemicalCompositions",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kanbans_TestChemicalCompositions_TestChemicalCompositionCode",
                table: "Kanbans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kanbans",
                table: "Kanbans");

            migrationBuilder.RenameTable(
                name: "Kanbans",
                newName: "Kanban");

            migrationBuilder.RenameIndex(
                name: "IX_Kanbans_TestChemicalCompositionCode",
                table: "Kanban",
                newName: "IX_Kanban_TestChemicalCompositionCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kanban",
                table: "Kanban",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Kanban_TestChemicalCompositions_TestChemicalCompositionCode",
                table: "Kanban",
                column: "TestChemicalCompositionCode",
                principalTable: "TestChemicalCompositions",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
