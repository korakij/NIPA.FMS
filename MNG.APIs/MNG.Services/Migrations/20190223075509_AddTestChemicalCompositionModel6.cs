using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class AddTestChemicalCompositionModel6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChemicalActual_V",
                table: "TestChemicalCompositions",
                newName: "Result_V");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_Ti",
                table: "TestChemicalCompositions",
                newName: "Result_Ti");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_Te",
                table: "TestChemicalCompositions",
                newName: "Result_Te");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_Sn",
                table: "TestChemicalCompositions",
                newName: "Result_Sn");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_Si",
                table: "TestChemicalCompositions",
                newName: "Result_Si");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_S",
                table: "TestChemicalCompositions",
                newName: "Result_S");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_P",
                table: "TestChemicalCompositions",
                newName: "Result_P");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_Ni",
                table: "TestChemicalCompositions",
                newName: "Result_Ni");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_Mo",
                table: "TestChemicalCompositions",
                newName: "Result_Mo");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_Mn",
                table: "TestChemicalCompositions",
                newName: "Result_Mn");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_Mg",
                table: "TestChemicalCompositions",
                newName: "Result_Mg");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_Cu",
                table: "TestChemicalCompositions",
                newName: "Result_Cu");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_Cr",
                table: "TestChemicalCompositions",
                newName: "Result_Cr");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_CCE",
                table: "TestChemicalCompositions",
                newName: "Result_CCE");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_C",
                table: "TestChemicalCompositions",
                newName: "Result_C");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_Al",
                table: "TestChemicalCompositions",
                newName: "Result_Al");

            migrationBuilder.CreateTable(
                name: "Kanban",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    TestChemicalCompositionCode = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kanban", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Kanban_TestChemicalCompositions_TestChemicalCompositionCode",
                        column: x => x.TestChemicalCompositionCode,
                        principalTable: "TestChemicalCompositions",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kanban_TestChemicalCompositionCode",
                table: "Kanban",
                column: "TestChemicalCompositionCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kanban");

            migrationBuilder.RenameColumn(
                name: "Result_V",
                table: "TestChemicalCompositions",
                newName: "ChemicalActual_V");

            migrationBuilder.RenameColumn(
                name: "Result_Ti",
                table: "TestChemicalCompositions",
                newName: "ChemicalActual_Ti");

            migrationBuilder.RenameColumn(
                name: "Result_Te",
                table: "TestChemicalCompositions",
                newName: "ChemicalActual_Te");

            migrationBuilder.RenameColumn(
                name: "Result_Sn",
                table: "TestChemicalCompositions",
                newName: "ChemicalActual_Sn");

            migrationBuilder.RenameColumn(
                name: "Result_Si",
                table: "TestChemicalCompositions",
                newName: "ChemicalActual_Si");

            migrationBuilder.RenameColumn(
                name: "Result_S",
                table: "TestChemicalCompositions",
                newName: "ChemicalActual_S");

            migrationBuilder.RenameColumn(
                name: "Result_P",
                table: "TestChemicalCompositions",
                newName: "ChemicalActual_P");

            migrationBuilder.RenameColumn(
                name: "Result_Ni",
                table: "TestChemicalCompositions",
                newName: "ChemicalActual_Ni");

            migrationBuilder.RenameColumn(
                name: "Result_Mo",
                table: "TestChemicalCompositions",
                newName: "ChemicalActual_Mo");

            migrationBuilder.RenameColumn(
                name: "Result_Mn",
                table: "TestChemicalCompositions",
                newName: "ChemicalActual_Mn");

            migrationBuilder.RenameColumn(
                name: "Result_Mg",
                table: "TestChemicalCompositions",
                newName: "ChemicalActual_Mg");

            migrationBuilder.RenameColumn(
                name: "Result_Cu",
                table: "TestChemicalCompositions",
                newName: "ChemicalActual_Cu");

            migrationBuilder.RenameColumn(
                name: "Result_Cr",
                table: "TestChemicalCompositions",
                newName: "ChemicalActual_Cr");

            migrationBuilder.RenameColumn(
                name: "Result_CCE",
                table: "TestChemicalCompositions",
                newName: "ChemicalActual_CCE");

            migrationBuilder.RenameColumn(
                name: "Result_C",
                table: "TestChemicalCompositions",
                newName: "ChemicalActual_C");

            migrationBuilder.RenameColumn(
                name: "Result_Al",
                table: "TestChemicalCompositions",
                newName: "ChemicalActual_Al");
        }
    }
}
