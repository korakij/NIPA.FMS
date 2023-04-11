using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class Update191 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChemicalStandard_AlMax",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_AlMin",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_CCEMax",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_CCEMin",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_CMax",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_CMin",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_CrMax",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_CrMin",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_CuMax",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_CuMin",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_MgMax",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_MgMin",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_MnMax",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_MnMin",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_MoMax",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_MoMin",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_NiMax",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_NiMin",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_PMax",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_PMin",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_SMax",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_SMin",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_SiMax",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_SiMin",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_SnMax",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_SnMin",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_TeMax",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_TeMin",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_TiMax",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_TiMin",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_VMax",
                table: "Chargings");

            migrationBuilder.DropColumn(
                name: "ChemicalStandard_VMin",
                table: "Chargings");

            migrationBuilder.RenameColumn(
                name: "ChemicalResult_V",
                table: "Chargings",
                newName: "ChemicalActual_V");

            migrationBuilder.RenameColumn(
                name: "ChemicalResult_Ti",
                table: "Chargings",
                newName: "ChemicalActual_Ti");

            migrationBuilder.RenameColumn(
                name: "ChemicalResult_TestDate",
                table: "Chargings",
                newName: "ChemicalActual_TestDate");

            migrationBuilder.RenameColumn(
                name: "ChemicalResult_Te",
                table: "Chargings",
                newName: "ChemicalActual_Te");

            migrationBuilder.RenameColumn(
                name: "ChemicalResult_Sn",
                table: "Chargings",
                newName: "ChemicalActual_Sn");

            migrationBuilder.RenameColumn(
                name: "ChemicalResult_Si",
                table: "Chargings",
                newName: "ChemicalActual_Si");

            migrationBuilder.RenameColumn(
                name: "ChemicalResult_S",
                table: "Chargings",
                newName: "ChemicalActual_S");

            migrationBuilder.RenameColumn(
                name: "ChemicalResult_P",
                table: "Chargings",
                newName: "ChemicalActual_P");

            migrationBuilder.RenameColumn(
                name: "ChemicalResult_Ni",
                table: "Chargings",
                newName: "ChemicalActual_Ni");

            migrationBuilder.RenameColumn(
                name: "ChemicalResult_Mo",
                table: "Chargings",
                newName: "ChemicalActual_Mo");

            migrationBuilder.RenameColumn(
                name: "ChemicalResult_Mn",
                table: "Chargings",
                newName: "ChemicalActual_Mn");

            migrationBuilder.RenameColumn(
                name: "ChemicalResult_Mg",
                table: "Chargings",
                newName: "ChemicalActual_Mg");

            migrationBuilder.RenameColumn(
                name: "ChemicalResult_Cu",
                table: "Chargings",
                newName: "ChemicalActual_Cu");

            migrationBuilder.RenameColumn(
                name: "ChemicalResult_Cr",
                table: "Chargings",
                newName: "ChemicalActual_Cr");

            migrationBuilder.RenameColumn(
                name: "ChemicalResult_CCE",
                table: "Chargings",
                newName: "ChemicalActual_CCE");

            migrationBuilder.RenameColumn(
                name: "ChemicalResult_C",
                table: "Chargings",
                newName: "ChemicalActual_C");

            migrationBuilder.RenameColumn(
                name: "ChemicalResult_Al",
                table: "Chargings",
                newName: "ChemicalActual_Al");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChemicalActual_V",
                table: "Chargings",
                newName: "ChemicalResult_V");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_Ti",
                table: "Chargings",
                newName: "ChemicalResult_Ti");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_TestDate",
                table: "Chargings",
                newName: "ChemicalResult_TestDate");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_Te",
                table: "Chargings",
                newName: "ChemicalResult_Te");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_Sn",
                table: "Chargings",
                newName: "ChemicalResult_Sn");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_Si",
                table: "Chargings",
                newName: "ChemicalResult_Si");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_S",
                table: "Chargings",
                newName: "ChemicalResult_S");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_P",
                table: "Chargings",
                newName: "ChemicalResult_P");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_Ni",
                table: "Chargings",
                newName: "ChemicalResult_Ni");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_Mo",
                table: "Chargings",
                newName: "ChemicalResult_Mo");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_Mn",
                table: "Chargings",
                newName: "ChemicalResult_Mn");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_Mg",
                table: "Chargings",
                newName: "ChemicalResult_Mg");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_Cu",
                table: "Chargings",
                newName: "ChemicalResult_Cu");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_Cr",
                table: "Chargings",
                newName: "ChemicalResult_Cr");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_CCE",
                table: "Chargings",
                newName: "ChemicalResult_CCE");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_C",
                table: "Chargings",
                newName: "ChemicalResult_C");

            migrationBuilder.RenameColumn(
                name: "ChemicalActual_Al",
                table: "Chargings",
                newName: "ChemicalResult_Al");

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_AlMax",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_AlMin",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_CCEMax",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_CCEMin",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_CMax",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_CMin",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_CrMax",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_CrMin",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_CuMax",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_CuMin",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_MgMax",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_MgMin",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_MnMax",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_MnMin",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_MoMax",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_MoMin",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_NiMax",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_NiMin",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_PMax",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_PMin",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_SMax",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_SMin",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_SiMax",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_SiMin",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_SnMax",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_SnMin",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_TeMax",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_TeMin",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_TiMax",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_TiMin",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_VMax",
                table: "Chargings",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChemicalStandard_VMin",
                table: "Chargings",
                nullable: true);
        }
    }
}
