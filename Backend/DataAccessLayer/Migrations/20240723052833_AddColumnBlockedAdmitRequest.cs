using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnBlockedAdmitRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasForgottenPassword",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsEligibleForResetPassword",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "AdmitRequests",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApprovalStatus",
                table: "AdmitRequests",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(byte),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BlockedBy",
                table: "AdmitRequests",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 23, 5, 28, 29, 685, DateTimeKind.Utc).AddTicks(6516), new DateTime(2024, 7, 23, 5, 28, 29, 685, DateTimeKind.Utc).AddTicks(6516) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 23, 5, 28, 29, 685, DateTimeKind.Utc).AddTicks(6516), new DateTime(2024, 7, 23, 5, 28, 29, 685, DateTimeKind.Utc).AddTicks(6516) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 23, 5, 28, 29, 685, DateTimeKind.Utc).AddTicks(6516), new DateTime(2024, 7, 23, 5, 28, 29, 685, DateTimeKind.Utc).AddTicks(6516) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 23, 5, 28, 29, 685, DateTimeKind.Utc).AddTicks(6516), new DateTime(2024, 7, 23, 5, 28, 29, 685, DateTimeKind.Utc).AddTicks(6516) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 23, 5, 28, 29, 685, DateTimeKind.Utc).AddTicks(6516), new DateTime(2024, 7, 23, 5, 28, 29, 685, DateTimeKind.Utc).AddTicks(6516) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 23, 5, 28, 29, 685, DateTimeKind.Utc).AddTicks(6516), new DateTime(2024, 7, 23, 5, 28, 29, 685, DateTimeKind.Utc).AddTicks(6516) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 23, 5, 28, 29, 685, DateTimeKind.Utc).AddTicks(6516), new DateTime(2024, 7, 23, 5, 28, 29, 685, DateTimeKind.Utc).AddTicks(6516) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 23, 5, 28, 29, 685, DateTimeKind.Utc).AddTicks(6516), new DateTime(2024, 7, 23, 5, 28, 29, 685, DateTimeKind.Utc).AddTicks(6516) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 23, 5, 28, 30, 347, DateTimeKind.Utc).AddTicks(5127), new DateTime(2024, 7, 23, 5, 28, 29, 685, DateTimeKind.Utc).AddTicks(6516) });

            migrationBuilder.CreateIndex(
                name: "IX_AdmitRequests_BlockedBy",
                table: "AdmitRequests",
                column: "BlockedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmitRequests_Users_BlockedBy",
                table: "AdmitRequests",
                column: "BlockedBy",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdmitRequests_Users_BlockedBy",
                table: "AdmitRequests");

            migrationBuilder.DropIndex(
                name: "IX_AdmitRequests_BlockedBy",
                table: "AdmitRequests");

            migrationBuilder.DropColumn(
                name: "BlockedBy",
                table: "AdmitRequests");

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

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "AdmitRequests",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "ApprovalStatus",
                table: "AdmitRequests",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1);

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207), new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207), new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207), new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207), new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207), new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207), new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207), new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207), new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "HasForgottenPassword", "IsEligibleForResetPassword", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 19, 12, 37, 51, 983, DateTimeKind.Utc).AddTicks(9305), null, null, new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207) });
        }
    }
}
