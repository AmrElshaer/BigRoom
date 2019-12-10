using Microsoft.EntityFrameworkCore.Migrations;

namespace BigRoom.Data.Migrations
{
    public partial class Updatequize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quize_Group_GroupId",
                table: "Quize");

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
                newName: "UserQuizes");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Quize",
                newName: "GroupId1");

            migrationBuilder.RenameIndex(
                name: "IX_Quize_GroupId",
                table: "Quize",
                newName: "IX_Quize_GroupId1");

            migrationBuilder.RenameIndex(
                name: "IX_UserQuize_userid",
                table: "UserQuizes",
                newName: "IX_UserQuizes_userid");

            migrationBuilder.RenameIndex(
                name: "IX_UserQuize_quizeid1",
                table: "UserQuizes",
                newName: "IX_UserQuizes_quizeid1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserQuizes",
                table: "UserQuizes",
                columns: new[] { "quizeid", "userid" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "53f3e70e-97d5-411e-8b54-06350ee0ed9c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "bacbe833-84f8-4196-92a3-bdbb230f16f9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "5205c63d-5fb0-49c4-ab29-ee3caad2cd32");

            migrationBuilder.AddForeignKey(
                name: "FK_Quize_Group_GroupId1",
                table: "Quize",
                column: "GroupId1",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuizes_Quize_quizeid1",
                table: "UserQuizes",
                column: "quizeid1",
                principalTable: "Quize",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuizes_AspNetUsers_userid",
                table: "UserQuizes",
                column: "userid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quize_Group_GroupId1",
                table: "Quize");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuizes_Quize_quizeid1",
                table: "UserQuizes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuizes_AspNetUsers_userid",
                table: "UserQuizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserQuizes",
                table: "UserQuizes");

            migrationBuilder.RenameTable(
                name: "UserQuizes",
                newName: "UserQuize");

            migrationBuilder.RenameColumn(
                name: "GroupId1",
                table: "Quize",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Quize_GroupId1",
                table: "Quize",
                newName: "IX_Quize_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_UserQuizes_userid",
                table: "UserQuize",
                newName: "IX_UserQuize_userid");

            migrationBuilder.RenameIndex(
                name: "IX_UserQuizes_quizeid1",
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
                name: "FK_Quize_Group_GroupId",
                table: "Quize",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
