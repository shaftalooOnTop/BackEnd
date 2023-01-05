using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class g1o33pdsaqlk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_themeOfTables_Restaurant_restaurantid",
                table: "themeOfTables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_themeOfTables",
                table: "themeOfTables");

            migrationBuilder.RenameTable(
                name: "themeOfTables",
                newName: "ThemeOfTables");

            migrationBuilder.RenameIndex(
                name: "IX_themeOfTables_restaurantid",
                table: "ThemeOfTables",
                newName: "IX_ThemeOfTables_restaurantid");

            migrationBuilder.AddColumn<DateTime>(
                name: "delivary",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThemeOfTables",
                table: "ThemeOfTables",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Polls",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    score1 = table.Column<int>(type: "int", nullable: false),
                    score2 = table.Column<int>(type: "int", nullable: false),
                    score3 = table.Column<int>(type: "int", nullable: false),
                    score4 = table.Column<int>(type: "int", nullable: false),
                    score5 = table.Column<int>(type: "int", nullable: false),
                    score6 = table.Column<int>(type: "int", nullable: false),
                    score7 = table.Column<int>(type: "int", nullable: false),
                    recommendation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    restaurantid = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polls", x => x.id);
                    table.ForeignKey(
                        name: "FK_Polls_Restaurant_restaurantid",
                        column: x => x.restaurantid,
                        principalTable: "Restaurant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Polls_restaurantid",
                table: "Polls",
                column: "restaurantid");

            migrationBuilder.AddForeignKey(
                name: "FK_ThemeOfTables_Restaurant_restaurantid",
                table: "ThemeOfTables",
                column: "restaurantid",
                principalTable: "Restaurant",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThemeOfTables_Restaurant_restaurantid",
                table: "ThemeOfTables");

            migrationBuilder.DropTable(
                name: "Polls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThemeOfTables",
                table: "ThemeOfTables");

            migrationBuilder.DropColumn(
                name: "delivary",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "ThemeOfTables",
                newName: "themeOfTables");

            migrationBuilder.RenameIndex(
                name: "IX_ThemeOfTables_restaurantid",
                table: "themeOfTables",
                newName: "IX_themeOfTables_restaurantid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_themeOfTables",
                table: "themeOfTables",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_themeOfTables_Restaurant_restaurantid",
                table: "themeOfTables",
                column: "restaurantid",
                principalTable: "Restaurant",
                principalColumn: "id");
        }
    }
}
