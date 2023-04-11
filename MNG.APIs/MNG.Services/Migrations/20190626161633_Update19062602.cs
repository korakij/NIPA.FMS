using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class Update19062602 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlPlans_ChemicalCompositionsInLadles_ChemicalCompositionInLadleCode",
                table: "ControlPlans");

            migrationBuilder.AlterColumn<string>(
                name: "ChemicalCompositionInLadleCode",
                table: "ControlPlans",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPlans_ChemicalCompositionsInLadles_ChemicalCompositionInLadleCode",
                table: "ControlPlans",
                column: "ChemicalCompositionInLadleCode",
                principalTable: "ChemicalCompositionsInLadles",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlPlans_ChemicalCompositionsInLadles_ChemicalCompositionInLadleCode",
                table: "ControlPlans");

            migrationBuilder.AlterColumn<string>(
                name: "ChemicalCompositionInLadleCode",
                table: "ControlPlans",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPlans_ChemicalCompositionsInLadles_ChemicalCompositionInLadleCode",
                table: "ControlPlans",
                column: "ChemicalCompositionInLadleCode",
                principalTable: "ChemicalCompositionsInLadles",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
