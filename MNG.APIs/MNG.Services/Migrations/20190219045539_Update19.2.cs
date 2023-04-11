using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class Update192 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlPlans_Specifications_SpecificationCode",
                table: "ControlPlans");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropIndex(
                name: "IX_ControlPlans_SpecificationCode",
                table: "ControlPlans");

            migrationBuilder.DropColumn(
                name: "SpecificationCode",
                table: "ControlPlans");

            migrationBuilder.AddColumn<string>(
                name: "ChemicalCompositionInFurnaceCode",
                table: "ControlPlans",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ChemicalCompositionsInFurnaces",
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
                    table.PrimaryKey("PK_ChemicalCompositionsInFurnaces", x => x.Code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlPlans_ChemicalCompositionInFurnaceCode",
                table: "ControlPlans",
                column: "ChemicalCompositionInFurnaceCode");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPlans_ChemicalCompositionsInFurnaces_ChemicalCompositionInFurnaceCode",
                table: "ControlPlans",
                column: "ChemicalCompositionInFurnaceCode",
                principalTable: "ChemicalCompositionsInFurnaces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlPlans_ChemicalCompositionsInFurnaces_ChemicalCompositionInFurnaceCode",
                table: "ControlPlans");

            migrationBuilder.DropTable(
                name: "ChemicalCompositionsInFurnaces");

            migrationBuilder.DropIndex(
                name: "IX_ControlPlans_ChemicalCompositionInFurnaceCode",
                table: "ControlPlans");

            migrationBuilder.DropColumn(
                name: "ChemicalCompositionInFurnaceCode",
                table: "ControlPlans");

            migrationBuilder.AddColumn<string>(
                name: "SpecificationCode",
                table: "ControlPlans",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 1024, nullable: true),
                    Furnace_AlMax = table.Column<float>(nullable: true),
                    Furnace_AlMin = table.Column<float>(nullable: true),
                    Furnace_CCEMax = table.Column<float>(nullable: true),
                    Furnace_CCEMin = table.Column<float>(nullable: true),
                    Furnace_CMax = table.Column<float>(nullable: true),
                    Furnace_CMin = table.Column<float>(nullable: true),
                    Furnace_CrMax = table.Column<float>(nullable: true),
                    Furnace_CrMin = table.Column<float>(nullable: true),
                    Furnace_CuMax = table.Column<float>(nullable: true),
                    Furnace_CuMin = table.Column<float>(nullable: true),
                    Furnace_MgMax = table.Column<float>(nullable: true),
                    Furnace_MgMin = table.Column<float>(nullable: true),
                    Furnace_MnMax = table.Column<float>(nullable: true),
                    Furnace_MnMin = table.Column<float>(nullable: true),
                    Furnace_MoMax = table.Column<float>(nullable: true),
                    Furnace_MoMin = table.Column<float>(nullable: true),
                    Furnace_NiMax = table.Column<float>(nullable: true),
                    Furnace_NiMin = table.Column<float>(nullable: true),
                    Furnace_PMax = table.Column<float>(nullable: true),
                    Furnace_PMin = table.Column<float>(nullable: true),
                    Furnace_SMax = table.Column<float>(nullable: true),
                    Furnace_SMin = table.Column<float>(nullable: true),
                    Furnace_SiMax = table.Column<float>(nullable: true),
                    Furnace_SiMin = table.Column<float>(nullable: true),
                    Furnace_SnMax = table.Column<float>(nullable: true),
                    Furnace_SnMin = table.Column<float>(nullable: true),
                    Furnace_TeMax = table.Column<float>(nullable: true),
                    Furnace_TeMin = table.Column<float>(nullable: true),
                    Furnace_TiMax = table.Column<float>(nullable: true),
                    Furnace_TiMin = table.Column<float>(nullable: true),
                    Furnace_VMax = table.Column<float>(nullable: true),
                    Furnace_VMin = table.Column<float>(nullable: true),
                    Ladle_AlMax = table.Column<float>(nullable: true),
                    Ladle_AlMin = table.Column<float>(nullable: true),
                    Ladle_CCEMax = table.Column<float>(nullable: true),
                    Ladle_CCEMin = table.Column<float>(nullable: true),
                    Ladle_CMax = table.Column<float>(nullable: true),
                    Ladle_CMin = table.Column<float>(nullable: true),
                    Ladle_CrMax = table.Column<float>(nullable: true),
                    Ladle_CrMin = table.Column<float>(nullable: true),
                    Ladle_CuMax = table.Column<float>(nullable: true),
                    Ladle_CuMin = table.Column<float>(nullable: true),
                    Ladle_MgMax = table.Column<float>(nullable: true),
                    Ladle_MgMin = table.Column<float>(nullable: true),
                    Ladle_MnMax = table.Column<float>(nullable: true),
                    Ladle_MnMin = table.Column<float>(nullable: true),
                    Ladle_MoMax = table.Column<float>(nullable: true),
                    Ladle_MoMin = table.Column<float>(nullable: true),
                    Ladle_NiMax = table.Column<float>(nullable: true),
                    Ladle_NiMin = table.Column<float>(nullable: true),
                    Ladle_PMax = table.Column<float>(nullable: true),
                    Ladle_PMin = table.Column<float>(nullable: true),
                    Ladle_SMax = table.Column<float>(nullable: true),
                    Ladle_SMin = table.Column<float>(nullable: true),
                    Ladle_SiMax = table.Column<float>(nullable: true),
                    Ladle_SiMin = table.Column<float>(nullable: true),
                    Ladle_SnMax = table.Column<float>(nullable: true),
                    Ladle_SnMin = table.Column<float>(nullable: true),
                    Ladle_TeMax = table.Column<float>(nullable: true),
                    Ladle_TeMin = table.Column<float>(nullable: true),
                    Ladle_TiMax = table.Column<float>(nullable: true),
                    Ladle_TiMin = table.Column<float>(nullable: true),
                    Ladle_VMax = table.Column<float>(nullable: true),
                    Ladle_VMin = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlPlans_SpecificationCode",
                table: "ControlPlans",
                column: "SpecificationCode");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPlans_Specifications_SpecificationCode",
                table: "ControlPlans",
                column: "SpecificationCode",
                principalTable: "Specifications",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
