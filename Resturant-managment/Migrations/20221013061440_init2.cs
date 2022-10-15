using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Restaurantid = table.Column<int>(type: "INTEGER", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.id);
                    table.ForeignKey(
                        name: "FK_Menus_Restaurant_Restaurantid",
                        column: x => x.Restaurantid,
                        principalTable: "Restaurant",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: true),
                    Menuid = table.Column<int>(type: "INTEGER", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                    table.ForeignKey(
                        name: "FK_Categories_Menus_Menuid",
                        column: x => x.Menuid,
                        principalTable: "Menus",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Categoryid = table.Column<int>(type: "INTEGER", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.id);
                    table.ForeignKey(
                        name: "FK_Foods_Categories_Categoryid",
                        column: x => x.Categoryid,
                        principalTable: "Categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Menuid",
                table: "Categories",
                column: "Menuid");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_Categoryid",
                table: "Foods",
                column: "Categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_Restaurantid",
                table: "Menus",
                column: "Restaurantid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Restaurant");
        }
    }
}
