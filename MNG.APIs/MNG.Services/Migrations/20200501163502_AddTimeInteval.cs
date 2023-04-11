using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class AddTimeInteval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "StartKwHr",
                table: "Chargings",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PowerComp",
                table: "Chargings",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "MaxTempKwHr",
                table: "Chargings",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "StartKwHr",
                table: "Chargings",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "PowerComp",
                table: "Chargings",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<float>(
                name: "MaxTempKwHr",
                table: "Chargings",
                nullable: true,
                oldClrType: typeof(double));
        }
    }
}
