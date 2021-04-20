using Microsoft.EntityFrameworkCore.Migrations;

namespace BigRoom.Repository.Migrations
{
    public partial class updateModelQuize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: "5a8336d7-3d6c-4815-9de0-16272a684aa3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "81be7249-d490-4fb7-8198-16cb2404e2e6");

            migrationBuilder.AddForeignKey(
                name: "FK_Degrees_Quizes_QuizeId",
                table: "Degrees",
                column: "QuizeId",
                principalTable: "Quizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: "8b5cf79a-bf37-4ad9-b0ed-e5c01848f51a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "5abd6b95-1c90-44c3-9a2f-6ab09c50e135");

            migrationBuilder.AddForeignKey(
                name: "FK_Degrees_Quizes_QuizeId",
                table: "Degrees",
                column: "QuizeId",
                principalTable: "Quizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
