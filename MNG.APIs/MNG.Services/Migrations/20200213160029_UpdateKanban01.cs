using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class UpdateKanban01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MatValidation_IsOk_Chill",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MatValidation_IsOk_Copper",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MatValidation_IsOk_FeedTemp",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MatValidation_IsOk_Inoculant",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MatValidation_IsOk_Magnesium",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MatValidation_IsOk_Tin",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MatValidation_IsOk_WireInoculant",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MatValidation_IsOk_WireMagnesium",
                table: "Kanbans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatValidation_IsOk_Chill",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "MatValidation_IsOk_Copper",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "MatValidation_IsOk_FeedTemp",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "MatValidation_IsOk_Inoculant",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "MatValidation_IsOk_Magnesium",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "MatValidation_IsOk_Tin",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "MatValidation_IsOk_WireInoculant",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "MatValidation_IsOk_WireMagnesium",
                table: "Kanbans");
        }
    }
}
