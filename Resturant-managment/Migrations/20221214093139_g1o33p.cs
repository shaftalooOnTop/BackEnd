using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_managment.Migrations
{
    public partial class g1o33p : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_identityid",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EntranceMangments_Employees_employeeid",
                table: "EntranceMangments");

            migrationBuilder.AlterColumn<int>(
                name: "employeeid",
                table: "EntranceMangments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdentityId",
                table: "EntranceMangments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "identityid",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "earning",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "jobtype",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "position",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "start",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_identityid",
                table: "Employees",
                column: "identityid",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EntranceMangments_Employees_employeeid",
                table: "EntranceMangments",
                column: "employeeid",
                principalTable: "Employees",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_identityid",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EntranceMangments_Employees_employeeid",
                table: "EntranceMangments");

            migrationBuilder.DropColumn(
                name: "earning",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "jobtype",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "position",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "start",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "employeeid",
                table: "EntranceMangments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityId",
                table: "EntranceMangments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "identityid",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_identityid",
                table: "Employees",
                column: "identityid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntranceMangments_Employees_employeeid",
                table: "EntranceMangments",
                column: "employeeid",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
