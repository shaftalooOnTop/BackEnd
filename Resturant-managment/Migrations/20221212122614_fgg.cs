using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class fgg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_PhotoTable_PhotoId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_PhotoId",
                table: "Foods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhotoTable",
                table: "PhotoTable");

            migrationBuilder.RenameTable(
                name: "PhotoTable",
                newName: "Photo");

            migrationBuilder.AddColumn<int>(
                name: "theme",
                table: "ReserveTables",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photo",
                table: "Photo",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    restaurantid = table.Column<int>(type: "int", nullable: false),
                    identityid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_identityid",
                        column: x => x.identityid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Restaurant_restaurantid",
                        column: x => x.restaurantid,
                        principalTable: "Restaurant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntranceMangments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    enter = table.Column<DateTime>(type: "datetime2", nullable: true),
                    leave = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdentityId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeid = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntranceMangments", x => x.id);
                    table.ForeignKey(
                        name: "FK_EntranceMangments_Employees_employeeid",
                        column: x => x.employeeid,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_PhotoId",
                table: "Foods",
                column: "PhotoId",
                unique: true,
                filter: "[PhotoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_identityid",
                table: "Employees",
                column: "identityid");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_restaurantid",
                table: "Employees",
                column: "restaurantid");

            migrationBuilder.CreateIndex(
                name: "IX_EntranceMangments_employeeid",
                table: "EntranceMangments",
                column: "employeeid");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Photo_PhotoId",
                table: "Foods",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Photo_PhotoId",
                table: "Foods");

            migrationBuilder.DropTable(
                name: "EntranceMangments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Foods_PhotoId",
                table: "Foods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photo",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "theme",
                table: "ReserveTables");

            migrationBuilder.RenameTable(
                name: "Photo",
                newName: "PhotoTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhotoTable",
                table: "PhotoTable",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_PhotoId",
                table: "Foods",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_PhotoTable_PhotoId",
                table: "Foods",
                column: "PhotoId",
                principalTable: "PhotoTable",
                principalColumn: "id");
        }
    }
}
