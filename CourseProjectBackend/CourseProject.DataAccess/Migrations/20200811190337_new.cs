using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseProject.DataAccess.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 1, 1, new DateTime(2020, 8, 25, 16, 4, 18, 97, DateTimeKind.Local).AddTicks(9511) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 1, 2, new DateTime(2020, 8, 25, 16, 4, 18, 101, DateTimeKind.Local).AddTicks(2203) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 2, new DateTime(2020, 8, 25, 16, 4, 18, 101, DateTimeKind.Local).AddTicks(2253) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 2, new DateTime(2020, 8, 25, 16, 4, 18, 101, DateTimeKind.Local).AddTicks(2260) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 3, new DateTime(2020, 8, 25, 16, 4, 18, 101, DateTimeKind.Local).AddTicks(2265) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "2cddfadd-2445-4c7c-b78d-f539a57da27a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "a93b0bb3-ffd7-4145-8843-976e08f5ba56");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PhoneNumber", "RegistrationDate" },
                values: new object[] { "0cde99fb-f571-43f7-8c66-2791b560b976", null, new DateTime(2020, 8, 11, 22, 3, 36, 462, DateTimeKind.Local).AddTicks(7730) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PhoneNumber", "RegistrationDate" },
                values: new object[] { "bb3b694d-7a6a-4b38-bc94-4f5fbaaf1c01", null, new DateTime(2020, 8, 11, 22, 3, 36, 462, DateTimeKind.Local).AddTicks(7858) });

            migrationBuilder.InsertData(
                table: "CoursesToUsers",
                columns: new[] { "UserId", "CourseId", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 8, 26, 22, 3, 36, 448, DateTimeKind.Local).AddTicks(5672) },
                    { 1, 2, new DateTime(2020, 8, 26, 22, 3, 36, 452, DateTimeKind.Local).AddTicks(535) },
                    { 2, 2, new DateTime(2020, 8, 26, 22, 3, 36, 452, DateTimeKind.Local).AddTicks(592) },
                    { 2, 2, new DateTime(2020, 8, 26, 22, 3, 36, 452, DateTimeKind.Local).AddTicks(599) },
                    { 2, 3, new DateTime(2020, 8, 26, 22, 3, 36, 452, DateTimeKind.Local).AddTicks(604) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 1, 1, new DateTime(2020, 8, 26, 22, 3, 36, 448, DateTimeKind.Local).AddTicks(5672) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 1, 2, new DateTime(2020, 8, 26, 22, 3, 36, 452, DateTimeKind.Local).AddTicks(535) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 2, new DateTime(2020, 8, 26, 22, 3, 36, 452, DateTimeKind.Local).AddTicks(592) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 2, new DateTime(2020, 8, 26, 22, 3, 36, 452, DateTimeKind.Local).AddTicks(599) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 3, new DateTime(2020, 8, 26, 22, 3, 36, 452, DateTimeKind.Local).AddTicks(604) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "1b2d383b-3ba4-4431-8157-5f63f571a45d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "44c380c9-0a39-44a7-ba2e-81b0f395403f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PhoneNumber", "RegistrationDate" },
                values: new object[] { "d4300009-8be4-4c2b-b7e5-6d56c04911bc", "0971500793", new DateTime(2020, 8, 10, 16, 4, 18, 112, DateTimeKind.Local).AddTicks(3347) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PhoneNumber", "RegistrationDate" },
                values: new object[] { "4599305e-dfd8-4d98-952f-9115e19f5775", "0972312793", new DateTime(2020, 8, 10, 16, 4, 18, 112, DateTimeKind.Local).AddTicks(3469) });

            migrationBuilder.InsertData(
                table: "CoursesToUsers",
                columns: new[] { "UserId", "CourseId", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 8, 25, 16, 4, 18, 97, DateTimeKind.Local).AddTicks(9511) },
                    { 1, 2, new DateTime(2020, 8, 25, 16, 4, 18, 101, DateTimeKind.Local).AddTicks(2203) },
                    { 2, 2, new DateTime(2020, 8, 25, 16, 4, 18, 101, DateTimeKind.Local).AddTicks(2253) },
                    { 2, 2, new DateTime(2020, 8, 25, 16, 4, 18, 101, DateTimeKind.Local).AddTicks(2260) },
                    { 2, 3, new DateTime(2020, 8, 25, 16, 4, 18, 101, DateTimeKind.Local).AddTicks(2265) }
                });
        }
    }
}
