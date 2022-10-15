using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class init2334 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Menus_Menuid",
                table: "Categories");

            migrationBuilder.AlterColumn<int>(
                name: "Menuid",
                table: "Categories",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Menus_Menuid",
                table: "Categories",
                column: "Menuid",
                principalTable: "Menus",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Menus_Menuid",
                table: "Categories");

            migrationBuilder.AlterColumn<int>(
                name: "Menuid",
                table: "Categories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Menus_Menuid",
                table: "Categories",
                column: "Menuid",
                principalTable: "Menus",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
