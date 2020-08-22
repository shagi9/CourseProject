using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseProject.DataAccess.Migrations
{
    public partial class experemintal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 1, 1, new DateTime(2020, 9, 2, 16, 0, 47, 302, DateTimeKind.Local).AddTicks(8687) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 1, 2, new DateTime(2020, 9, 2, 16, 0, 47, 306, DateTimeKind.Local).AddTicks(2035) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 2, new DateTime(2020, 9, 2, 16, 0, 47, 306, DateTimeKind.Local).AddTicks(2091) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 2, new DateTime(2020, 9, 2, 16, 0, 47, 306, DateTimeKind.Local).AddTicks(2098) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 3, new DateTime(2020, 9, 2, 16, 0, 47, 306, DateTimeKind.Local).AddTicks(2164) });

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "UserRefreshTokens",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ReplacedByToken",
                table: "UserRefreshTokens",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Revoked",
                table: "UserRefreshTokens",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Created",
                table: "UserRefreshTokens");

            migrationBuilder.DropColumn(
                name: "ReplacedByToken",
                table: "UserRefreshTokens");

            migrationBuilder.DropColumn(
                name: "Revoked",
                table: "UserRefreshTokens");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f6456aeb-8c43-479b-a8e1-fe4d4db33abe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "ca01148d-71cf-4ad8-8c48-4ae9be9b38b7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "RegistrationDate" },
                values: new object[] { "cac9cb1a-f04b-4304-b762-68be563b8008", new DateTime(2020, 8, 18, 16, 0, 47, 319, DateTimeKind.Local).AddTicks(3888) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "RegistrationDate" },
                values: new object[] { "796e12b3-b40d-40e0-ab63-cf4ce1363a0b", new DateTime(2020, 8, 18, 16, 0, 47, 319, DateTimeKind.Local).AddTicks(4015) });

            migrationBuilder.InsertData(
                table: "CoursesToUsers",
                columns: new[] { "UserId", "CourseId", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 9, 2, 16, 0, 47, 302, DateTimeKind.Local).AddTicks(8687) },
                    { 1, 2, new DateTime(2020, 9, 2, 16, 0, 47, 306, DateTimeKind.Local).AddTicks(2035) },
                    { 2, 2, new DateTime(2020, 9, 2, 16, 0, 47, 306, DateTimeKind.Local).AddTicks(2091) },
                    { 2, 2, new DateTime(2020, 9, 2, 16, 0, 47, 306, DateTimeKind.Local).AddTicks(2098) },
                    { 2, 3, new DateTime(2020, 9, 2, 16, 0, 47, 306, DateTimeKind.Local).AddTicks(2164) }
                });
        }
    }
}
