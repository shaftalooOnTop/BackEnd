using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class gggg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Orders_Orderid",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restaurant_Restaurantid",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Payment_OrderId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Foods_Orderid",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "Orderid",
                table: "Foods");

            migrationBuilder.AddColumn<int>(
                name: "ReserveTableId",
                table: "Payment",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Restaurantid",
                table: "Orders",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "RestaurantIdentityId",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FoodOrder",
                columns: table => new
                {
                    Foodsid = table.Column<int>(type: "INTEGER", nullable: false),
                    ordersid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodOrder", x => new { x.Foodsid, x.ordersid });
                    table.ForeignKey(
                        name: "FK_FoodOrder_Foods_Foodsid",
                        column: x => x.Foodsid,
                        principalTable: "Foods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodOrder_Orders_ordersid",
                        column: x => x.ordersid,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodOrders",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodOrders", x => new { x.FoodId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_FoodOrders_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resrvetimes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReserveTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resrvetimes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ReserveTables",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExpireHours = table.Column<int>(type: "INTEGER", nullable: false),
                    RestaurantIdentityId = table.Column<string>(type: "TEXT", nullable: false),
                    TableId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReserveTimeId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserModelid = table.Column<int>(type: "INTEGER", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveTables", x => x.id);
                    table.ForeignKey(
                        name: "FK_ReserveTables_AspNetUsers_RestaurantIdentityId",
                        column: x => x.RestaurantIdentityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReserveTables_Resrvetimes_ReserveTimeId",
                        column: x => x.ReserveTimeId,
                        principalTable: "Resrvetimes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReserveTables_RestaurantTables_TableId",
                        column: x => x.TableId,
                        principalTable: "RestaurantTables",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReserveTables_UserModel_UserModelid",
                        column: x => x.UserModelid,
                        principalTable: "UserModel",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OrderId",
                table: "Payment",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ReserveTableId",
                table: "Payment",
                column: "ReserveTableId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RestaurantIdentityId",
                table: "Orders",
                column: "RestaurantIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrder_ordersid",
                table: "FoodOrder",
                column: "ordersid");

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrders_OrderId",
                table: "FoodOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTables_ReserveTimeId",
                table: "ReserveTables",
                column: "ReserveTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTables_RestaurantIdentityId",
                table: "ReserveTables",
                column: "RestaurantIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTables_TableId",
                table: "ReserveTables",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTables_UserModelid",
                table: "ReserveTables",
                column: "UserModelid");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_RestaurantIdentityId",
                table: "Orders",
                column: "RestaurantIdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restaurant_Restaurantid",
                table: "Orders",
                column: "Restaurantid",
                principalTable: "Restaurant",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UserModel_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "UserModel",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_ReserveTables_ReserveTableId",
                table: "Payment",
                column: "ReserveTableId",
                principalTable: "ReserveTables",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_RestaurantIdentityId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restaurant_Restaurantid",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UserModel_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_ReserveTables_ReserveTableId",
                table: "Payment");

            migrationBuilder.DropTable(
                name: "FoodOrder");

            migrationBuilder.DropTable(
                name: "FoodOrders");

            migrationBuilder.DropTable(
                name: "ReserveTables");

            migrationBuilder.DropTable(
                name: "Resrvetimes");

            migrationBuilder.DropTable(
                name: "UserModel");

            migrationBuilder.DropIndex(
                name: "IX_Payment_OrderId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_ReserveTableId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Orders_RestaurantIdentityId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReserveTableId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "RestaurantIdentityId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "Restaurantid",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Orderid",
                table: "Foods",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OrderId",
                table: "Payment",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_Orderid",
                table: "Foods",
                column: "Orderid");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Orders_Orderid",
                table: "Foods",
                column: "Orderid",
                principalTable: "Orders",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restaurant_Restaurantid",
                table: "Orders",
                column: "Restaurantid",
                principalTable: "Restaurant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
