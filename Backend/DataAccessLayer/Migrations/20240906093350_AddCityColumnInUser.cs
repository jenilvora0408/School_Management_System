using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddCityColumnInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                type: "character varying(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "City", "CreatedOn", "UpdatedOn" },
                values: new object[] { null, new DateTime(2024, 9, 6, 9, 33, 47, 579, DateTimeKind.Utc).AddTicks(4142), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 3, 5, 49, 5, 764, DateTimeKind.Utc).AddTicks(5320), new DateTime(2024, 9, 3, 5, 49, 5, 179, DateTimeKind.Utc).AddTicks(7617) });
        }
    }
}
