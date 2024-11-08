using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class EditPlan241101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Plans");

            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "Plans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creator",
                table: "Plans");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Plans",
                nullable: false,
                defaultValue: 0);
        }
    }
}
