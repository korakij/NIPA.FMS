using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class AddTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    ChargingChargeNo = table.Column<string>(nullable: true),
                    ChargingCode = table.Column<string>(maxLength: 20, nullable: false),
                    TestChemicalCompositionCode = table.Column<string>(maxLength: 20, nullable: false),
                    KanbanCode = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Transactions_Chargings_ChargingChargeNo",
                        column: x => x.ChargingChargeNo,
                        principalTable: "Chargings",
                        principalColumn: "ChargeNo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Kanbans_KanbanCode",
                        column: x => x.KanbanCode,
                        principalTable: "Kanbans",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_TestChemicalCompositions_TestChemicalCompositionCode",
                        column: x => x.TestChemicalCompositionCode,
                        principalTable: "TestChemicalCompositions",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ChargingChargeNo",
                table: "Transactions",
                column: "ChargingChargeNo");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_KanbanCode",
                table: "Transactions",
                column: "KanbanCode");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TestChemicalCompositionCode",
                table: "Transactions",
                column: "TestChemicalCompositionCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
