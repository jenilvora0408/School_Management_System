using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasForgottenPassword",
                table: "Users",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEligibleForResetPassword",
                table: "Users",
                type: "boolean",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998), new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998), new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998), new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998), new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998), new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998), new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998), new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998), new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "HasForgottenPassword", "IsEligibleForResetPassword", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 10, 6, 12, 22, 955, DateTimeKind.Utc).AddTicks(1286), null, null, new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasForgottenPassword",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsEligibleForResetPassword",
                table: "Users");

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
    }
}
