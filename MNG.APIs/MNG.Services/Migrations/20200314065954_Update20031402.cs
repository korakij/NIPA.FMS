using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class Update20031402 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pourings_Line_LineCode",
                table: "Pourings");

            migrationBuilder.AlterColumn<string>(
                name: "LineCode",
                table: "Pourings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pourings_Line_LineCode",
                table: "Pourings",
                column: "LineCode",
                principalTable: "Line",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pourings_Line_LineCode",
                table: "Pourings");

            migrationBuilder.AlterColumn<string>(
                name: "LineCode",
                table: "Pourings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Pourings_Line_LineCode",
                table: "Pourings",
                column: "LineCode",
                principalTable: "Line",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
