using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class SubjectClassConnect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int[]>(
                name: "ClassIds",
                table: "Subjects",
                type: "integer[]",
                nullable: true);

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
                columns: new[] { "ClassIds", "CreatedOn", "UpdatedOn" },
                values: new object[] { null, new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144), new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClassIds", "CreatedOn", "UpdatedOn" },
                values: new object[] { null, new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144), new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClassIds", "CreatedOn", "UpdatedOn" },
                values: new object[] { null, new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144), new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ClassIds", "CreatedOn", "UpdatedOn" },
                values: new object[] { null, new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144), new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ClassIds", "CreatedOn", "UpdatedOn" },
                values: new object[] { null, new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144), new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ClassIds", "CreatedOn", "UpdatedOn" },
                values: new object[] { null, new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144), new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 16, 9, 3, 52, 968, DateTimeKind.Utc).AddTicks(5521), new DateTime(2024, 8, 16, 9, 3, 52, 355, DateTimeKind.Utc).AddTicks(8144) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassIds",
                table: "Subjects");

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 12, 12, 23, 40, 407, DateTimeKind.Utc).AddTicks(8383), new DateTime(2024, 8, 12, 12, 23, 40, 407, DateTimeKind.Utc).AddTicks(8383) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 12, 12, 23, 40, 407, DateTimeKind.Utc).AddTicks(8383), new DateTime(2024, 8, 12, 12, 23, 40, 407, DateTimeKind.Utc).AddTicks(8383) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 12, 12, 23, 40, 407, DateTimeKind.Utc).AddTicks(8383), new DateTime(2024, 8, 12, 12, 23, 40, 407, DateTimeKind.Utc).AddTicks(8383) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 12, 12, 23, 40, 407, DateTimeKind.Utc).AddTicks(8383), new DateTime(2024, 8, 12, 12, 23, 40, 407, DateTimeKind.Utc).AddTicks(8383) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 12, 12, 23, 40, 407, DateTimeKind.Utc).AddTicks(8383), new DateTime(2024, 8, 12, 12, 23, 40, 407, DateTimeKind.Utc).AddTicks(8383) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 12, 12, 23, 40, 407, DateTimeKind.Utc).AddTicks(8383), new DateTime(2024, 8, 12, 12, 23, 40, 407, DateTimeKind.Utc).AddTicks(8383) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 12, 12, 23, 40, 407, DateTimeKind.Utc).AddTicks(8383), new DateTime(2024, 8, 12, 12, 23, 40, 407, DateTimeKind.Utc).AddTicks(8383) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 12, 12, 23, 40, 407, DateTimeKind.Utc).AddTicks(8383), new DateTime(2024, 8, 12, 12, 23, 40, 407, DateTimeKind.Utc).AddTicks(8383) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 12, 12, 23, 40, 991, DateTimeKind.Utc).AddTicks(100), new DateTime(2024, 8, 12, 12, 23, 40, 407, DateTimeKind.Utc).AddTicks(8383) });
        }
    }
}
