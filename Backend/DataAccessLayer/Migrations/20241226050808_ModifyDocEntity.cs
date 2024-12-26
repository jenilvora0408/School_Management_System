using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class ModifyDocEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentExtension",
                table: "Documents",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentName",
                table: "Documents",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentType",
                table: "Documents",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestDate",
                table: "ContactPrincipal",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 26, 5, 8, 7, 194, DateTimeKind.Utc).AddTicks(4455),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 11, 6, 12, 28, 0, 513, DateTimeKind.Utc).AddTicks(5848));

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 26, 5, 8, 7, 198, DateTimeKind.Utc).AddTicks(940), new DateTime(2024, 12, 26, 5, 8, 6, 543, DateTimeKind.Utc).AddTicks(3467) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentExtension",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentName",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "Documents");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestDate",
                table: "ContactPrincipal",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 6, 12, 28, 0, 513, DateTimeKind.Utc).AddTicks(5848),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 12, 26, 5, 8, 7, 194, DateTimeKind.Utc).AddTicks(4455));

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 28, 0, 515, DateTimeKind.Utc).AddTicks(7385), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });
        }
    }
}
