using Microsoft.EntityFrameworkCore.Migrations;

namespace BigRoom.Data.Migrations
{
    public partial class userquizedeteail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Userquize_Quize_quizeid",
                table: "Userquize");

            migrationBuilder.DropForeignKey(
                name: "FK_Userquize_AspNetUsers_usersId",
                table: "Userquize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Userquize",
                table: "Userquize");

            migrationBuilder.DropIndex(
                name: "IX_Userquize_usersId",
                table: "Userquize");

            migrationBuilder.DropColumn(
                name: "quizesid",
                table: "Quize");

            migrationBuilder.DropColumn(
                name: "usersId",
                table: "Userquize");

            migrationBuilder.RenameTable(
                name: "Userquize",
                newName: "Userquizes");

            migrationBuilder.AlterColumn<string>(
                name: "userid",
                table: "Userquizes",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "quizeid",
                table: "Userquizes",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "quizeid1",
                table: "Userquizes",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Userquizes",
                table: "Userquizes",
                columns: new[] { "quizeid", "userid" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Userquizes_quizeid1",
                table: "Userquizes",
                column: "quizeid1");

            migrationBuilder.CreateIndex(
                name: "IX_Userquizes_userid",
                table: "Userquizes",
                column: "userid");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Userquizes_quizeid1",
                table: "Userquizes");

            migrationBuilder.DropIndex(
                name: "IX_Userquizes_userid",
                table: "Userquizes");

            migrationBuilder.DropColumn(
                name: "quizeid1",
                table: "Userquizes");

            migrationBuilder.RenameTable(
                name: "Userquizes",
                newName: "Userquize");

            migrationBuilder.AddColumn<string>(
                name: "quizesid",
                table: "Quize",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "userid",
                table: "Userquize",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "quizeid",
                table: "Userquize",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "usersId",
                table: "Userquize",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Userquize",
                table: "Userquize",
                columns: new[] { "quizeid", "userid" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "bb6f83a4-dbbf-4ff8-b40e-3b125a46c028");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "4e44d489-c3d4-440e-8807-31cc82788afa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "f68447d0-094a-4759-89f9-318f02a286b1");

            migrationBuilder.CreateIndex(
                name: "IX_Userquize_usersId",
                table: "Userquize",
                column: "usersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Userquize_Quize_quizeid",
                table: "Userquize",
                column: "quizeid",
                principalTable: "Quize",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Userquize_AspNetUsers_usersId",
                table: "Userquize",
                column: "usersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
