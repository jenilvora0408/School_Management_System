using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class Column_Update_Admit_Request_Approval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "column",
                table: "admitRequestApproval",
                newName: "comment");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_on", "updated_on" },
                values: new object[] { new DateTime(2023, 11, 20, 12, 1, 40, 535, DateTimeKind.Local).AddTicks(9565), new DateTime(2023, 11, 20, 6, 31, 39, 990, DateTimeKind.Utc).AddTicks(3286) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "comment",
                table: "admitRequestApproval",
                newName: "column");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_on", "updated_on" },
                values: new object[] { new DateTime(2023, 11, 3, 10, 40, 41, 548, DateTimeKind.Local).AddTicks(3373), new DateTime(2023, 11, 3, 5, 10, 41, 69, DateTimeKind.Utc).AddTicks(1125) });
        }
    }
}
