using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class AddTestChemicalCompositionModel4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestChemicalCompositions",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    TestTime = table.Column<DateTime>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    ChemicalActual_TestDate = table.Column<DateTime>(nullable: false),
                    ChemicalActual_CCE = table.Column<float>(nullable: true),
                    ChemicalActual_C = table.Column<float>(nullable: true),
                    ChemicalActual_Si = table.Column<float>(nullable: true),
                    ChemicalActual_Mn = table.Column<float>(nullable: true),
                    ChemicalActual_Mg = table.Column<float>(nullable: true),
                    ChemicalActual_S = table.Column<float>(nullable: true),
                    ChemicalActual_Al = table.Column<float>(nullable: true),
                    ChemicalActual_Cu = table.Column<float>(nullable: true),
                    ChemicalActual_Sn = table.Column<float>(nullable: true),
                    ChemicalActual_Cr = table.Column<float>(nullable: true),
                    ChemicalActual_P = table.Column<float>(nullable: true),
                    ChemicalActual_Mo = table.Column<float>(nullable: true),
                    ChemicalActual_Ni = table.Column<float>(nullable: true),
                    ChemicalActual_V = table.Column<float>(nullable: true),
                    ChemicalActual_Ti = table.Column<float>(nullable: true),
                    ChemicalActual_Te = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestChemicalCompositions", x => x.Code);
                    table.ForeignKey(
                        name: "FK_TestChemicalCompositions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestChemicalCompositions_ProductId",
                table: "TestChemicalCompositions",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestChemicalCompositions");
        }
    }
}
