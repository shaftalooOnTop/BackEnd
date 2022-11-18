using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class _1ll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Cities_Cityid",
                table: "Restaurant");

            migrationBuilder.RenameColumn(
                name: "Cityid",
                table: "Restaurant",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurant_Cityid",
                table: "Restaurant",
                newName: "IX_Restaurant_CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Cities_CityId",
                table: "Restaurant",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Cities_CityId",
                table: "Restaurant");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Restaurant",
                newName: "Cityid");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurant_CityId",
                table: "Restaurant",
                newName: "IX_Restaurant_Cityid");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Cities_Cityid",
                table: "Restaurant",
                column: "Cityid",
                principalTable: "Cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
