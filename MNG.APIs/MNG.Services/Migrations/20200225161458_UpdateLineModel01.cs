using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class UpdateLineModel01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pourings_Molding_MoldingCode",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Line",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "Line",
                table: "Molding");

            migrationBuilder.AlterColumn<string>(
                name: "MoldingCode",
                table: "Pourings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LineCode",
                table: "Pourings",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastMoldTime",
                table: "Pourings",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FirstMoldTime",
                table: "Pourings",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "LineCode",
                table: "Molding",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Line",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Line", x => x.Code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pourings_LineCode",
                table: "Pourings",
                column: "LineCode");

            migrationBuilder.CreateIndex(
                name: "IX_Molding_LineCode",
                table: "Molding",
                column: "LineCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Molding_Line_LineCode",
                table: "Molding",
                column: "LineCode",
                principalTable: "Line",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pourings_Line_LineCode",
                table: "Pourings",
                column: "LineCode",
                principalTable: "Line",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pourings_Molding_MoldingCode",
                table: "Pourings",
                column: "MoldingCode",
                principalTable: "Molding",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Molding_Line_LineCode",
                table: "Molding");

            migrationBuilder.DropForeignKey(
                name: "FK_Pourings_Line_LineCode",
                table: "Pourings");

            migrationBuilder.DropForeignKey(
                name: "FK_Pourings_Molding_MoldingCode",
                table: "Pourings");

            migrationBuilder.DropTable(
                name: "Line");

            migrationBuilder.DropIndex(
                name: "IX_Pourings_LineCode",
                table: "Pourings");

            migrationBuilder.DropIndex(
                name: "IX_Molding_LineCode",
                table: "Molding");

            migrationBuilder.AlterColumn<string>(
                name: "MoldingCode",
                table: "Pourings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LineCode",
                table: "Pourings",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastMoldTime",
                table: "Pourings",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FirstMoldTime",
                table: "Pourings",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Line",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "LineCode",
                table: "Molding",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Line",
                table: "Molding",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Pourings_Molding_MoldingCode",
                table: "Pourings",
                column: "MoldingCode",
                principalTable: "Molding",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
