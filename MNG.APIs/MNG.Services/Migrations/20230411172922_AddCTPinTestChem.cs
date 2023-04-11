using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class AddCTPinTestChem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ControlPlanId",
                table: "TestChemicalCompositions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestChemicalCompositions_ControlPlanId",
                table: "TestChemicalCompositions",
                column: "ControlPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestChemicalCompositions_ControlPlans_ControlPlanId",
                table: "TestChemicalCompositions",
                column: "ControlPlanId",
                principalTable: "ControlPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestChemicalCompositions_ControlPlans_ControlPlanId",
                table: "TestChemicalCompositions");

            migrationBuilder.DropIndex(
                name: "IX_TestChemicalCompositions_ControlPlanId",
                table: "TestChemicalCompositions");

            migrationBuilder.DropColumn(
                name: "ControlPlanId",
                table: "TestChemicalCompositions");
        }
    }
}
