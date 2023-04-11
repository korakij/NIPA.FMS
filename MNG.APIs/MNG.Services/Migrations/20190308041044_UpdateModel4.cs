using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class UpdateModel4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestChemicalCompositions_Chargings_ChargingChargeNo",
                table: "TestChemicalCompositions");

            migrationBuilder.DropIndex(
                name: "IX_TestChemicalCompositions_ChargingChargeNo",
                table: "TestChemicalCompositions");

            migrationBuilder.DropColumn(
                name: "ChargingChargeNo",
                table: "TestChemicalCompositions");

            migrationBuilder.AlterColumn<string>(
                name: "ChargingCode",
                table: "TestChemicalCompositions",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestChemicalCompositions_ChargingCode",
                table: "TestChemicalCompositions",
                column: "ChargingCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TestChemicalCompositions_Chargings_ChargingCode",
                table: "TestChemicalCompositions",
                column: "ChargingCode",
                principalTable: "Chargings",
                principalColumn: "ChargeNo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestChemicalCompositions_Chargings_ChargingCode",
                table: "TestChemicalCompositions");

            migrationBuilder.DropIndex(
                name: "IX_TestChemicalCompositions_ChargingCode",
                table: "TestChemicalCompositions");

            migrationBuilder.AlterColumn<string>(
                name: "ChargingCode",
                table: "TestChemicalCompositions",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChargingChargeNo",
                table: "TestChemicalCompositions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestChemicalCompositions_ChargingChargeNo",
                table: "TestChemicalCompositions",
                column: "ChargingChargeNo");

            migrationBuilder.AddForeignKey(
                name: "FK_TestChemicalCompositions_Chargings_ChargingChargeNo",
                table: "TestChemicalCompositions",
                column: "ChargingChargeNo",
                principalTable: "Chargings",
                principalColumn: "ChargeNo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
