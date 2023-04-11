using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class AddProductIdInCharging : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Molding_ToolingCode",
                table: "Molding");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Chargings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Molding_ToolingCode",
                table: "Molding",
                column: "ToolingCode");

            migrationBuilder.CreateIndex(
                name: "IX_Chargings_ProductId",
                table: "Chargings",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chargings_Products_ProductId",
                table: "Chargings",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chargings_Products_ProductId",
                table: "Chargings");

            migrationBuilder.DropIndex(
                name: "IX_Molding_ToolingCode",
                table: "Molding");

            migrationBuilder.DropIndex(
                name: "IX_Chargings_ProductId",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Chargings");

            migrationBuilder.CreateIndex(
                name: "IX_Molding_ToolingCode",
                table: "Molding",
                column: "ToolingCode",
                unique: true,
                filter: "[ToolingCode] IS NOT NULL");
        }
    }
}
