using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseProject.DataAccess.Migrations
{
    public partial class asaasasdas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 1, 1, new DateTime(2020, 9, 3, 12, 4, 48, 182, DateTimeKind.Local).AddTicks(3926) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 1, 2, new DateTime(2020, 9, 3, 12, 4, 48, 185, DateTimeKind.Local).AddTicks(6915) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 2, new DateTime(2020, 9, 3, 12, 4, 48, 185, DateTimeKind.Local).AddTicks(6962) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 2, new DateTime(2020, 9, 3, 12, 4, 48, 185, DateTimeKind.Local).AddTicks(6969) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 3, new DateTime(2020, 9, 3, 12, 4, 48, 185, DateTimeKind.Local).AddTicks(6972) });

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "56fd3ceb-3bb8-4d83-a0f4-57edfdca09dc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "fcca3027-aae9-465a-b976-86e36d127903");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "RegistrationDate" },
                values: new object[] { "2e9bf8d7-5d6b-4e4a-a156-673923cb59da", new DateTime(1997, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 20, 12, 0, 1, 482, DateTimeKind.Local).AddTicks(8798) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "RegistrationDate" },
                values: new object[] { "96ee8f22-e5c3-4ac1-bb4c-e4982e6d1dfb", new DateTime(1998, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 20, 12, 0, 1, 482, DateTimeKind.Local).AddTicks(8932) });

            migrationBuilder.InsertData(
                table: "CoursesToUsers",
                columns: new[] { "UserId", "CourseId", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 9, 4, 12, 0, 1, 470, DateTimeKind.Local).AddTicks(1613) },
                    { 1, 2, new DateTime(2020, 9, 4, 12, 0, 1, 473, DateTimeKind.Local).AddTicks(2408) },
                    { 2, 2, new DateTime(2020, 9, 4, 12, 0, 1, 473, DateTimeKind.Local).AddTicks(2455) },
                    { 2, 2, new DateTime(2020, 9, 4, 12, 0, 1, 473, DateTimeKind.Local).AddTicks(2463) },
                    { 2, 3, new DateTime(2020, 9, 4, 12, 0, 1, 473, DateTimeKind.Local).AddTicks(2467) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 1, 1, new DateTime(2020, 9, 4, 12, 0, 1, 470, DateTimeKind.Local).AddTicks(1613) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 1, 2, new DateTime(2020, 9, 4, 12, 0, 1, 473, DateTimeKind.Local).AddTicks(2408) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 2, new DateTime(2020, 9, 4, 12, 0, 1, 473, DateTimeKind.Local).AddTicks(2455) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 2, new DateTime(2020, 9, 4, 12, 0, 1, 473, DateTimeKind.Local).AddTicks(2463) });

            migrationBuilder.DeleteData(
                table: "CoursesToUsers",
                keyColumns: new[] { "UserId", "CourseId", "StartDate" },
                keyValues: new object[] { 2, 3, new DateTime(2020, 9, 4, 12, 0, 1, 473, DateTimeKind.Local).AddTicks(2467) });

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "830b97d2-dae5-426b-b7ee-97ed4dc2c79b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "7fc86564-fda7-4ac0-a87a-5773435abad3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Age", "ConcurrencyStamp", "RegistrationDate" },
                values: new object[] { 23, "9eca9be2-b1c8-4e5b-972c-a69cbdf2190d", new DateTime(2020, 8, 19, 12, 4, 48, 196, DateTimeKind.Local).AddTicks(1980) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Age", "ConcurrencyStamp", "RegistrationDate" },
                values: new object[] { 21, "fa681689-4277-47c6-9ad1-ea689c7d567d", new DateTime(2020, 8, 19, 12, 4, 48, 196, DateTimeKind.Local).AddTicks(2101) });

            migrationBuilder.InsertData(
                table: "CoursesToUsers",
                columns: new[] { "UserId", "CourseId", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 9, 3, 12, 4, 48, 182, DateTimeKind.Local).AddTicks(3926) },
                    { 1, 2, new DateTime(2020, 9, 3, 12, 4, 48, 185, DateTimeKind.Local).AddTicks(6915) },
                    { 2, 2, new DateTime(2020, 9, 3, 12, 4, 48, 185, DateTimeKind.Local).AddTicks(6962) },
                    { 2, 2, new DateTime(2020, 9, 3, 12, 4, 48, 185, DateTimeKind.Local).AddTicks(6969) },
                    { 2, 3, new DateTime(2020, 9, 3, 12, 4, 48, 185, DateTimeKind.Local).AddTicks(6972) }
                });
        }
    }
}
