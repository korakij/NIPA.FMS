using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class AddQAModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "QInspect_Cementite",
                table: "Pourings",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "QInspect_Count",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "QInspect_Elongation",
                table: "Pourings",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "QInspect_Ferrite",
                table: "Pourings",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "QInspect_GraphiteA",
                table: "Pourings",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<byte[]>(
                name: "QInspect_GraphiteImg",
                table: "Pourings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QInspect_Hardness",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "QInspect_MatrixImg",
                table: "Pourings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "QInspect_Nodularity",
                table: "Pourings",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "QInspect_Pearlite",
                table: "Pourings",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "QInspect_Size",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QInspect_Tensile",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QInspect_Yeild",
                table: "Pourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TappingTemp",
                table: "Kanbans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QInspect_Cementite",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "QInspect_Count",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "QInspect_Elongation",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "QInspect_Ferrite",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "QInspect_GraphiteA",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "QInspect_GraphiteImg",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "QInspect_Hardness",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "QInspect_MatrixImg",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "QInspect_Nodularity",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "QInspect_Pearlite",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "QInspect_Size",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "QInspect_Tensile",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "QInspect_Yeild",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "TappingTemp",
                table: "Kanbans");
        }
    }
}
