using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class init23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Menus_Menuid",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Categories_Categoryid",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Restaurant_Restaurantid",
                table: "Menus");

            migrationBuilder.AlterColumn<int>(
                name: "Restaurantid",
                table: "Menus",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Categoryid",
                table: "Foods",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Categories_Categoryid",
                table: "Foods",
                column: "Categoryid",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Restaurant_Restaurantid",
                table: "Menus",
                column: "Restaurantid",
                principalTable: "Restaurant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Menus_Menuid",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Categories_Categoryid",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Restaurant_Restaurantid",
                table: "Menus");

            migrationBuilder.AlterColumn<int>(
                name: "Restaurantid",
                table: "Menus",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Categoryid",
                table: "Foods",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Categories_Categoryid",
                table: "Foods",
                column: "Categoryid",
                principalTable: "Categories",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Restaurant_Restaurantid",
                table: "Menus",
                column: "Restaurantid",
                principalTable: "Restaurant",
                principalColumn: "id");
        }
    }
}
