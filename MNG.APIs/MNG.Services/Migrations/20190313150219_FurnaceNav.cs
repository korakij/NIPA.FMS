using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class FurnaceNav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FurnaceCode",
                table: "LotNos",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_LotNos_FurnaceCode",
                table: "LotNos",
                column: "FurnaceCode");

            migrationBuilder.AddForeignKey(
                name: "FK_LotNos_Furnaces_FurnaceCode",
                table: "LotNos",
                column: "FurnaceCode",
                principalTable: "Furnaces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
