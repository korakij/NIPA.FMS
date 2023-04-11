using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class LotNoNavKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chargings_LotNos_LotNoCode",
                table: "Chargings");

            migrationBuilder.AlterColumn<string>(
                name: "LotNoCode",
                table: "Chargings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Chargings_LotNos_LotNoCode",
                table: "Chargings",
                column: "LotNoCode",
                principalTable: "LotNos",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chargings_LotNos_LotNoCode",
                table: "Chargings");

            migrationBuilder.AlterColumn<string>(
                name: "LotNoCode",
                table: "Chargings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Chargings_LotNos_LotNoCode",
                table: "Chargings",
                column: "LotNoCode",
                principalTable: "LotNos",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
