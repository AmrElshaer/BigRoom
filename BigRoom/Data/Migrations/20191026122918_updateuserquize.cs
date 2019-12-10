using Microsoft.EntityFrameworkCore.Migrations;

namespace BigRoom.Data.Migrations
{
    public partial class updateuserquize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserQuizes");

            migrationBuilder.CreateTable(
                name: "degreeofquize",
                columns: table => new
                {
                    quizeid = table.Column<string>(nullable: false),
                    userid = table.Column<string>(nullable: false),
                    degree = table.Column<int>(nullable: false),
                    quizeid1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_degreeofquize", x => new { x.quizeid, x.userid });
                    table.ForeignKey(
                        name: "FK_degreeofquize_Quize_quizeid1",
                        column: x => x.quizeid1,
                        principalTable: "Quize",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_degreeofquize_AspNetUsers_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_degreeofquize_quizeid1",
                table: "degreeofquize",
                column: "quizeid1");

            migrationBuilder.CreateIndex(
                name: "IX_degreeofquize_userid",
                table: "degreeofquize",
                column: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "degreeofquize");

            migrationBuilder.CreateTable(
                name: "UserQuizes",
                columns: table => new
                {
                    quizeid = table.Column<string>(nullable: false),
                    userid = table.Column<string>(nullable: false),
                    degree = table.Column<int>(nullable: false),
                    quizeid1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQuizes", x => new { x.quizeid, x.userid });
                    table.ForeignKey(
                        name: "FK_UserQuizes_Quize_quizeid1",
                        column: x => x.quizeid1,
                        principalTable: "Quize",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserQuizes_AspNetUsers_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "f777a527-152c-41cb-b6ca-07aa12c84c01");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "5bd44c96-0090-46fd-966e-c4e54f794523");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "795408c0-aa92-4aa2-8e6f-ce7f0a215ade");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuizes_quizeid1",
                table: "UserQuizes",
                column: "quizeid1");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuizes_userid",
                table: "UserQuizes",
                column: "userid");
        }
    }
}
