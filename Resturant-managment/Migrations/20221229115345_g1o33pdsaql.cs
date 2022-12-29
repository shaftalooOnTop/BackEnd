using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class g1o33pdsaql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_AspNetUsers_RestaurantIdentityId",
                table: "Restaurant");

            migrationBuilder.AddColumn<double>(
                name: "rank",
                table: "RestaurantTables",
                type: "float",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantIdentityId",
                table: "Restaurant",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "theme",
                table: "ReserveTables",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "rate",
                table: "ReserveTables",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "landingpageid",
                table: "Photo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LandingPages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandingPages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "themeOfTables",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    theme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    restaurantid = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_themeOfTables", x => x.id);
                    table.ForeignKey(
                        name: "FK_themeOfTables_Restaurant_restaurantid",
                        column: x => x.restaurantid,
                        principalTable: "Restaurant",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photo_landingpageid",
                table: "Photo",
                column: "landingpageid");

            migrationBuilder.CreateIndex(
                name: "IX_themeOfTables_restaurantid",
                table: "themeOfTables",
                column: "restaurantid");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_LandingPages_landingpageid",
                table: "Photo",
                column: "landingpageid",
                principalTable: "LandingPages",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_AspNetUsers_RestaurantIdentityId",
                table: "Restaurant",
                column: "RestaurantIdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_LandingPages_landingpageid",
                table: "Photo");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_AspNetUsers_RestaurantIdentityId",
                table: "Restaurant");

            migrationBuilder.DropTable(
                name: "LandingPages");

            migrationBuilder.DropTable(
                name: "themeOfTables");

            migrationBuilder.DropIndex(
                name: "IX_Photo_landingpageid",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "rank",
                table: "RestaurantTables");

            migrationBuilder.DropColumn(
                name: "rate",
                table: "ReserveTables");

            migrationBuilder.DropColumn(
                name: "landingpageid",
                table: "Photo");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantIdentityId",
                table: "Restaurant",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "theme",
                table: "ReserveTables",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_AspNetUsers_RestaurantIdentityId",
                table: "Restaurant",
                column: "RestaurantIdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
