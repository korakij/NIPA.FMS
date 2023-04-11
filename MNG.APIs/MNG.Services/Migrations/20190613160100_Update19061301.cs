using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class Update19061301 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestChemInLadle");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Kanbans",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "Result_Al",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Result_C",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Result_CCE",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Result_Cr",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Result_Cu",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Result_Mg",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Result_Mn",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Result_Mo",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Result_Ni",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Result_P",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Result_S",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Result_Si",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Result_Sn",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Result_Te",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Result_Ti",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Result_V",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_Al",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_C",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_CCE",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_Cr",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_Cu",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_Mg",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_Mn",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_Mo",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_Ni",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_P",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_S",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_Si",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_Sn",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_Te",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_Ti",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_V",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChemicalCompositionInLadleCode",
                table: "ControlPlans",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChemicalCompositionsInLadles",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    CCEMax = table.Column<float>(nullable: true),
                    CCEMin = table.Column<float>(nullable: true),
                    CMax = table.Column<float>(nullable: true),
                    CMin = table.Column<float>(nullable: true),
                    SiMax = table.Column<float>(nullable: true),
                    SiMin = table.Column<float>(nullable: true),
                    MnMax = table.Column<float>(nullable: true),
                    MnMin = table.Column<float>(nullable: true),
                    MgMax = table.Column<float>(nullable: true),
                    MgMin = table.Column<float>(nullable: true),
                    SMax = table.Column<float>(nullable: true),
                    SMin = table.Column<float>(nullable: true),
                    AlMax = table.Column<float>(nullable: true),
                    AlMin = table.Column<float>(nullable: true),
                    CuMax = table.Column<float>(nullable: true),
                    CuMin = table.Column<float>(nullable: true),
                    SnMax = table.Column<float>(nullable: true),
                    SnMin = table.Column<float>(nullable: true),
                    CrMax = table.Column<float>(nullable: true),
                    CrMin = table.Column<float>(nullable: true),
                    PMax = table.Column<float>(nullable: true),
                    PMin = table.Column<float>(nullable: true),
                    MoMax = table.Column<float>(nullable: true),
                    MoMin = table.Column<float>(nullable: true),
                    NiMax = table.Column<float>(nullable: true),
                    NiMin = table.Column<float>(nullable: true),
                    VMax = table.Column<float>(nullable: true),
                    VMin = table.Column<float>(nullable: true),
                    TiMax = table.Column<float>(nullable: true),
                    TiMin = table.Column<float>(nullable: true),
                    TeMax = table.Column<float>(nullable: true),
                    TeMin = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChemicalCompositionsInLadles", x => x.Code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlPlans_ChemicalCompositionInLadleCode",
                table: "ControlPlans",
                column: "ChemicalCompositionInLadleCode");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPlans_ChemicalCompositionsInLadles_ChemicalCompositionInLadleCode",
                table: "ControlPlans",
                column: "ChemicalCompositionInLadleCode",
                principalTable: "ChemicalCompositionsInLadles",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlPlans_ChemicalCompositionsInLadles_ChemicalCompositionInLadleCode",
                table: "ControlPlans");

            migrationBuilder.DropTable(
                name: "ChemicalCompositionsInLadles");

            migrationBuilder.DropIndex(
                name: "IX_ControlPlans_ChemicalCompositionInLadleCode",
                table: "ControlPlans");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Result_Al",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Result_C",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Result_CCE",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Result_Cr",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Result_Cu",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Result_Mg",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Result_Mn",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Result_Mo",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Result_Ni",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Result_P",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Result_S",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Result_Si",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Result_Sn",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Result_Te",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Result_Ti",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Result_V",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_Al",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_C",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_CCE",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_Cr",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_Cu",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_Mg",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_Mn",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_Mo",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_Ni",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_P",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_S",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_Si",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_Sn",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_Te",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_Ti",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_V",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "ChemicalCompositionInLadleCode",
                table: "ControlPlans");

            migrationBuilder.CreateTable(
                name: "TestChemInLadle",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    KanbanCode = table.Column<string>(maxLength: 20, nullable: false),
                    ProductId = table.Column<int>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    Result_Al = table.Column<float>(nullable: true),
                    Result_C = table.Column<float>(nullable: true),
                    Result_CCE = table.Column<float>(nullable: true),
                    Result_Cr = table.Column<float>(nullable: true),
                    Result_Cu = table.Column<float>(nullable: true),
                    Result_Mg = table.Column<float>(nullable: true),
                    Result_Mn = table.Column<float>(nullable: true),
                    Result_Mo = table.Column<float>(nullable: true),
                    Result_Ni = table.Column<float>(nullable: true),
                    Result_P = table.Column<float>(nullable: true),
                    Result_S = table.Column<float>(nullable: true),
                    Result_Si = table.Column<float>(nullable: true),
                    Result_Sn = table.Column<float>(nullable: true),
                    Result_Te = table.Column<float>(nullable: true),
                    Result_Ti = table.Column<float>(nullable: true),
                    Result_V = table.Column<float>(nullable: true),
                    Validation_IsOk_Al = table.Column<bool>(nullable: true),
                    Validation_IsOk_C = table.Column<bool>(nullable: true),
                    Validation_IsOk_CCE = table.Column<bool>(nullable: true),
                    Validation_IsOk_Cr = table.Column<bool>(nullable: true),
                    Validation_IsOk_Cu = table.Column<bool>(nullable: true),
                    Validation_IsOk_Mg = table.Column<bool>(nullable: true),
                    Validation_IsOk_Mn = table.Column<bool>(nullable: true),
                    Validation_IsOk_Mo = table.Column<bool>(nullable: true),
                    Validation_IsOk_Ni = table.Column<bool>(nullable: true),
                    Validation_IsOk_P = table.Column<bool>(nullable: true),
                    Validation_IsOk_S = table.Column<bool>(nullable: true),
                    Validation_IsOk_Si = table.Column<bool>(nullable: true),
                    Validation_IsOk_Sn = table.Column<bool>(nullable: true),
                    Validation_IsOk_Te = table.Column<bool>(nullable: true),
                    Validation_IsOk_Ti = table.Column<bool>(nullable: true),
                    Validation_IsOk_V = table.Column<bool>(nullable: true)
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
    }
}
