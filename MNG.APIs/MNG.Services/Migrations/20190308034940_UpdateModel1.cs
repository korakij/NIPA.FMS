using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class UpdateModel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.AddColumn<string>(
                name: "FurnaceCode",
                table: "Chargings",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Shift",
                table: "Chargings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Furnace",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false),
                    Power = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnace", x => x.Code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chargings_FurnaceCode",
                table: "Chargings",
                column: "FurnaceCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Chargings_Furnace_FurnaceCode",
                table: "Chargings",
                column: "FurnaceCode",
                principalTable: "Furnace",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chargings_Furnace_FurnaceCode",
                table: "Chargings");

            migrationBuilder.DropTable(
                name: "Furnace");

            migrationBuilder.DropIndex(
                name: "IX_Chargings_FurnaceCode",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "FurnaceCode",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "Shift",
                table: "Chargings");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    ChargingChargeNo = table.Column<string>(nullable: true),
                    ChargingCode = table.Column<string>(maxLength: 20, nullable: false),
                    KanbanCode = table.Column<string>(maxLength: 20, nullable: false),
                    TestChemicalCompositionCode = table.Column<string>(maxLength: 20, nullable: false)
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
    }
}
