using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class UpdateCharging : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ControlPlanId",
                table: "Chargings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chargings_ControlPlanId",
                table: "Chargings",
                column: "ControlPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chargings_ControlPlans_ControlPlanId",
                table: "Chargings",
                column: "ControlPlanId",
                principalTable: "ControlPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chargings_ControlPlans_ControlPlanId",
                table: "Chargings");

            migrationBuilder.DropIndex(
                name: "IX_Chargings_ControlPlanId",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ControlPlanId",
                table: "Chargings");
        }
    }
}
