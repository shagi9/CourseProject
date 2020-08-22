using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseProject.DataAccess.Migrations
{
    public partial class AddedRefreshTokenTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "UserRefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefreshToken = table.Column<string>(nullable: true),
                    Expires = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRefreshToken_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshToken_UserId",
                table: "UserRefreshToken",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRefreshToken");

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
                columns: new[] { "ConcurrencyStamp", "RegistrationDate" },
                values: new object[] { "0cde99fb-f571-43f7-8c66-2791b560b976", new DateTime(2020, 8, 11, 22, 3, 36, 462, DateTimeKind.Local).AddTicks(7730) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "RegistrationDate" },
                values: new object[] { "bb3b694d-7a6a-4b38-bc94-4f5fbaaf1c01", new DateTime(2020, 8, 11, 22, 3, 36, 462, DateTimeKind.Local).AddTicks(7858) });

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
    }
}
