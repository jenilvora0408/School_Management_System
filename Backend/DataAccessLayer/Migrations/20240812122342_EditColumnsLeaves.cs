using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class EditColumnsLeaves : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailabilityOnPhone",
                table: "Leaves");

            migrationBuilder.AlterColumn<string>(
                name: "LeaveType",
                table: "Leaves",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LeaveType",
                table: "Leaves",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<bool>(
                name: "AvailabilityOnPhone",
                table: "Leaves",
                type: "boolean",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 12, 5, 45, 32, 218, DateTimeKind.Utc).AddTicks(2849), new DateTime(2024, 8, 12, 5, 45, 32, 218, DateTimeKind.Utc).AddTicks(2849) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 12, 5, 45, 32, 218, DateTimeKind.Utc).AddTicks(2849), new DateTime(2024, 8, 12, 5, 45, 32, 218, DateTimeKind.Utc).AddTicks(2849) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 12, 5, 45, 32, 218, DateTimeKind.Utc).AddTicks(2849), new DateTime(2024, 8, 12, 5, 45, 32, 218, DateTimeKind.Utc).AddTicks(2849) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 12, 5, 45, 32, 218, DateTimeKind.Utc).AddTicks(2849), new DateTime(2024, 8, 12, 5, 45, 32, 218, DateTimeKind.Utc).AddTicks(2849) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 12, 5, 45, 32, 218, DateTimeKind.Utc).AddTicks(2849), new DateTime(2024, 8, 12, 5, 45, 32, 218, DateTimeKind.Utc).AddTicks(2849) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 12, 5, 45, 32, 218, DateTimeKind.Utc).AddTicks(2849), new DateTime(2024, 8, 12, 5, 45, 32, 218, DateTimeKind.Utc).AddTicks(2849) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 12, 5, 45, 32, 218, DateTimeKind.Utc).AddTicks(2849), new DateTime(2024, 8, 12, 5, 45, 32, 218, DateTimeKind.Utc).AddTicks(2849) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 12, 5, 45, 32, 218, DateTimeKind.Utc).AddTicks(2849), new DateTime(2024, 8, 12, 5, 45, 32, 218, DateTimeKind.Utc).AddTicks(2849) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 12, 5, 45, 32, 786, DateTimeKind.Utc).AddTicks(2182), new DateTime(2024, 8, 12, 5, 45, 32, 218, DateTimeKind.Utc).AddTicks(2849) });
        }
    }
}
