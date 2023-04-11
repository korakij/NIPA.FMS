using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class UpdateKanban : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaterialCode",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kanbans_MaterialCode",
                table: "Kanbans",
                column: "MaterialCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Kanbans_Materials_MaterialCode",
                table: "Kanbans",
                column: "MaterialCode",
                principalTable: "Materials",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kanbans_Materials_MaterialCode",
                table: "Kanbans");

            migrationBuilder.DropIndex(
                name: "IX_Kanbans_MaterialCode",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "MaterialCode",
                table: "Kanbans");
        }
    }
}
