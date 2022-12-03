using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class g1o33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrders_Foods_FoodId",
                table: "FoodOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrders_Orders_OrderId",
                table: "FoodOrders");

            migrationBuilder.DropTable(
                name: "FoodOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodOrders",
                table: "FoodOrders");

            migrationBuilder.DropIndex(
                name: "IX_FoodOrders_OrderId",
                table: "FoodOrders");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "FoodOrders");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "FoodOrders");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "FoodOrders",
                newName: "Ordersid");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "FoodOrders",
                newName: "Foodsid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodOrders",
                table: "FoodOrders",
                columns: new[] { "Foodsid", "Ordersid" });

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrders_Ordersid",
                table: "FoodOrders",
                column: "Ordersid");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrders_Foods_Foodsid",
                table: "FoodOrders",
                column: "Foodsid",
                principalTable: "Foods",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrders_Orders_Ordersid",
                table: "FoodOrders",
                column: "Ordersid",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrders_Foods_Foodsid",
                table: "FoodOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrders_Orders_Ordersid",
                table: "FoodOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodOrders",
                table: "FoodOrders");

            migrationBuilder.DropIndex(
                name: "IX_FoodOrders_Ordersid",
                table: "FoodOrders");

            migrationBuilder.RenameColumn(
                name: "Ordersid",
                table: "FoodOrders",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Foodsid",
                table: "FoodOrders",
                newName: "OrderId");

            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "FoodOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "FoodOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodOrders",
                table: "FoodOrders",
                columns: new[] { "FoodId", "OrderId" });

            migrationBuilder.CreateTable(
                name: "FoodOrder",
                columns: table => new
                {
                    Foodsid = table.Column<int>(type: "int", nullable: false),
                    Ordersid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodOrder", x => new { x.Foodsid, x.Ordersid });
                    table.ForeignKey(
                        name: "FK_FoodOrder_Foods_Foodsid",
                        column: x => x.Foodsid,
                        principalTable: "Foods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodOrder_Orders_Ordersid",
                        column: x => x.Ordersid,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrders_OrderId",
                table: "FoodOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrder_Ordersid",
                table: "FoodOrder",
                column: "Ordersid");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrders_Foods_FoodId",
                table: "FoodOrders",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrders_Orders_OrderId",
                table: "FoodOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
