using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BigRoom.Data.Migrations
{
    public partial class updateuserquize3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_degreeofquize_Quize_quizeid1",
                table: "degreeofquize");

            migrationBuilder.DropForeignKey(
                name: "FK_degreeofquize_AspNetUsers_userid",
                table: "degreeofquize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_degreeofquize",
                table: "degreeofquize");

            migrationBuilder.RenameTable(
                name: "degreeofquize",
                newName: "Degreeofquizes");

            migrationBuilder.RenameIndex(
                name: "IX_degreeofquize_userid",
                table: "Degreeofquizes",
                newName: "IX_Degreeofquizes_userid");

            migrationBuilder.RenameIndex(
                name: "IX_degreeofquize_quizeid1",
                table: "Degreeofquizes",
                newName: "IX_Degreeofquizes_quizeid1");

            migrationBuilder.AlterColumn<string>(
                name: "userid",
                table: "Degreeofquizes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "quizeid",
                table: "Degreeofquizes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Degreeofquizes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Degreeofquizes",
                table: "Degreeofquizes",
                column: "id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "bd0c1565-491e-4f03-9905-ea7cad1ac049");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "2a24d3f7-3ce8-4023-9ea5-f88366e2a5a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "958ecc93-9509-4895-b534-fc81b6f0b509");

            migrationBuilder.AddForeignKey(
                name: "FK_Degreeofquizes_Quize_quizeid1",
                table: "Degreeofquizes",
                column: "quizeid1",
                principalTable: "Quize",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Degreeofquizes_AspNetUsers_userid",
                table: "Degreeofquizes",
                column: "userid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Degreeofquizes_Quize_quizeid1",
                table: "Degreeofquizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Degreeofquizes_AspNetUsers_userid",
                table: "Degreeofquizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Degreeofquizes",
                table: "Degreeofquizes");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Degreeofquizes");

            migrationBuilder.RenameTable(
                name: "Degreeofquizes",
                newName: "degreeofquize");

            migrationBuilder.RenameIndex(
                name: "IX_Degreeofquizes_userid",
                table: "degreeofquize",
                newName: "IX_degreeofquize_userid");

            migrationBuilder.RenameIndex(
                name: "IX_Degreeofquizes_quizeid1",
                table: "degreeofquize",
                newName: "IX_degreeofquize_quizeid1");

            migrationBuilder.AlterColumn<string>(
                name: "userid",
                table: "degreeofquize",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "quizeid",
                table: "degreeofquize",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_degreeofquize",
                table: "degreeofquize",
                columns: new[] { "quizeid", "userid" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "8622d28d-0a4f-437a-b485-c419c178dae7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "f60ffd14-5505-466e-8820-458e373306fa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "603c862e-a52f-4e7c-a28e-c2b949c2a950");

            migrationBuilder.AddForeignKey(
                name: "FK_degreeofquize_Quize_quizeid1",
                table: "degreeofquize",
                column: "quizeid1",
                principalTable: "Quize",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_degreeofquize_AspNetUsers_userid",
                table: "degreeofquize",
                column: "userid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
