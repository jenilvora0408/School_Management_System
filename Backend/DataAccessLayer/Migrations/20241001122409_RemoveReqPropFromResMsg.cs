using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveReqPropFromResMsg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ResponseMessage",
                table: "ContactPrincipal",
                type: "character varying(2500)",
                maxLength: 2500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(2500)",
                oldMaxLength: 2500);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestDate",
                table: "ContactPrincipal",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 1, 12, 24, 8, 786, DateTimeKind.Utc).AddTicks(3803),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 10, 1, 10, 49, 22, 959, DateTimeKind.Utc).AddTicks(1182));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ResponseMessage",
                table: "ContactPrincipal",
                type: "character varying(2500)",
                maxLength: 2500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(2500)",
                oldMaxLength: 2500,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestDate",
                table: "ContactPrincipal",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 1, 10, 49, 22, 959, DateTimeKind.Utc).AddTicks(1182),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 10, 1, 12, 24, 8, 786, DateTimeKind.Utc).AddTicks(3803));

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 960, DateTimeKind.Utc).AddTicks(593), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });
        }
    }
}
