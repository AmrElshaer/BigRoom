using Microsoft.EntityFrameworkCore.Migrations;

namespace BigRoom.Data.Migrations
{
    public partial class userquies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Degree",
                table: "Userquizes",
                newName: "degree");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "235bab8a-ed9d-4911-95d0-52fbb186c274");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "4a638337-4a15-4208-a9c7-108d9a4a1f4e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "85b3979e-2509-420f-bfbb-5f50b7c8b67d");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "degree",
                table: "Userquizes",
                newName: "Degree");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b207bb68-290a-4083-a4c1-fb744ec7c79c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "654dd004-9573-4d4d-8d4c-0a60440b4041");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "725af54c-23c3-4332-8659-9af7b4fa7f89");
        }
    }
}
