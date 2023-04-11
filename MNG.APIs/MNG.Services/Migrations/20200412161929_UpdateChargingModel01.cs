using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class UpdateChargingModel01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Interval",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PowerComp",
                table: "Chargings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Interval",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "PowerComp",
                table: "Chargings");
        }
    }
}
