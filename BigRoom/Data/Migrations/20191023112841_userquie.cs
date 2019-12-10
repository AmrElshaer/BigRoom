using Microsoft.EntityFrameworkCore.Migrations;

namespace BigRoom.Data.Migrations
{
    public partial class userquie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Userquizes_Quize_quizeid1",
                table: "Userquizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Userquizes_AspNetUsers_userid",
                table: "Userquizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Userquizes",
                table: "Userquizes");

            migrationBuilder.RenameTable(
                name: "Userquizes",
                newName: "UserQuize");

            migrationBuilder.RenameIndex(
                name: "IX_Userquizes_userid",
                table: "UserQuize",
                newName: "IX_UserQuize_userid");

            migrationBuilder.RenameIndex(
                name: "IX_Userquizes_quizeid1",
                table: "UserQuize",
                newName: "IX_UserQuize_quizeid1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserQuize",
                table: "UserQuize",
                columns: new[] { "quizeid", "userid" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "e8fc45b2-9731-4947-a4d7-d8213654ae01");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "2803f9a4-5db6-4f66-9a5b-8c30c42a0f05");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "ea8483a8-a470-424e-a885-75b380e8d361");

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuize_Quize_quizeid1",
                table: "UserQuize",
                column: "quizeid1",
                principalTable: "Quize",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuize_AspNetUsers_userid",
                table: "UserQuize",
                column: "userid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserQuize_Quize_quizeid1",
                table: "UserQuize");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuize_AspNetUsers_userid",
                table: "UserQuize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserQuize",
                table: "UserQuize");

            migrationBuilder.RenameTable(
                name: "UserQuize",
                newName: "Userquizes");

            migrationBuilder.RenameIndex(
                name: "IX_UserQuize_userid",
                table: "Userquizes",
                newName: "IX_Userquizes_userid");

            migrationBuilder.RenameIndex(
                name: "IX_UserQuize_quizeid1",
                table: "Userquizes",
                newName: "IX_Userquizes_quizeid1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Userquizes",
                table: "Userquizes",
                columns: new[] { "quizeid", "userid" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Userquizes_Quize_quizeid1",
                table: "Userquizes",
                column: "quizeid1",
                principalTable: "Quize",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Userquizes_AspNetUsers_userid",
                table: "Userquizes",
                column: "userid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
