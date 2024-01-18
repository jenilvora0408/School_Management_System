using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class Gender_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_on", "updated_on" },
                values: new object[] { new DateTime(2024, 1, 16, 11, 10, 22, 582, DateTimeKind.Local).AddTicks(7862), new DateTime(2024, 1, 16, 5, 40, 22, 101, DateTimeKind.Utc).AddTicks(7364) });

            migrationBuilder.CreateIndex(
                name: "IX_admitRequest_gender",
                table: "admitRequest",
                column: "gender");

            migrationBuilder.AddForeignKey(
                name: "FK_admitRequest_gender_gender",
                table: "admitRequest",
                column: "gender",
                principalTable: "gender",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_admitRequest_gender_gender",
                table: "admitRequest");

            migrationBuilder.DropIndex(
                name: "IX_admitRequest_gender",
                table: "admitRequest");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_on", "updated_on" },
                values: new object[] { new DateTime(2024, 1, 16, 10, 48, 34, 366, DateTimeKind.Local).AddTicks(3044), new DateTime(2024, 1, 16, 5, 18, 33, 915, DateTimeKind.Utc).AddTicks(486) });
        }
    }
}
