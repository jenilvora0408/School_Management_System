using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddReasonForBlockColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReasonForBlock",
                table: "AdmitRequests",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReasonForBlock",
                table: "AdmitRequests");

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
    }
}
