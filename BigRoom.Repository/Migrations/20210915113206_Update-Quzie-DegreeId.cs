using Microsoft.EntityFrameworkCore.Migrations;

namespace BigRoom.Repository.Migrations
{
    public partial class UpdateQuzieDegreeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Degrees_Quizes_QuizeId",
                table: "Degrees");

            migrationBuilder.AlterColumn<int>(
                name: "QuizeId",
                table: "Degrees",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "1b50f33f-41c7-42db-826f-d11c0800fb40");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "b4f569b3-3581-4b39-bff5-010ae8f619c5");

            migrationBuilder.AddForeignKey(
                name: "FK_Degrees_Quizes_QuizeId",
                table: "Degrees",
                column: "QuizeId",
                principalTable: "Quizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Degrees_Quizes_QuizeId",
                table: "Degrees");

            migrationBuilder.AlterColumn<int>(
                name: "QuizeId",
                table: "Degrees",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "2655809d-f389-4582-8ef8-ce6608f1dfd3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "8a202024-3c78-4163-b198-a90a03306e6e");

            migrationBuilder.AddForeignKey(
                name: "FK_Degrees_Quizes_QuizeId",
                table: "Degrees",
                column: "QuizeId",
                principalTable: "Quizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
