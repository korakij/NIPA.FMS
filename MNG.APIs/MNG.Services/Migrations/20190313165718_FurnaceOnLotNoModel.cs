using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class FurnaceOnLotNoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LotNoCode",
                table: "Furnaces",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Furnaces_LotNoCode",
                table: "Furnaces",
                column: "LotNoCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Furnaces_LotNos_LotNoCode",
                table: "Furnaces",
                column: "LotNoCode",
                principalTable: "LotNos",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Furnaces_LotNos_LotNoCode",
                table: "Furnaces");

            migrationBuilder.DropIndex(
                name: "IX_Furnaces_LotNoCode",
                table: "Furnaces");

            migrationBuilder.DropColumn(
                name: "LotNoCode",
                table: "Furnaces");
        }
    }
}
