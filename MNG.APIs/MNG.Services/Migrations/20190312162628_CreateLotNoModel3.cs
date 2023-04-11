using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class CreateLotNoModel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chargings_Furnace_FurnaceCode",
                table: "Chargings");

            migrationBuilder.DropIndex(
                name: "IX_LotNos_FurnaceCode",
                table: "LotNos");

            migrationBuilder.DropIndex(
                name: "IX_Chargings_FurnaceCode",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "FurnaceCode",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "Shift",
                table: "Chargings");

            migrationBuilder.CreateIndex(
                name: "IX_LotNos_FurnaceCode",
                table: "LotNos",
                column: "FurnaceCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LotNos_FurnaceCode",
                table: "LotNos");

            migrationBuilder.AddColumn<string>(
                name: "FurnaceCode",
                table: "Chargings",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Shift",
                table: "Chargings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LotNos_FurnaceCode",
                table: "LotNos",
                column: "FurnaceCode");

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
