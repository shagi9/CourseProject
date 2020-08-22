using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseProject.DataAccess.Migrations
{
    public partial class something : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRefreshToken_AspNetUsers_UserId",
                table: "UserRefreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRefreshToken",
                table: "UserRefreshToken");

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 1, 1, new DateTime(2020, 9, 2, 12, 48, 30, 442, DateTimeKind.Local).AddTicks(971) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 1, 2, new DateTime(2020, 9, 2, 12, 48, 30, 445, DateTimeKind.Local).AddTicks(9785) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 2, new DateTime(2020, 9, 2, 12, 48, 30, 445, DateTimeKind.Local).AddTicks(9846) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 2, new DateTime(2020, 9, 2, 12, 48, 30, 445, DateTimeKind.Local).AddTicks(9854) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 3, new DateTime(2020, 9, 2, 12, 48, 30, 445, DateTimeKind.Local).AddTicks(9857) });

            migrationBuilder.RenameTable(
                name: "UserRefreshToken",
                newName: "UserRefreshTokens");

            migrationBuilder.RenameIndex(
                name: "IX_UserRefreshToken_UserId",
                table: "UserRefreshTokens",
                newName: "IX_UserRefreshTokens_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRefreshTokens",
                table: "UserRefreshTokens",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserRefreshTokens_AspNetUsers_UserId",
                table: "UserRefreshTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRefreshTokens_AspNetUsers_UserId",
                table: "UserRefreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRefreshTokens",
                table: "UserRefreshTokens");

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

            migrationBuilder.RenameTable(
                name: "UserRefreshTokens",
                newName: "UserRefreshToken");

            migrationBuilder.RenameIndex(
                name: "IX_UserRefreshTokens_UserId",
                table: "UserRefreshToken",
                newName: "IX_UserRefreshToken_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRefreshToken",
                table: "UserRefreshToken",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "70cf5df7-d8e5-4eea-8391-e431dc7930dd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "9cfec901-75e6-47cf-a7c3-6ecf2d697353");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "RegistrationDate" },
                values: new object[] { "8f413e1e-e63a-4579-ad44-327663b7e2f1", new DateTime(2020, 8, 18, 12, 48, 30, 457, DateTimeKind.Local).AddTicks(8045) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "RegistrationDate" },
                values: new object[] { "3bd397ea-560e-4eb3-acf4-3a30f2e524cf", new DateTime(2020, 8, 18, 12, 48, 30, 457, DateTimeKind.Local).AddTicks(8172) });

            migrationBuilder.InsertData(
                table: "CoursesToUsers",
                columns: new[] { "UserId", "CourseId", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 9, 2, 12, 48, 30, 442, DateTimeKind.Local).AddTicks(971) },
                    { 1, 2, new DateTime(2020, 9, 2, 12, 48, 30, 445, DateTimeKind.Local).AddTicks(9785) },
                    { 2, 2, new DateTime(2020, 9, 2, 12, 48, 30, 445, DateTimeKind.Local).AddTicks(9846) },
                    { 2, 2, new DateTime(2020, 9, 2, 12, 48, 30, 445, DateTimeKind.Local).AddTicks(9854) },
                    { 2, 3, new DateTime(2020, 9, 2, 12, 48, 30, 445, DateTimeKind.Local).AddTicks(9857) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRefreshToken_AspNetUsers_UserId",
                table: "UserRefreshToken",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
