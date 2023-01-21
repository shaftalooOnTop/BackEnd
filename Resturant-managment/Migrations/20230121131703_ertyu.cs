using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class ertyu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_AspNetUsers_RestaurantIdentityId",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_RestaurantIdentityId",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RestaurantId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantIdentityId",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RestaurantId",
                table: "AspNetUsers",
                column: "RestaurantId",
                unique: true,
                filter: "[RestaurantId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RestaurantId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantIdentityId",
                table: "Restaurant",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_RestaurantIdentityId",
                table: "Restaurant",
                column: "RestaurantIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RestaurantId",
                table: "AspNetUsers",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_AspNetUsers_RestaurantIdentityId",
                table: "Restaurant",
                column: "RestaurantIdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
