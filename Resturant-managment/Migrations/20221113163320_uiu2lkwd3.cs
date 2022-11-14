using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class uiu2lkwd3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Restaurant_RestaurantId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ResturantId",
                table: "Tags");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "Tags",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Restaurant_RestaurantId",
                table: "Tags",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Restaurant_RestaurantId",
                table: "Tags");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "Tags",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ResturantId",
                table: "Tags",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Restaurant_RestaurantId",
                table: "Tags",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "id");
        }
    }
}
