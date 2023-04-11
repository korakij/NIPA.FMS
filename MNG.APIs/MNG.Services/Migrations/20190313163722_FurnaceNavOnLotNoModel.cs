using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class FurnaceNavOnLotNoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DimensionCose",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "FurnaceCode",
                table: "LotNos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LotNos_FurnaceCode",
                table: "LotNos",
                column: "FurnaceCode",
                unique: true,
                filter: "[FurnaceCode] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_LotNos_Furnaces_FurnaceCode",
                table: "LotNos",
                column: "FurnaceCode",
                principalTable: "Furnaces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LotNos_Furnaces_FurnaceCode",
                table: "LotNos");

            migrationBuilder.DropIndex(
                name: "IX_LotNos_FurnaceCode",
                table: "LotNos");

            migrationBuilder.DropColumn(
                name: "FurnaceCode",
                table: "LotNos");

            migrationBuilder.AddColumn<string>(
                name: "DimensionCose",
                table: "Products",
                nullable: true);
        }
    }
}
