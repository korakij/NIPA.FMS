using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class AddTestChemicalCompositionModel8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Kanbans_ChargingChargeNo",
                table: "Kanbans",
                column: "ChargingChargeNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Kanbans_Chargings_ChargingChargeNo",
                table: "Kanbans",
                column: "ChargingChargeNo",
                principalTable: "Chargings",
                principalColumn: "ChargeNo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kanbans_Chargings_ChargingChargeNo",
                table: "Kanbans");

            migrationBuilder.DropIndex(
                name: "IX_Kanbans_ChargingChargeNo",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "ChargingChargeNo",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "ChargingCode",
                table: "Kanbans");
        }
    }
}
