using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class AppDb_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "declined_by",
                table: "admitRequestApproval",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "approved_by",
                table: "admitRequestApproval",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_on", "updated_on" },
                values: new object[] { new DateTime(2023, 11, 20, 12, 5, 55, 836, DateTimeKind.Local).AddTicks(2413), new DateTime(2023, 11, 20, 6, 35, 55, 230, DateTimeKind.Utc).AddTicks(8767) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "declined_by",
                table: "admitRequestApproval",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "approved_by",
                table: "admitRequestApproval",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_on", "updated_on" },
                values: new object[] { new DateTime(2023, 11, 20, 12, 1, 40, 535, DateTimeKind.Local).AddTicks(9565), new DateTime(2023, 11, 20, 6, 31, 39, 990, DateTimeKind.Utc).AddTicks(3286) });
        }
    }
}
