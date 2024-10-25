using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRelatableEvidenceColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelatableEvidence",
                table: "ContactPrincipal");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestDate",
                table: "ContactPrincipal",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 25, 5, 51, 8, 927, DateTimeKind.Utc).AddTicks(8502),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 10, 16, 9, 40, 38, 331, DateTimeKind.Utc).AddTicks(2051));

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 929, DateTimeKind.Utc).AddTicks(3400), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestDate",
                table: "ContactPrincipal",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 16, 9, 40, 38, 331, DateTimeKind.Utc).AddTicks(2051),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 10, 25, 5, 51, 8, 927, DateTimeKind.Utc).AddTicks(8502));

            migrationBuilder.AddColumn<string>(
                name: "RelatableEvidence",
                table: "ContactPrincipal",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 38, 333, DateTimeKind.Utc).AddTicks(431), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });
        }
    }
}
