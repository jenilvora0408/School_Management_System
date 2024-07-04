using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class NullableColumnAdmitRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AdmitRequests",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "AdmitRequests",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410), new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410), new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410), new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410), new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410), new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410), new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410), new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410), new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 4, 6, 9, 41, 958, DateTimeKind.Utc).AddTicks(9957), new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AdmitRequests",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "AdmitRequests",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041), new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041), new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041), new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041), new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041), new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041), new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041), new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041), new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 2, 10, 45, 41, 295, DateTimeKind.Utc).AddTicks(1224), new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041) });
        }
    }
}
