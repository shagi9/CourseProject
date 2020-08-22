using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseProject.DataAccess.Migrations
{
    public partial class addedsomething : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 1, 1, new DateTime(2020, 9, 3, 10, 30, 44, 694, DateTimeKind.Local).AddTicks(3305) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 1, 2, new DateTime(2020, 9, 3, 10, 30, 44, 698, DateTimeKind.Local).AddTicks(4561) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 2, new DateTime(2020, 9, 3, 10, 30, 44, 698, DateTimeKind.Local).AddTicks(4606) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 2, new DateTime(2020, 9, 3, 10, 30, 44, 698, DateTimeKind.Local).AddTicks(4614) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 3, new DateTime(2020, 9, 3, 10, 30, 44, 698, DateTimeKind.Local).AddTicks(4618) });

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserRefreshTokens",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "07d9d2cf-9be7-4dfa-83ea-c646b44d9292");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "c4399d5b-d70e-47e8-b2a7-f98980ce311b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "RegistrationDate" },
                values: new object[] { "8bd41438-25a0-4ad9-af22-fe330403ce96", new DateTime(2020, 8, 19, 11, 24, 3, 933, DateTimeKind.Local).AddTicks(9588) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "RegistrationDate" },
                values: new object[] { "b4cd3ec2-7c8f-4c07-9db3-4e07d63eff69", new DateTime(2020, 8, 19, 11, 24, 3, 933, DateTimeKind.Local).AddTicks(9716) });

            migrationBuilder.InsertData(
                table: "CoursesToUsers",
                columns: new[] { "UserId", "CourseId", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 9, 3, 11, 24, 3, 921, DateTimeKind.Local).AddTicks(2291) },
                    { 1, 2, new DateTime(2020, 9, 3, 11, 24, 3, 925, DateTimeKind.Local).AddTicks(1072) },
                    { 2, 2, new DateTime(2020, 9, 3, 11, 24, 3, 925, DateTimeKind.Local).AddTicks(1131) },
                    { 2, 2, new DateTime(2020, 9, 3, 11, 24, 3, 925, DateTimeKind.Local).AddTicks(1138) },
                    { 2, 3, new DateTime(2020, 9, 3, 11, 24, 3, 925, DateTimeKind.Local).AddTicks(1142) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshTokens_UserId1",
                table: "UserRefreshTokens",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRefreshTokens_IdentityUser_UserId1",
                table: "UserRefreshTokens",
                column: "UserId1",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRefreshTokens_IdentityUser_UserId1",
                table: "UserRefreshTokens");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropIndex(
                name: "IX_UserRefreshTokens_UserId1",
                table: "UserRefreshTokens");

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 1, 1, new DateTime(2020, 9, 3, 11, 24, 3, 921, DateTimeKind.Local).AddTicks(2291) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 1, 2, new DateTime(2020, 9, 3, 11, 24, 3, 925, DateTimeKind.Local).AddTicks(1072) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 2, new DateTime(2020, 9, 3, 11, 24, 3, 925, DateTimeKind.Local).AddTicks(1131) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 2, new DateTime(2020, 9, 3, 11, 24, 3, 925, DateTimeKind.Local).AddTicks(1138) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 3, new DateTime(2020, 9, 3, 11, 24, 3, 925, DateTimeKind.Local).AddTicks(1142) });

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserRefreshTokens");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e3871c26-95c8-4162-b2f4-14f51424a212");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "57a3501d-595b-4a91-b298-6e31c81a924f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "RegistrationDate" },
                values: new object[] { "0fb509a8-8f4b-41b5-bc1e-dc1dfa567df9", new DateTime(2020, 8, 19, 10, 30, 44, 709, DateTimeKind.Local).AddTicks(2649) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "RegistrationDate" },
                values: new object[] { "97fd02fc-cc91-40d3-b641-d13a81f28537", new DateTime(2020, 8, 19, 10, 30, 44, 709, DateTimeKind.Local).AddTicks(2796) });

            migrationBuilder.InsertData(
                table: "CoursesToUsers",
                columns: new[] { "UserId", "CourseId", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 9, 3, 10, 30, 44, 694, DateTimeKind.Local).AddTicks(3305) },
                    { 1, 2, new DateTime(2020, 9, 3, 10, 30, 44, 698, DateTimeKind.Local).AddTicks(4561) },
                    { 2, 2, new DateTime(2020, 9, 3, 10, 30, 44, 698, DateTimeKind.Local).AddTicks(4606) },
                    { 2, 2, new DateTime(2020, 9, 3, 10, 30, 44, 698, DateTimeKind.Local).AddTicks(4614) },
                    { 2, 3, new DateTime(2020, 9, 3, 10, 30, 44, 698, DateTimeKind.Local).AddTicks(4618) }
                });
        }
    }
}
