using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnStatusInLeave : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "ApprovalStatus",
                table: "Leaves",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)1);

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 49, 16, 926, DateTimeKind.Utc).AddTicks(4334), new DateTime(2024, 7, 29, 9, 49, 16, 926, DateTimeKind.Utc).AddTicks(4334) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 49, 16, 926, DateTimeKind.Utc).AddTicks(4334), new DateTime(2024, 7, 29, 9, 49, 16, 926, DateTimeKind.Utc).AddTicks(4334) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 49, 16, 926, DateTimeKind.Utc).AddTicks(4334), new DateTime(2024, 7, 29, 9, 49, 16, 926, DateTimeKind.Utc).AddTicks(4334) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 49, 16, 926, DateTimeKind.Utc).AddTicks(4334), new DateTime(2024, 7, 29, 9, 49, 16, 926, DateTimeKind.Utc).AddTicks(4334) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 49, 16, 926, DateTimeKind.Utc).AddTicks(4334), new DateTime(2024, 7, 29, 9, 49, 16, 926, DateTimeKind.Utc).AddTicks(4334) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 49, 16, 926, DateTimeKind.Utc).AddTicks(4334), new DateTime(2024, 7, 29, 9, 49, 16, 926, DateTimeKind.Utc).AddTicks(4334) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 49, 16, 926, DateTimeKind.Utc).AddTicks(4334), new DateTime(2024, 7, 29, 9, 49, 16, 926, DateTimeKind.Utc).AddTicks(4334) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 49, 16, 926, DateTimeKind.Utc).AddTicks(4334), new DateTime(2024, 7, 29, 9, 49, 16, 926, DateTimeKind.Utc).AddTicks(4334) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 49, 17, 497, DateTimeKind.Utc).AddTicks(1329), new DateTime(2024, 7, 29, 9, 49, 16, 926, DateTimeKind.Utc).AddTicks(4334) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "Leaves");

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170), new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170), new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170), new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170), new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170), new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170), new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170), new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170), new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 41, 42, 22, DateTimeKind.Utc).AddTicks(4256), new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170) });
        }
    }
}
