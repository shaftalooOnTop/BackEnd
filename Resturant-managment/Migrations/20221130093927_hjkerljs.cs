using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class hjkerljs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restaurant_Restaurantid",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Restaurantid",
                table: "Orders",
                newName: "RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_Restaurantid",
                table: "Orders",
                newName: "IX_Orders_RestaurantId");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "stat",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restaurant_RestaurantId",
                table: "Orders",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restaurant_RestaurantId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "stat",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "Orders",
                newName: "Restaurantid");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_RestaurantId",
                table: "Orders",
                newName: "IX_Orders_Restaurantid");

            migrationBuilder.AlterColumn<int>(
                name: "Restaurantid",
                table: "Orders",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restaurant_Restaurantid",
                table: "Orders",
                column: "Restaurantid",
                principalTable: "Restaurant",
                principalColumn: "id");
        }
    }
}
