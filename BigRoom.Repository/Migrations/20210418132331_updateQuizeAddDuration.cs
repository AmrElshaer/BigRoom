using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BigRoom.Repository.Migrations
{
    public partial class updateQuizeAddDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Quizes");

            migrationBuilder.AddColumn<int>(
                name: "Hour",
                table: "Quizes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Minute",
                table: "Quizes",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "504ef464-3492-4aa6-bd65-412227e53c5f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "4179d8d3-fbb6-4cb1-afaf-07e2c1eeca95");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hour",
                table: "Quizes");

            migrationBuilder.DropColumn(
                name: "Minute",
                table: "Quizes");

            migrationBuilder.AddColumn<DateTime>(
                name: "Duration",
                table: "Quizes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "079021f6-3d28-4e90-a1c9-ca3f9e4a4d99");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "654e697c-dce0-4b2d-bb41-da8521d367f2");
        }
    }
}
