using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class df53456 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_RestaurantUserId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RestaurantUserId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RestaurantUserId1",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantUserId",
                table: "Comments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RestaurantUserId",
                table: "Comments",
                column: "RestaurantUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_RestaurantUserId",
                table: "Comments",
                column: "RestaurantUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_RestaurantUserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RestaurantUserId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantUserId",
                table: "Comments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RestaurantUserId1",
                table: "Comments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RestaurantUserId1",
                table: "Comments",
                column: "RestaurantUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_RestaurantUserId1",
                table: "Comments",
                column: "RestaurantUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
