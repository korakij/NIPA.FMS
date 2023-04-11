using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class UpdateToolingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "SPThickness",
                table: "Toolings",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<float>(
                name: "SPHeight",
                table: "Toolings",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<float>(
                name: "PPThickness",
                table: "Toolings",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<float>(
                name: "PPHeight",
                table: "Toolings",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<float>(
                name: "MinDistance",
                table: "Toolings",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AddColumn<int>(
                name: "Cavity",
                table: "Toolings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cavity",
                table: "Toolings");

            migrationBuilder.AlterColumn<float>(
                name: "SPThickness",
                table: "Toolings",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "SPHeight",
                table: "Toolings",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "PPThickness",
                table: "Toolings",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "PPHeight",
                table: "Toolings",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "MinDistance",
                table: "Toolings",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);
        }
    }
}
