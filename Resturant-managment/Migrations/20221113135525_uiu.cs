using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class uiu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Cities_Cityid",
                table: "Restaurant");

            migrationBuilder.AlterColumn<int>(
                name: "Cityid",
                table: "Restaurant",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Cities_Cityid",
                table: "Restaurant",
                column: "Cityid",
                principalTable: "Cities",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Cities_Cityid",
                table: "Restaurant");

            migrationBuilder.AlterColumn<int>(
                name: "Cityid",
                table: "Restaurant",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

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
