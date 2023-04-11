using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MNG.Services.Migrations
{
    public partial class UpdatePouringModel01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pouring_Kanbans_KanbanCode",
                table: "Pouring");

            migrationBuilder.DropForeignKey(
                name: "FK_Pouring_Molding_MoldingCode",
                table: "Pouring");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pouring",
                table: "Pouring");

            migrationBuilder.RenameTable(
                name: "Pouring",
                newName: "Pourings");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Pourings",
                newName: "LastMoldTime");

            migrationBuilder.RenameIndex(
                name: "IX_Pouring_MoldingCode",
                table: "Pourings",
                newName: "IX_Pourings_MoldingCode");

            migrationBuilder.RenameIndex(
                name: "IX_Pouring_KanbanCode",
                table: "Pourings",
                newName: "IX_Pourings_KanbanCode");

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstMoldTime",
                table: "Pourings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "Pourings",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "Pourings",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pourings",
                table: "Pourings",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Pourings_ProductId1",
                table: "Pourings",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pourings_Kanbans_KanbanCode",
                table: "Pourings",
                column: "KanbanCode",
                principalTable: "Kanbans",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pourings_Molding_MoldingCode",
                table: "Pourings",
                column: "MoldingCode",
                principalTable: "Molding",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pourings_Products_ProductId1",
                table: "Pourings",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pourings_Kanbans_KanbanCode",
                table: "Pourings");

            migrationBuilder.DropForeignKey(
                name: "FK_Pourings_Molding_MoldingCode",
                table: "Pourings");

            migrationBuilder.DropForeignKey(
                name: "FK_Pourings_Products_ProductId1",
                table: "Pourings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pourings",
                table: "Pourings");

            migrationBuilder.DropIndex(
                name: "IX_Pourings_ProductId1",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "FirstMoldTime",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Pourings");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Pourings");

            migrationBuilder.RenameTable(
                name: "Pourings",
                newName: "Pouring");

            migrationBuilder.RenameColumn(
                name: "LastMoldTime",
                table: "Pouring",
                newName: "Time");

            migrationBuilder.RenameIndex(
                name: "IX_Pourings_MoldingCode",
                table: "Pouring",
                newName: "IX_Pouring_MoldingCode");

            migrationBuilder.RenameIndex(
                name: "IX_Pourings_KanbanCode",
                table: "Pouring",
                newName: "IX_Pouring_KanbanCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pouring",
                table: "Pouring",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Pouring_Kanbans_KanbanCode",
                table: "Pouring",
                column: "KanbanCode",
                principalTable: "Kanbans",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pouring_Molding_MoldingCode",
                table: "Pouring",
                column: "MoldingCode",
                principalTable: "Molding",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
