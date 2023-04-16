using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class AddCTPinKanban : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ControlPlanId",
                table: "Kanbans",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kanbans_ControlPlanId",
                table: "Kanbans",
                column: "ControlPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kanbans_ControlPlans_ControlPlanId",
                table: "Kanbans",
                column: "ControlPlanId",
                principalTable: "ControlPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kanbans_ControlPlans_ControlPlanId",
                table: "Kanbans");

            migrationBuilder.DropIndex(
                name: "IX_Kanbans_ControlPlanId",
                table: "Kanbans");

            migrationBuilder.DropColumn(
                name: "ControlPlanId",
                table: "Kanbans");
        }
    }
}
