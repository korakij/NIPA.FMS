using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class CreateLotNoModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FurnaceCode",
                table: "LotNos",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "LotNos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Shift",
                table: "LotNos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LotNos_FurnaceCode",
                table: "LotNos",
                column: "FurnaceCode");

            migrationBuilder.AddForeignKey(
                name: "FK_LotNos_Furnace_FurnaceCode",
                table: "LotNos",
                column: "FurnaceCode",
                principalTable: "Furnace",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LotNos_Furnace_FurnaceCode",
                table: "LotNos");

            migrationBuilder.DropIndex(
                name: "IX_LotNos_FurnaceCode",
                table: "LotNos");

            migrationBuilder.DropColumn(
                name: "FurnaceCode",
                table: "LotNos");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "LotNos");

            migrationBuilder.DropColumn(
                name: "Shift",
                table: "LotNos");
        }
    }
}
