using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class uiu2lkwdjfkjdkjslkjnfsdgnlk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Comments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RestaurantId",
                table: "Comments",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Restaurant_RestaurantId",
                table: "Comments",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Restaurant_RestaurantId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RestaurantId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Comments");
        }
    }
}
