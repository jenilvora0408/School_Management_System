using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class userFKConrtactPrincipal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestDate",
                table: "ContactPrincipal",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 16, 4, 51, 22, 227, DateTimeKind.Utc).AddTicks(8458),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 10, 1, 12, 24, 8, 786, DateTimeKind.Utc).AddTicks(3803));

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 22, 229, DateTimeKind.Utc).AddTicks(553), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.CreateIndex(
                name: "IX_ContactPrincipal_UserId",
                table: "ContactPrincipal",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPrincipal_Users_UserId",
                table: "ContactPrincipal",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactPrincipal_Users_UserId",
                table: "ContactPrincipal");

            migrationBuilder.DropIndex(
                name: "IX_ContactPrincipal_UserId",
                table: "ContactPrincipal");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestDate",
                table: "ContactPrincipal",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 1, 12, 24, 8, 786, DateTimeKind.Utc).AddTicks(3803),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 10, 16, 4, 51, 22, 227, DateTimeKind.Utc).AddTicks(8458));

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 24, 8, 787, DateTimeKind.Utc).AddTicks(3184), new DateTime(2024, 10, 1, 12, 24, 8, 184, DateTimeKind.Utc).AddTicks(5009) });
        }
    }
}
