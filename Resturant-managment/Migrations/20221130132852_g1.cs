using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class g1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cities_IdentityId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restaurant_Restaurantid",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UserModel_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTables_UserModel_UserModelid",
                table: "ReserveTables");

            migrationBuilder.DropTable(
                name: "UserModel");

            migrationBuilder.DropIndex(
                name: "IX_ReserveTables_UserModelid",
                table: "ReserveTables");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Restaurantid",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserModelid",
                table: "ReserveTables");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "Restaurantid",
                table: "Orders",
                newName: "restaurantId");

            migrationBuilder.RenameColumn(
                name: "IdentityId",
                table: "AspNetUsers",
                newName: "cityid");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_IdentityId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_cityid");

            migrationBuilder.AlterColumn<int>(
                name: "restaurantId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "restuarantId",
                table: "Orders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_restuarantId",
                table: "Orders",
                column: "restuarantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cities_cityid",
                table: "AspNetUsers",
                column: "cityid",
                principalTable: "Cities",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restaurant_restuarantId",
                table: "Orders",
                column: "restuarantId",
                principalTable: "Restaurant",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cities_cityid",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restaurant_restuarantId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_restuarantId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "restuarantId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "restaurantId",
                table: "Orders",
                newName: "Restaurantid");

            migrationBuilder.RenameColumn(
                name: "cityid",
                table: "AspNetUsers",
                newName: "IdentityId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_cityid",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_IdentityId");

            migrationBuilder.AddColumn<int>(
                name: "UserModelid",
                table: "ReserveTables",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Restaurantid",
                table: "Orders",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdentityId",
                table: "Cities",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTables_UserModelid",
                table: "ReserveTables",
                column: "UserModelid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Restaurantid",
                table: "Orders",
                column: "Restaurantid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cities_IdentityId",
                table: "AspNetUsers",
                column: "IdentityId",
                principalTable: "Cities",
                principalColumn: "id");

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
                name: "FK_ReserveTables_UserModel_UserModelid",
                table: "ReserveTables",
                column: "UserModelid",
                principalTable: "UserModel",
                principalColumn: "id");
        }
    }
}
