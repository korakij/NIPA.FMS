using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class UpdatePouringModel03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductCode",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pourings_ProductCode",
                table: "Pourings",
                column: "ProductCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Pourings_Products_ProductCode",
                table: "Pourings",
                column: "ProductCode",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pourings_Products_ProductCode",
                table: "Pourings");

            migrationBuilder.DropIndex(
                name: "IX_Pourings_ProductCode",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "Pourings");
        }
    }
}
