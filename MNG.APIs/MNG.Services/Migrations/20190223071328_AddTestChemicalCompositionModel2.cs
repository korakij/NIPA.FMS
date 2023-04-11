using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class AddTestChemicalCompositionModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chargings_Products_ProductId",
                table: "Chargings");

            migrationBuilder.DropIndex(
                name: "IX_Chargings_ProductId",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalActual_Al",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalActual_C",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalActual_CCE",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalActual_Cr",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalActual_Cu",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalActual_Mg",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalActual_Mn",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalActual_Mo",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalActual_Ni",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalActual_P",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalActual_S",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalActual_Si",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalActual_Sn",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalActual_Te",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalActual_TestDate",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalActual_Ti",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalActual_V",
                table: "Chargings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Chargings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalActual_Al",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalActual_C",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalActual_CCE",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalActual_Cr",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalActual_Cu",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalActual_Mg",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalActual_Mn",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalActual_Mo",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalActual_Ni",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalActual_P",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalActual_S",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalActual_Si",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalActual_Sn",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalActual_Te",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ChemicalActual_TestDate",
                table: "Chargings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "ChemicalActual_Ti",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalActual_V",
                table: "Chargings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chargings_ProductId",
                table: "Chargings",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chargings_Products_ProductId",
                table: "Chargings",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
