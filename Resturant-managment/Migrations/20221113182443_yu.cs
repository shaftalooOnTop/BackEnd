using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class yu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Menus_Menuid",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "Menuid",
                table: "Categories",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_Menuid",
                table: "Categories",
                newName: "IX_Categories_MenuId");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Categories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Menus_MenuId",
                table: "Categories",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Menus_MenuId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Categories",
                newName: "Menuid");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_MenuId",
                table: "Categories",
                newName: "IX_Categories_Menuid");

            migrationBuilder.AlterColumn<int>(
                name: "Menuid",
                table: "Categories",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Menus_Menuid",
                table: "Categories",
                column: "Menuid",
                principalTable: "Menus",
                principalColumn: "id");
        }
    }
}
