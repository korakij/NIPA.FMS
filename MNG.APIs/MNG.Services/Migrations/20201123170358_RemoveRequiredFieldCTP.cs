using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class RemoveRequiredFieldCTP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlPlans_ChemicalCompositionsInFurnaces_ChemicalCompositionInFurnaceCode",
                table: "ControlPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlPlans_ChemicalCompositionsInLadles_ChemicalCompositionInLadleCode",
                table: "ControlPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlPlans_MaterialSpecifications_MaterialSpecificationCode",
                table: "ControlPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlPlans_MeltStandards_MeltingCode",
                table: "ControlPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlPlans_MoldStandards_MoldingCode",
                table: "ControlPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlPlans_PourStandards_PouringCode",
                table: "ControlPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlPlans_ShotBlastStandards_ShotBlastingCode",
                table: "ControlPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlPlans_Toolings_ToolingCode",
                table: "ControlPlans");

            migrationBuilder.AlterColumn<string>(
                name: "ToolingCode",
                table: "ControlPlans",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "ShotBlastingCode",
                table: "ControlPlans",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "PouringCode",
                table: "ControlPlans",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "MoldingCode",
                table: "ControlPlans",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "MeltingCode",
                table: "ControlPlans",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "MaterialSpecificationCode",
                table: "ControlPlans",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "ChemicalCompositionInLadleCode",
                table: "ControlPlans",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "ChemicalCompositionInFurnaceCode",
                table: "ControlPlans",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPlans_ChemicalCompositionsInFurnaces_ChemicalCompositionInFurnaceCode",
                table: "ControlPlans",
                column: "ChemicalCompositionInFurnaceCode",
                principalTable: "ChemicalCompositionsInFurnaces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPlans_ChemicalCompositionsInLadles_ChemicalCompositionInLadleCode",
                table: "ControlPlans",
                column: "ChemicalCompositionInLadleCode",
                principalTable: "ChemicalCompositionsInLadles",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPlans_MaterialSpecifications_MaterialSpecificationCode",
                table: "ControlPlans",
                column: "MaterialSpecificationCode",
                principalTable: "MaterialSpecifications",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPlans_MeltStandards_MeltingCode",
                table: "ControlPlans",
                column: "MeltingCode",
                principalTable: "MeltStandards",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPlans_MoldStandards_MoldingCode",
                table: "ControlPlans",
                column: "MoldingCode",
                principalTable: "MoldStandards",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPlans_PourStandards_PouringCode",
                table: "ControlPlans",
                column: "PouringCode",
                principalTable: "PourStandards",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPlans_ShotBlastStandards_ShotBlastingCode",
                table: "ControlPlans",
                column: "ShotBlastingCode",
                principalTable: "ShotBlastStandards",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPlans_Toolings_ToolingCode",
                table: "ControlPlans",
                column: "ToolingCode",
                principalTable: "Toolings",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlPlans_ChemicalCompositionsInFurnaces_ChemicalCompositionInFurnaceCode",
                table: "ControlPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlPlans_ChemicalCompositionsInLadles_ChemicalCompositionInLadleCode",
                table: "ControlPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlPlans_MaterialSpecifications_MaterialSpecificationCode",
                table: "ControlPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlPlans_MeltStandards_MeltingCode",
                table: "ControlPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlPlans_MoldStandards_MoldingCode",
                table: "ControlPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlPlans_PourStandards_PouringCode",
                table: "ControlPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlPlans_ShotBlastStandards_ShotBlastingCode",
                table: "ControlPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlPlans_Toolings_ToolingCode",
                table: "ControlPlans");

            migrationBuilder.AlterColumn<string>(
                name: "ToolingCode",
                table: "ControlPlans",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShotBlastingCode",
                table: "ControlPlans",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PouringCode",
                table: "ControlPlans",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MoldingCode",
                table: "ControlPlans",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MeltingCode",
                table: "ControlPlans",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaterialSpecificationCode",
                table: "ControlPlans",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChemicalCompositionInLadleCode",
                table: "ControlPlans",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChemicalCompositionInFurnaceCode",
                table: "ControlPlans",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPlans_ChemicalCompositionsInFurnaces_ChemicalCompositionInFurnaceCode",
                table: "ControlPlans",
                column: "ChemicalCompositionInFurnaceCode",
                principalTable: "ChemicalCompositionsInFurnaces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPlans_ChemicalCompositionsInLadles_ChemicalCompositionInLadleCode",
                table: "ControlPlans",
                column: "ChemicalCompositionInLadleCode",
                principalTable: "ChemicalCompositionsInLadles",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPlans_MaterialSpecifications_MaterialSpecificationCode",
                table: "ControlPlans",
                column: "MaterialSpecificationCode",
                principalTable: "MaterialSpecifications",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPlans_MeltStandards_MeltingCode",
                table: "ControlPlans",
                column: "MeltingCode",
                principalTable: "MeltStandards",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPlans_MoldStandards_MoldingCode",
                table: "ControlPlans",
                column: "MoldingCode",
                principalTable: "MoldStandards",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPlans_PourStandards_PouringCode",
                table: "ControlPlans",
                column: "PouringCode",
                principalTable: "PourStandards",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPlans_ShotBlastStandards_ShotBlastingCode",
                table: "ControlPlans",
                column: "ShotBlastingCode",
                principalTable: "ShotBlastStandards",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPlans_Toolings_ToolingCode",
                table: "ControlPlans",
                column: "ToolingCode",
                principalTable: "Toolings",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
