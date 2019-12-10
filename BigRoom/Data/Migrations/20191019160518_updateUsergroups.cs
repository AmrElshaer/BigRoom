using Microsoft.EntityFrameworkCore.Migrations;

namespace BigRoom.Data.Migrations
{
    public partial class updateUsergroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroups",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "groupsid",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "usersid",
                table: "UserGroups");

            migrationBuilder.AddColumn<string>(
                name: "CodeJoin",
                table: "UserGroups",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "UserGroups",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroups",
                table: "UserGroups",
                columns: new[] { "CodeJoin", "UserName" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "7b2aaeb9-9e5f-4288-82a9-36dbafc087e5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "c698e1e3-2c02-415b-9708-b45040ba0839");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "a34f2b74-5a6d-49b5-8a89-96aabe3291f9");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroups",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "CodeJoin",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "UserGroups");

            migrationBuilder.AddColumn<int>(
                name: "groupsid",
                table: "UserGroups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "usersid",
                table: "UserGroups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroups",
                table: "UserGroups",
                columns: new[] { "groupsid", "usersid" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b8f86093-606f-4e8d-ac84-c3130ab8db43");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "33ddd24c-7d1d-4a88-9ec5-896f9dfc9a03");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "44987b1d-6068-466f-9ff4-eff5e06ce36b");
        }
    }
}
