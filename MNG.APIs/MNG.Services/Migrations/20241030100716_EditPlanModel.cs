using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class EditPlanModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "PlanDetails");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Plans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "PlanDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PlanDetails");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "PlanDetails",
                nullable: false,
                defaultValue: 0);
        }
    }
}
