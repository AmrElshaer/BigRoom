using Microsoft.EntityFrameworkCore.Migrations;

namespace BigRoom.Migrations
{
    public partial class update234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quize_Group_GroupId1",
                table: "Quize");

            migrationBuilder.DropIndex(
                name: "IX_Quize_GroupId1",
                table: "Quize");

            migrationBuilder.DropColumn(
                name: "GroupId1",
                table: "Quize");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Quize",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quize_GroupId",
                table: "Quize",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quize_Group_GroupId",
                table: "Quize",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quize_Group_GroupId",
                table: "Quize");

            migrationBuilder.DropIndex(
                name: "IX_Quize_GroupId",
                table: "Quize");

            migrationBuilder.AlterColumn<string>(
                name: "GroupId",
                table: "Quize",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "GroupId1",
                table: "Quize",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quize_GroupId1",
                table: "Quize",
                column: "GroupId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Quize_Group_GroupId1",
                table: "Quize",
                column: "GroupId1",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
