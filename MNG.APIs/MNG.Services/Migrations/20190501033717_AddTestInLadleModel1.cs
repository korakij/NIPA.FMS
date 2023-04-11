using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class AddTestInLadleModel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("UPDATE TestChemicalCompositions SET [Time]='2019-01-01T00:00:00' ");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "TestChemicalCompositions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TestChemInLadle",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: true),
                    Result_CCE = table.Column<float>(nullable: true),
                    Result_C = table.Column<float>(nullable: true),
                    Result_Si = table.Column<float>(nullable: true),
                    Result_Mn = table.Column<float>(nullable: true),
                    Result_Mg = table.Column<float>(nullable: true),
                    Result_S = table.Column<float>(nullable: true),
                    Result_Al = table.Column<float>(nullable: true),
                    Result_Cu = table.Column<float>(nullable: true),
                    Result_Sn = table.Column<float>(nullable: true),
                    Result_Cr = table.Column<float>(nullable: true),
                    Result_P = table.Column<float>(nullable: true),
                    Result_Mo = table.Column<float>(nullable: true),
                    Result_Ni = table.Column<float>(nullable: true),
                    Result_V = table.Column<float>(nullable: true),
                    Result_Ti = table.Column<float>(nullable: true),
                    Result_Te = table.Column<float>(nullable: true),
                    Validation_IsOk_CCE = table.Column<bool>(nullable: true),
                    Validation_IsOk_C = table.Column<bool>(nullable: true),
                    Validation_IsOk_Si = table.Column<bool>(nullable: true),
                    Validation_IsOk_Mn = table.Column<bool>(nullable: true),
                    Validation_IsOk_Mg = table.Column<bool>(nullable: true),
                    Validation_IsOk_S = table.Column<bool>(nullable: true),
                    Validation_IsOk_Al = table.Column<bool>(nullable: true),
                    Validation_IsOk_Cu = table.Column<bool>(nullable: true),
                    Validation_IsOk_Sn = table.Column<bool>(nullable: true),
                    Validation_IsOk_Cr = table.Column<bool>(nullable: true),
                    Validation_IsOk_P = table.Column<bool>(nullable: true),
                    Validation_IsOk_Mo = table.Column<bool>(nullable: true),
                    Validation_IsOk_Ni = table.Column<bool>(nullable: true),
                    Validation_IsOk_V = table.Column<bool>(nullable: true),
                    Validation_IsOk_Ti = table.Column<bool>(nullable: true),
                    Validation_IsOk_Te = table.Column<bool>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false),
                    KanbanCode = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestChemInLadle", x => x.Code);
                    table.ForeignKey(
                        name: "FK_TestChemInLadle_Kanbans_KanbanCode",
                        column: x => x.KanbanCode,
                        principalTable: "Kanbans",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestChemInLadle_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestChemInLadle_KanbanCode",
                table: "TestChemInLadle",
                column: "KanbanCode");

            migrationBuilder.CreateIndex(
                name: "IX_TestChemInLadle_ProductId",
                table: "TestChemInLadle",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestChemInLadle");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "TestChemicalCompositions",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
