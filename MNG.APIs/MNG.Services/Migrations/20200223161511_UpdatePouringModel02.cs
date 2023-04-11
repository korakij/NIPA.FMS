using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class UpdatePouringModel02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pourings_Products_ProductId1",
                table: "Pourings");

            migrationBuilder.DropIndex(
                name: "IX_Pourings_ProductId1",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Pourings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "Pourings",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "Pourings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pourings_ProductId1",
                table: "Pourings",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pourings_Products_ProductId1",
                table: "Pourings",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
