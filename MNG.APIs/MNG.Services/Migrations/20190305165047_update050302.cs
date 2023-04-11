using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class update050302 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kanbans_Chargings_ChargingChargeNo",
                table: "Kanbans");

            migrationBuilder.DropForeignKey(
                name: "FK_Kanbans_TestChemicalCompositions_TestChemicalCompositionCode",
                table: "Kanbans");

            migrationBuilder.DropIndex(
                name: "IX_Kanbans_ChargingChargeNo",
                table: "Kanbans");

            migrationBuilder.DropIndex(
                name: "IX_Kanbans_TestChemicalCompositionCode",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "ChargingChargeNo",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "ChargingCode",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "TestChemicalCompositionCode",
                table: "Kanbans");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChargingChargeNo",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChargingCode",
                table: "Kanbans",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TestChemicalCompositionCode",
                table: "Kanbans",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Kanbans_ChargingChargeNo",
                table: "Kanbans",
                column: "ChargingChargeNo");

            migrationBuilder.CreateIndex(
                name: "IX_Kanbans_TestChemicalCompositionCode",
                table: "Kanbans",
                column: "TestChemicalCompositionCode",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kanbans_Chargings_ChargingChargeNo",
                table: "Kanbans",
                column: "ChargingChargeNo",
                principalTable: "Chargings",
                principalColumn: "ChargeNo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Kanbans_TestChemicalCompositions_TestChemicalCompositionCode",
                table: "Kanbans",
                column: "TestChemicalCompositionCode",
                principalTable: "TestChemicalCompositions",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
