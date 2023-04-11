using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class AddMoldingModel01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfMold",
                table: "Pouring",
                newName: "NoOfPouredMold");

            migrationBuilder.AddColumn<string>(
                name: "MoldingCode",
                table: "Pouring",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Molding",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Line = table.Column<int>(nullable: false),
                    LineCode = table.Column<string>(nullable: true),
                    ToolingCode = table.Column<string>(nullable: true),
                    NoOfMold = table.Column<int>(nullable: false),
                    Compressibility = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Molding", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Molding_Toolings_ToolingCode",
                        column: x => x.ToolingCode,
                        principalTable: "Toolings",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pouring_MoldingCode",
                table: "Pouring",
                column: "MoldingCode");

            migrationBuilder.CreateIndex(
                name: "IX_Molding_ToolingCode",
                table: "Molding",
                column: "ToolingCode",
                unique: true,
                filter: "[ToolingCode] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Pouring_Molding_MoldingCode",
                table: "Pouring",
                column: "MoldingCode",
                principalTable: "Molding",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pouring_Molding_MoldingCode",
                table: "Pouring");

            migrationBuilder.DropTable(
                name: "Molding");

            migrationBuilder.DropIndex(
                name: "IX_Pouring_MoldingCode",
                table: "Pouring");

            migrationBuilder.DropColumn(
                name: "MoldingCode",
                table: "Pouring");

            migrationBuilder.RenameColumn(
                name: "NoOfPouredMold",
                table: "Pouring",
                newName: "NumberOfMold");
        }
    }
}
