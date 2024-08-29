using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUniqueEmailProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AdmitRequests_Email",
                table: "AdmitRequests");

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 29, 9, 50, 22, 318, DateTimeKind.Utc).AddTicks(5565), new DateTime(2024, 8, 29, 9, 50, 21, 755, DateTimeKind.Utc).AddTicks(4411) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 22, 555, DateTimeKind.Utc).AddTicks(7527), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.CreateIndex(
                name: "IX_AdmitRequests_Email",
                table: "AdmitRequests",
                column: "Email",
                unique: true);
        }
    }
}
