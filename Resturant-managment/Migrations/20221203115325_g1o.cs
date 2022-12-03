using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class g1o : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrder_Orders_ordersid",
                table: "FoodOrder");

            migrationBuilder.RenameColumn(
                name: "ordersid",
                table: "FoodOrder",
                newName: "Ordersid");

            migrationBuilder.RenameIndex(
                name: "IX_FoodOrder_ordersid",
                table: "FoodOrder",
                newName: "IX_FoodOrder_Ordersid");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrder_Orders_Ordersid",
                table: "FoodOrder",
                column: "Ordersid",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrder_Orders_Ordersid",
                table: "FoodOrder");

            migrationBuilder.RenameColumn(
                name: "Ordersid",
                table: "FoodOrder",
                newName: "ordersid");

            migrationBuilder.RenameIndex(
                name: "IX_FoodOrder_Ordersid",
                table: "FoodOrder",
                newName: "IX_FoodOrder_ordersid");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrder_Orders_ordersid",
                table: "FoodOrder",
                column: "ordersid",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
