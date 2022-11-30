using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class g144 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Cities_CityId",
                table: "Restaurant");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Restaurant",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Cities_CityId",
                table: "Restaurant",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Cities_CityId",
                table: "Restaurant");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Restaurant",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Cities_CityId",
                table: "Restaurant",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
