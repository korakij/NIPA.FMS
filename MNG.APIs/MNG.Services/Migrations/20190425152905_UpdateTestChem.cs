using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class UpdateTestChem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestChemicalCompositions_Products_ProductId",
                table: "TestChemicalCompositions");

            migrationBuilder.DropColumn(
                name: "Result_IsOk_CCE",
                table: "TestChemicalCompositions");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "TestChemicalCompositions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_TestChemicalCompositions_Products_ProductId",
                table: "TestChemicalCompositions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestChemicalCompositions_Products_ProductId",
                table: "TestChemicalCompositions");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "TestChemicalCompositions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Result_IsOk_CCE",
                table: "TestChemicalCompositions",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TestChemicalCompositions_Products_ProductId",
                table: "TestChemicalCompositions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
