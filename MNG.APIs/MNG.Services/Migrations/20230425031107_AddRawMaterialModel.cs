using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class AddRawMaterialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RawMaterials",
                columns: table => new
                {
                    MatCode = table.Column<string>(maxLength: 20, nullable: false),
                    PigFC = table.Column<double>(nullable: true),
                    PigFCD = table.Column<double>(nullable: true),
                    RS = table.Column<double>(nullable: true),
                    SS = table.Column<double>(nullable: true),
                    RemainedMetal = table.Column<double>(nullable: true),
                    Total = table.Column<double>(nullable: true),
                    C_FC = table.Column<double>(nullable: true),
                    C_FCD = table.Column<double>(nullable: true),
                    Fe_Si = table.Column<double>(nullable: true),
                    Fe_Mn = table.Column<double>(nullable: true),
                    HC_Cr = table.Column<double>(nullable: true),
                    Fe_Ni = table.Column<double>(nullable: true),
                    Fe_Mo = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterials", x => x.MatCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RawMaterials");
        }
    }
}
