using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnToSubjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437), new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437), new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437), new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437), new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437), new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437), new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437), new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437), new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 43, 42, 940, DateTimeKind.Utc).AddTicks(6684), new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144), new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144), new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144), new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144), new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144), new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144), new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144), new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144), new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 16, 9, 3, 52, 968, DateTimeKind.Utc).AddTicks(5521), new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144) });
        }
    }
}
