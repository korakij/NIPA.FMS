using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class Edit260824 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Yield",
                table: "MaterialSpecifications",
                newName: "YieldMin");

            migrationBuilder.RenameColumn(
                name: "GraphiteA",
                table: "MaterialSpecifications",
                newName: "YieldMax");

            migrationBuilder.RenameColumn(
                name: "Elongation",
                table: "MaterialSpecifications",
                newName: "NodularityMax");

            migrationBuilder.AddColumn<float>(
                name: "ElongationMax",
                table: "MaterialSpecifications",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ElongationMin",
                table: "MaterialSpecifications",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "GraphiteAMax",
                table: "MaterialSpecifications",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "GraphiteAMin",
                table: "MaterialSpecifications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ElongationMax",
                table: "MaterialSpecifications");

            migrationBuilder.DropColumn(
                name: "ElongationMin",
                table: "MaterialSpecifications");

            migrationBuilder.DropColumn(
                name: "GraphiteAMax",
                table: "MaterialSpecifications");

            migrationBuilder.DropColumn(
                name: "GraphiteAMin",
                table: "MaterialSpecifications");

            migrationBuilder.RenameColumn(
                name: "YieldMin",
                table: "MaterialSpecifications",
                newName: "Yield");

            migrationBuilder.RenameColumn(
                name: "YieldMax",
                table: "MaterialSpecifications",
                newName: "GraphiteA");

            migrationBuilder.RenameColumn(
                name: "NodularityMax",
                table: "MaterialSpecifications",
                newName: "Elongation");
        }
    }
}
