using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class g211 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LandingPages_Photo_photoid",
                table: "LandingPages");

            migrationBuilder.DropIndex(
                name: "IX_LandingPages_photoid",
                table: "LandingPages");

            migrationBuilder.DropColumn(
                name: "photoid",
                table: "LandingPages");

            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "LandingPages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img",
                table: "LandingPages");

            migrationBuilder.AddColumn<int>(
                name: "photoid",
                table: "LandingPages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LandingPages_photoid",
                table: "LandingPages",
                column: "photoid");

            migrationBuilder.AddForeignKey(
                name: "FK_LandingPages_Photo_photoid",
                table: "LandingPages",
                column: "photoid",
                principalTable: "Photo",
                principalColumn: "id");
        }
    }
}
