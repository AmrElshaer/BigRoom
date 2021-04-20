using Microsoft.EntityFrameworkCore.Migrations;

namespace BigRoom.Repository.Migrations
{
    public partial class updateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Quizes_QuizeId",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_QuizeId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "QuizeId",
                table: "UserProfiles");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuizeId",
                table: "UserProfiles",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "7f661ce3-cc39-4b6c-8abf-1f1a48701330");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "78ceb571-406e-4c04-9a38-97746107dff7");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_QuizeId",
                table: "UserProfiles",
                column: "QuizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Quizes_QuizeId",
                table: "UserProfiles",
                column: "QuizeId",
                principalTable: "Quizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
