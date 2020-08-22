using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseProject.DataAccess.Migrations
{
    public partial class addedsomethingasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                value: "69918983-2555-4c6b-916b-684810410d53");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "65c3b6aa-06ea-4202-94b8-9d0d5d5afdb0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "RegistrationDate" },
                values: new object[] { "16aafb3e-deb1-4169-8a55-b3d4319a059b", new DateTime(2020, 8, 19, 11, 39, 31, 102, DateTimeKind.Local).AddTicks(8790) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "RegistrationDate" },
                values: new object[] { "7652013c-6d9a-4bcd-a19b-c2c4cfe08a49", new DateTime(2020, 8, 19, 11, 39, 31, 102, DateTimeKind.Local).AddTicks(8930) });

            migrationBuilder.InsertData(
                table: "CoursesToUsers",
                columns: new[] { "UserId", "CourseId", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 9, 3, 11, 39, 31, 90, DateTimeKind.Local).AddTicks(5567) },
                    { 1, 2, new DateTime(2020, 9, 3, 11, 39, 31, 94, DateTimeKind.Local).AddTicks(3850) },
                    { 2, 2, new DateTime(2020, 9, 3, 11, 39, 31, 94, DateTimeKind.Local).AddTicks(3910) },
                    { 2, 2, new DateTime(2020, 9, 3, 11, 39, 31, 94, DateTimeKind.Local).AddTicks(3919) },
                    { 2, 3, new DateTime(2020, 9, 3, 11, 39, 31, 94, DateTimeKind.Local).AddTicks(3924) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 1, 1, new DateTime(2020, 9, 3, 11, 39, 31, 90, DateTimeKind.Local).AddTicks(5567) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 1, 2, new DateTime(2020, 9, 3, 11, 39, 31, 94, DateTimeKind.Local).AddTicks(3850) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 2, new DateTime(2020, 9, 3, 11, 39, 31, 94, DateTimeKind.Local).AddTicks(3910) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 2, new DateTime(2020, 9, 3, 11, 39, 31, 94, DateTimeKind.Local).AddTicks(3919) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 3, new DateTime(2020, 9, 3, 11, 39, 31, 94, DateTimeKind.Local).AddTicks(3924) });

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "UserRefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ReplacedByToken",
                table: "UserRefreshTokens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Revoked",
                table: "UserRefreshTokens",
                type: "datetime2",
                nullable: true);

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
        }
    }
}
