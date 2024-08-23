using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddSubjectCodeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubjectCode",
                table: "Subjects",
                type: "text",
                nullable: true);

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
                columns: new[] { "CreatedOn", "SubjectCode", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), null, new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "SubjectCode", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), null, new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "SubjectCode", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), null, new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "SubjectCode", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), null, new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "SubjectCode", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), null, new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "SubjectCode", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), null, new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "SubjectCode", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), null, new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "SubjectCode", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), null, new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "SubjectCode", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), null, new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "SubjectCode", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), null, new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "SubjectCode", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), null, new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "SubjectCode", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433), null, new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 45, 22, 555, DateTimeKind.Utc).AddTicks(7527), new DateTime(2024, 8, 23, 11, 45, 21, 904, DateTimeKind.Utc).AddTicks(433) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectCode",
                table: "Subjects");

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 23, 9, 4, 48, 991, DateTimeKind.Utc).AddTicks(5867), new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });
        }
    }
}
