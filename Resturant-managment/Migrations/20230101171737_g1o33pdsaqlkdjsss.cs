using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class g1o33pdsaqlkdjsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_LandingPages_landingpageid",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_landingpageid",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "landingpageid",
                table: "Photo");

            migrationBuilder.RenameColumn(
                name: "Avg",
                table: "Restaurant",
                newName: "rate");

            migrationBuilder.AddColumn<int>(
                name: "photoid",
                table: "LandingPages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "LandingPages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "title",
                table: "LandingPages");

            migrationBuilder.RenameColumn(
                name: "rate",
                table: "Restaurant",
                newName: "Avg");

            migrationBuilder.AddColumn<int>(
                name: "landingpageid",
                table: "Photo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_landingpageid",
                table: "Photo",
                column: "landingpageid");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_LandingPages_landingpageid",
                table: "Photo",
                column: "landingpageid",
                principalTable: "LandingPages",
                principalColumn: "id");
        }
    }
}
