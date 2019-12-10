using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BigRoom.Data.Migrations
{
    public partial class updateuserquize4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Degreeofquizes");

            migrationBuilder.CreateTable(
                name: "Degree",
                columns: table => new
                {
                    quize = table.Column<string>(nullable: false),
                    user = table.Column<string>(nullable: false),
                    degree = table.Column<int>(nullable: false),
                    Quizeid = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degree", x => new { x.user, x.quize });
                    table.ForeignKey(
                        name: "FK_Degree_Quize_Quizeid",
                        column: x => x.Quizeid,
                        principalTable: "Quize",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Degree_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "0b2aae21-f3fb-4ae3-b2fc-b60e6c75aabb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "52e12bd9-73cd-4134-bfe0-5a601c6e5eb9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "2330b0b0-db5d-4cf7-a786-f5eef1747923");

            migrationBuilder.CreateIndex(
                name: "IX_Degree_Quizeid",
                table: "Degree",
                column: "Quizeid");

            migrationBuilder.CreateIndex(
                name: "IX_Degree_UserId",
                table: "Degree",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Degree");

            migrationBuilder.CreateTable(
                name: "Degreeofquizes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    degree = table.Column<int>(nullable: false),
                    quizeid = table.Column<string>(nullable: true),
                    quizeid1 = table.Column<int>(nullable: true),
                    userid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degreeofquizes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Degreeofquizes_Quize_quizeid1",
                        column: x => x.quizeid1,
                        principalTable: "Quize",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Degreeofquizes_AspNetUsers_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Degreeofquizes_quizeid1",
                table: "Degreeofquizes",
                column: "quizeid1");

            migrationBuilder.CreateIndex(
                name: "IX_Degreeofquizes_userid",
                table: "Degreeofquizes",
                column: "userid");
        }
    }
}
