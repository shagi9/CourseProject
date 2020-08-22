using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseProject.DataAccess.Migrations
{
    public partial class sasdas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserRefreshTokens");

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
                columns: new[] { "ConcurrencyStamp", "RegistrationDate" },
                values: new object[] { "9eca9be2-b1c8-4e5b-972c-a69cbdf2190d", new DateTime(2020, 8, 19, 12, 4, 48, 196, DateTimeKind.Local).AddTicks(1980) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "RegistrationDate" },
                values: new object[] { "fa681689-4277-47c6-9ad1-ea689c7d567d", new DateTime(2020, 8, 19, 12, 4, 48, 196, DateTimeKind.Local).AddTicks(2101) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserRefreshTokens",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
