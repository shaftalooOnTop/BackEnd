using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class g2111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "RestaurantTables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "primium_ex",
                table: "Restaurant",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentType",
                table: "Payments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentState",
                table: "Payments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Primiums",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    expiretime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    restaurantid = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Primiums", x => x.id);
                    table.ForeignKey(
                        name: "FK_Primiums_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Primiums_Restaurant_restaurantid",
                        column: x => x.restaurantid,
                        principalTable: "Restaurant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Primiums_PaymentId",
                table: "Primiums",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Primiums_restaurantid",
                table: "Primiums",
                column: "restaurantid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Primiums");

            migrationBuilder.DropColumn(
                name: "img",
                table: "RestaurantTables");

            migrationBuilder.DropColumn(
                name: "primium_ex",
                table: "Restaurant");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentType",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentState",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
