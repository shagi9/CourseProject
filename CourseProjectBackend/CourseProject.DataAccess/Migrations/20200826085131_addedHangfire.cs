using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseProject.DataAccess.Migrations
{
    public partial class addedHangfire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "3c234326-cc3a-48ff-b35a-f736495bc6f0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "c06371c6-0f9c-47cf-823f-3c89f98416b0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "RegistrationDate" },
                values: new object[] { "23af3e19-43ad-4cc0-b738-ecd1a723c2ff", new DateTime(2020, 8, 26, 11, 51, 30, 564, DateTimeKind.Local).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "RegistrationDate" },
                values: new object[] { "033c2181-e7bf-4378-bebd-b210f5bc456e", new DateTime(2020, 8, 26, 11, 51, 30, 564, DateTimeKind.Local).AddTicks(7070) });

            migrationBuilder.UpdateData(
                table: "CoursesToUsers",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 9, 25, 11, 51, 30, 553, DateTimeKind.Local).AddTicks(3960), new DateTime(2020, 9, 10, 11, 51, 30, 548, DateTimeKind.Local).AddTicks(5457) });

            migrationBuilder.UpdateData(
                table: "CoursesToUsers",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 9, 25, 11, 51, 30, 553, DateTimeKind.Local).AddTicks(4768), new DateTime(2020, 9, 10, 11, 51, 30, 553, DateTimeKind.Local).AddTicks(4741) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "fe31af83-77fc-4420-ba6d-c808184d8a3e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "a8ca9a93-c71f-4b85-b852-b13df5d507a7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "RegistrationDate" },
                values: new object[] { "bf6989df-ed84-426d-af36-cc9f7d40a110", new DateTime(2020, 8, 25, 12, 51, 45, 427, DateTimeKind.Local).AddTicks(6630) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "RegistrationDate" },
                values: new object[] { "c6a13c3d-5b11-4c75-97c8-dda30aefdacb", new DateTime(2020, 8, 25, 12, 51, 45, 427, DateTimeKind.Local).AddTicks(6863) });

            migrationBuilder.UpdateData(
                table: "CoursesToUsers",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 9, 24, 12, 51, 45, 416, DateTimeKind.Local).AddTicks(5597), new DateTime(2020, 9, 9, 12, 51, 45, 413, DateTimeKind.Local).AddTicks(1213) });

            migrationBuilder.UpdateData(
                table: "CoursesToUsers",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 9, 24, 12, 51, 45, 416, DateTimeKind.Local).AddTicks(6409), new DateTime(2020, 9, 9, 12, 51, 45, 416, DateTimeKind.Local).AddTicks(6381) });
        }
    }
}
