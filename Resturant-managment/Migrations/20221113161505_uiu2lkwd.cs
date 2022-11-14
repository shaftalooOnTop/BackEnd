using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class uiu2lkwd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Restaurant_Restaurantid",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "Restaurantid",
                table: "Tags",
                newName: "RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_Restaurantid",
                table: "Tags",
                newName: "IX_Tags_RestaurantId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Restaurant",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "backgroundImg",
                table: "Restaurant",
                newName: "BackgroundImg");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Restaurant_RestaurantId",
                table: "Tags",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Restaurant_RestaurantId",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "Tags",
                newName: "Restaurantid");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_RestaurantId",
                table: "Tags",
                newName: "IX_Tags_Restaurantid");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Restaurant",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "BackgroundImg",
                table: "Restaurant",
                newName: "backgroundImg");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Restaurant_Restaurantid",
                table: "Tags",
                column: "Restaurantid",
                principalTable: "Restaurant",
                principalColumn: "id");
        }
    }
}
