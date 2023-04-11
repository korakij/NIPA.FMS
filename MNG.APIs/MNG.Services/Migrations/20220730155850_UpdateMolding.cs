using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class UpdateMolding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Molding_Toolings_ToolingCode",
                table: "Molding");

            migrationBuilder.DropIndex(
                name: "IX_Molding_ToolingCode",
                table: "Molding");

            migrationBuilder.DropColumn(
                name: "ToolingCode",
                table: "Molding");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ToolingCode",
                table: "Molding",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Molding_ToolingCode",
                table: "Molding",
                column: "ToolingCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Molding_Toolings_ToolingCode",
                table: "Molding",
                column: "ToolingCode",
                principalTable: "Toolings",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
