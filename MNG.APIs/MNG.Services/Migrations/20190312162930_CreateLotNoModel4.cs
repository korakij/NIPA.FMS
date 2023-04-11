using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class CreateLotNoModel4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LotNoCode",
                table: "Chargings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chargings_LotNoCode",
                table: "Chargings",
                column: "LotNoCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Chargings_LotNos_LotNoCode",
                table: "Chargings",
                column: "LotNoCode",
                principalTable: "LotNos",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chargings_LotNos_LotNoCode",
                table: "Chargings");

            migrationBuilder.DropIndex(
                name: "IX_Chargings_LotNoCode",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "LotNoCode",
                table: "Chargings");
        }
    }
}
