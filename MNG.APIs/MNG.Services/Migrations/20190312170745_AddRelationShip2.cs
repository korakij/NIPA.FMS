using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class AddRelationShip2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LotNos_Furnaces_FurnaceCode",
                table: "LotNos");

            migrationBuilder.AlterColumn<string>(
                name: "FurnaceCode",
                table: "LotNos",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LotNos_Furnaces_FurnaceCode",
                table: "LotNos",
                column: "FurnaceCode",
                principalTable: "Furnaces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LotNos_Furnaces_FurnaceCode",
                table: "LotNos");

            migrationBuilder.AlterColumn<string>(
                name: "FurnaceCode",
                table: "LotNos",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AddForeignKey(
                name: "FK_LotNos_Furnaces_FurnaceCode",
                table: "LotNos",
                column: "FurnaceCode",
                principalTable: "Furnaces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
