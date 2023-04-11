using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class CreateLotNoModel5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LotNos_Furnace_FurnaceCode",
                table: "LotNos");

            migrationBuilder.DropIndex(
                name: "IX_LotNos_FurnaceCode",
                table: "LotNos");

            migrationBuilder.AlterColumn<string>(
                name: "FurnaceCode",
                table: "LotNos",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.CreateIndex(
                name: "IX_LotNos_FurnaceCode",
                table: "LotNos",
                column: "FurnaceCode",
                unique: true,
                filter: "[FurnaceCode] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_LotNos_Furnace_FurnaceCode",
                table: "LotNos",
                column: "FurnaceCode",
                principalTable: "Furnace",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LotNos_Furnace_FurnaceCode",
                table: "LotNos");

            migrationBuilder.DropIndex(
                name: "IX_LotNos_FurnaceCode",
                table: "LotNos");

            migrationBuilder.AlterColumn<string>(
                name: "FurnaceCode",
                table: "LotNos",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LotNos_FurnaceCode",
                table: "LotNos",
                column: "FurnaceCode",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LotNos_Furnace_FurnaceCode",
                table: "LotNos",
                column: "FurnaceCode",
                principalTable: "Furnace",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
