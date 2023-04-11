using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class UpdateModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chargings_Furnace_FurnaceCode",
                table: "Chargings");

            migrationBuilder.AddColumn<string>(
                name: "ChargingChargeNo",
                table: "TestChemicalCompositions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChargingCode",
                table: "TestChemicalCompositions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TestChemicalCompositionCode",
                table: "Kanbans",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FurnaceCode",
                table: "Chargings",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestChemicalCompositions_ChargingChargeNo",
                table: "TestChemicalCompositions",
                column: "ChargingChargeNo");

            migrationBuilder.CreateIndex(
                name: "IX_Kanbans_TestChemicalCompositionCode",
                table: "Kanbans",
                column: "TestChemicalCompositionCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Chargings_Furnace_FurnaceCode",
                table: "Chargings",
                column: "FurnaceCode",
                principalTable: "Furnace",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kanbans_TestChemicalCompositions_TestChemicalCompositionCode",
                table: "Kanbans",
                column: "TestChemicalCompositionCode",
                principalTable: "TestChemicalCompositions",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestChemicalCompositions_Chargings_ChargingChargeNo",
                table: "TestChemicalCompositions",
                column: "ChargingChargeNo",
                principalTable: "Chargings",
                principalColumn: "ChargeNo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chargings_Furnace_FurnaceCode",
                table: "Chargings");

            migrationBuilder.DropForeignKey(
                name: "FK_Kanbans_TestChemicalCompositions_TestChemicalCompositionCode",
                table: "Kanbans");

            migrationBuilder.DropForeignKey(
                name: "FK_TestChemicalCompositions_Chargings_ChargingChargeNo",
                table: "TestChemicalCompositions");

            migrationBuilder.DropIndex(
                name: "IX_TestChemicalCompositions_ChargingChargeNo",
                table: "TestChemicalCompositions");

            migrationBuilder.DropIndex(
                name: "IX_Kanbans_TestChemicalCompositionCode",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "ChargingChargeNo",
                table: "TestChemicalCompositions");

            migrationBuilder.DropColumn(
                name: "ChargingCode",
                table: "TestChemicalCompositions");

            migrationBuilder.DropColumn(
                name: "TestChemicalCompositionCode",
                table: "Kanbans");

            migrationBuilder.AlterColumn<string>(
                name: "FurnaceCode",
                table: "Chargings",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AddForeignKey(
                name: "FK_Chargings_Furnace_FurnaceCode",
                table: "Chargings",
                column: "FurnaceCode",
                principalTable: "Furnace",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
