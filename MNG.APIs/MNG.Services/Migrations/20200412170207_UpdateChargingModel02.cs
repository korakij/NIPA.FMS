﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class UpdateChargingModel02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Chargings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Chargings");
        }
    }
}
