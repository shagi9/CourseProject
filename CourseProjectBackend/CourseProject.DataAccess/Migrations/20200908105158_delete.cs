using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseProject.DataAccess.Migrations
{
    public partial class delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_UserId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_UserId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7b87980b-7297-4a67-946a-43765e345405");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "88087b8d-c5d5-4ccd-81ef-10ce75368b16");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "RegistrationDate" },
                values: new object[] { "911673c4-96cf-4986-a045-4e8f1d07b70b", new DateTime(2020, 9, 8, 13, 51, 57, 867, DateTimeKind.Local).AddTicks(2625) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "RegistrationDate" },
                values: new object[] { "f062d44a-3e18-40a1-a43c-5ca0b1db9859", new DateTime(2020, 9, 8, 13, 51, 57, 867, DateTimeKind.Local).AddTicks(2778) });

            migrationBuilder.UpdateData(
                table: "CoursesToUsers",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 10, 8, 13, 51, 57, 857, DateTimeKind.Local).AddTicks(5403), new DateTime(2020, 9, 23, 13, 51, 57, 857, DateTimeKind.Local).AddTicks(4884) });

            migrationBuilder.UpdateData(
                table: "CoursesToUsers",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 10, 8, 13, 51, 57, 857, DateTimeKind.Local).AddTicks(5874), new DateTime(2020, 9, 23, 13, 51, 57, 857, DateTimeKind.Local).AddTicks(5849) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: 1);

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

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UserId",
                table: "Courses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_UserId",
                table: "Courses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
