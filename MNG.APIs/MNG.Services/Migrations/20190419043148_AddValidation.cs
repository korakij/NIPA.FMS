using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class AddValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_Al",
                table: "TestChemicalCompositions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_C",
                table: "TestChemicalCompositions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_CCE",
                table: "TestChemicalCompositions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_Cr",
                table: "TestChemicalCompositions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_Cu",
                table: "TestChemicalCompositions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_Mg",
                table: "TestChemicalCompositions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_Mn",
                table: "TestChemicalCompositions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_Mo",
                table: "TestChemicalCompositions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_Ni",
                table: "TestChemicalCompositions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_P",
                table: "TestChemicalCompositions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_S",
                table: "TestChemicalCompositions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_Si",
                table: "TestChemicalCompositions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_Sn",
                table: "TestChemicalCompositions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_Te",
                table: "TestChemicalCompositions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_Ti",
                table: "TestChemicalCompositions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation_IsOk_V",
                table: "TestChemicalCompositions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Validation_IsOk_Al",
                table: "TestChemicalCompositions");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_C",
                table: "TestChemicalCompositions");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_CCE",
                table: "TestChemicalCompositions");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_Cr",
                table: "TestChemicalCompositions");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_Cu",
                table: "TestChemicalCompositions");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_Mg",
                table: "TestChemicalCompositions");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_Mn",
                table: "TestChemicalCompositions");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_Mo",
                table: "TestChemicalCompositions");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_Ni",
                table: "TestChemicalCompositions");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_P",
                table: "TestChemicalCompositions");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_S",
                table: "TestChemicalCompositions");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_Si",
                table: "TestChemicalCompositions");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_Sn",
                table: "TestChemicalCompositions");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_Te",
                table: "TestChemicalCompositions");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_Ti",
                table: "TestChemicalCompositions");

            migrationBuilder.DropColumn(
                name: "Validation_IsOk_V",
                table: "TestChemicalCompositions");
        }
    }
}
