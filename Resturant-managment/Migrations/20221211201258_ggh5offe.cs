using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class ggh5offe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_PhotoTable_PhotoId",
                table: "Foods");

            migrationBuilder.AlterColumn<int>(
                name: "PhotoId",
                table: "Foods",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_PhotoTable_PhotoId",
                table: "Foods",
                column: "PhotoId",
                principalTable: "PhotoTable",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_PhotoTable_PhotoId",
                table: "Foods");

            migrationBuilder.AlterColumn<int>(
                name: "PhotoId",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_PhotoTable_PhotoId",
                table: "Foods",
                column: "PhotoId",
                principalTable: "PhotoTable",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
