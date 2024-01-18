using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class AdmitRequestRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "admit_request_role",
                table: "admitRequest",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_on", "updated_on" },
                values: new object[] { new DateTime(2024, 1, 16, 10, 48, 34, 366, DateTimeKind.Local).AddTicks(3044), new DateTime(2024, 1, 16, 5, 18, 33, 915, DateTimeKind.Utc).AddTicks(486) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "admit_request_role",
                table: "admitRequest");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_on", "updated_on" },
                values: new object[] { new DateTime(2023, 11, 20, 12, 5, 55, 836, DateTimeKind.Local).AddTicks(2413), new DateTime(2023, 11, 20, 6, 35, 55, 230, DateTimeKind.Utc).AddTicks(8767) });
        }
    }
}
