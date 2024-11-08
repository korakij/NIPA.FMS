using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class EditDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tensile",
                table: "MaterialSpecifications",
                newName: "TensileMin");

            migrationBuilder.AddColumn<float>(
                name: "QInspect_SizeTensile",
                table: "Pourings",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "SizeTensileMax",
                table: "MaterialSpecifications",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SizeTensileMin",
                table: "MaterialSpecifications",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TensileMax",
                table: "MaterialSpecifications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QInspect_SizeTensile",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "SizeTensileMax",
                table: "MaterialSpecifications");

            migrationBuilder.DropColumn(
                name: "SizeTensileMin",
                table: "MaterialSpecifications");

            migrationBuilder.DropColumn(
                name: "TensileMax",
                table: "MaterialSpecifications");

            migrationBuilder.RenameColumn(
                name: "TensileMin",
                table: "MaterialSpecifications",
                newName: "Tensile");
        }
    }
}
