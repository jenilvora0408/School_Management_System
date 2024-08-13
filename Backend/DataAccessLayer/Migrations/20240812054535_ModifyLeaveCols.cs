using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class ModifyLeaveCols : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeaveEndType",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "LeaveStartType",
                table: "Leaves");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LeaveEndType",
                table: "Leaves",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LeaveStartType",
                table: "Leaves",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 30, 10, 849, DateTimeKind.Utc).AddTicks(6009), new DateTime(2024, 7, 31, 8, 30, 10, 849, DateTimeKind.Utc).AddTicks(6009) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 30, 10, 849, DateTimeKind.Utc).AddTicks(6009), new DateTime(2024, 7, 31, 8, 30, 10, 849, DateTimeKind.Utc).AddTicks(6009) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 30, 10, 849, DateTimeKind.Utc).AddTicks(6009), new DateTime(2024, 7, 31, 8, 30, 10, 849, DateTimeKind.Utc).AddTicks(6009) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 30, 10, 849, DateTimeKind.Utc).AddTicks(6009), new DateTime(2024, 7, 31, 8, 30, 10, 849, DateTimeKind.Utc).AddTicks(6009) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 30, 10, 849, DateTimeKind.Utc).AddTicks(6009), new DateTime(2024, 7, 31, 8, 30, 10, 849, DateTimeKind.Utc).AddTicks(6009) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 30, 10, 849, DateTimeKind.Utc).AddTicks(6009), new DateTime(2024, 7, 31, 8, 30, 10, 849, DateTimeKind.Utc).AddTicks(6009) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 30, 10, 849, DateTimeKind.Utc).AddTicks(6009), new DateTime(2024, 7, 31, 8, 30, 10, 849, DateTimeKind.Utc).AddTicks(6009) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 30, 10, 849, DateTimeKind.Utc).AddTicks(6009), new DateTime(2024, 7, 31, 8, 30, 10, 849, DateTimeKind.Utc).AddTicks(6009) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 30, 11, 383, DateTimeKind.Utc).AddTicks(3387), new DateTime(2024, 7, 31, 8, 30, 10, 849, DateTimeKind.Utc).AddTicks(6009) });
        }
    }
}
