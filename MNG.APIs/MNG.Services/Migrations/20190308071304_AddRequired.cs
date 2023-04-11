using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class AddRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kanbans_TestChemicalCompositions_TestChemicalCompositionCode",
                table: "Kanbans");

            migrationBuilder.DropForeignKey(
                name: "FK_TestChemicalCompositions_Chargings_ChargingCode",
                table: "TestChemicalCompositions");

            migrationBuilder.AlterColumn<string>(
                name: "ChargingCode",
                table: "TestChemicalCompositions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TestChemicalCompositionCode",
                table: "Kanbans",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kanbans_TestChemicalCompositions_TestChemicalCompositionCode",
                table: "Kanbans",
                column: "TestChemicalCompositionCode",
                principalTable: "TestChemicalCompositions",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestChemicalCompositions_Chargings_ChargingCode",
                table: "TestChemicalCompositions",
                column: "ChargingCode",
                principalTable: "Chargings",
                principalColumn: "ChargeNo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kanbans_TestChemicalCompositions_TestChemicalCompositionCode",
                table: "Kanbans");

            migrationBuilder.DropForeignKey(
                name: "FK_TestChemicalCompositions_Chargings_ChargingCode",
                table: "TestChemicalCompositions");

            migrationBuilder.AlterColumn<string>(
                name: "ChargingCode",
                table: "TestChemicalCompositions",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "TestChemicalCompositionCode",
                table: "Kanbans",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AddForeignKey(
                name: "FK_Kanbans_TestChemicalCompositions_TestChemicalCompositionCode",
                table: "Kanbans",
                column: "TestChemicalCompositionCode",
                principalTable: "TestChemicalCompositions",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestChemicalCompositions_Chargings_ChargingCode",
                table: "TestChemicalCompositions",
                column: "ChargingCode",
                principalTable: "Chargings",
                principalColumn: "ChargeNo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
