using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class AddToolingImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "CBImage",
                table: "Toolings",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "CSEImage",
                table: "Toolings",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PPImage",
                table: "Toolings",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SPImage",
                table: "Toolings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CBImage",
                table: "Toolings");

            migrationBuilder.DropColumn(
                name: "CSEImage",
                table: "Toolings");

            migrationBuilder.DropColumn(
                name: "PPImage",
                table: "Toolings");

            migrationBuilder.DropColumn(
                name: "SPImage",
                table: "Toolings");
        }
    }
}
