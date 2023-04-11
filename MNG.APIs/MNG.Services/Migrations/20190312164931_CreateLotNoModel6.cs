using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class CreateLotNoModel6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LotNos_Furnace_FurnaceCode",
                table: "LotNos");

            migrationBuilder.DropTable(
                name: "Furnace");

            migrationBuilder.DropIndex(
                name: "IX_LotNos_FurnaceCode",
                table: "LotNos");

            migrationBuilder.DropColumn(
                name: "FurnaceCode",
                table: "LotNos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FurnaceCode",
                table: "LotNos",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Furnace",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Power = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnace", x => x.Code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LotNos_FurnaceCode",
                table: "LotNos",
                column: "FurnaceCode",
                unique: true,
                filter: "[FurnaceCode] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_LotNos_Furnace_FurnaceCode",
                table: "LotNos",
                column: "FurnaceCode",
                principalTable: "Furnace",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
