using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class AddPouringModel01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pouring",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Line = table.Column<int>(nullable: false),
                    LineCode = table.Column<string>(nullable: true),
                    FirstTemp = table.Column<int>(nullable: true),
                    LastTemp = table.Column<int>(nullable: true),
                    NumberOfMold = table.Column<int>(nullable: true),
                    KanbanCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pouring", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Pouring_Kanbans_KanbanCode",
                        column: x => x.KanbanCode,
                        principalTable: "Kanbans",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pouring_KanbanCode",
                table: "Pouring",
                column: "KanbanCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pouring");
        }
    }
}
