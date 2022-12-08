using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Foods");

            migrationBuilder.AddColumn<int>(
                name: "Photoid",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_Photoid",
                table: "Foods",
                column: "Photoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Photos_Photoid",
                table: "Foods",
                column: "Photoid",
                principalTable: "Photos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Photos_Photoid",
                table: "Foods");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Foods_Photoid",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "Photoid",
                table: "Foods");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
