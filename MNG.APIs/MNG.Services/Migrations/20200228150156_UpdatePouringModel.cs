using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class UpdatePouringModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Duration",
                table: "Pourings",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDurationOK",
                table: "Pourings",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFirstTempOK",
                table: "Pourings",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLastTempOK",
                table: "Pourings",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsNoOfMoldOK",
                table: "Pourings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "IsDurationOK",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "IsFirstTempOK",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "IsLastTempOK",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "IsNoOfMoldOK",
                table: "Pourings");
        }
    }
}
