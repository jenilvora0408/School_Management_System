using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class BloodGroup_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_on", "updated_on" },
                values: new object[] { new DateTime(2024, 1, 16, 11, 27, 9, 323, DateTimeKind.Local).AddTicks(9813), new DateTime(2024, 1, 16, 5, 57, 8, 864, DateTimeKind.Utc).AddTicks(7015) });

            migrationBuilder.CreateIndex(
                name: "IX_admitRequest_blood_group",
                table: "admitRequest",
                column: "blood_group");

            migrationBuilder.AddForeignKey(
                name: "FK_admitRequest_bloodGroup_blood_group",
                table: "admitRequest",
                column: "blood_group",
                principalTable: "bloodGroup",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_admitRequest_bloodGroup_blood_group",
                table: "admitRequest");

            migrationBuilder.DropIndex(
                name: "IX_admitRequest_blood_group",
                table: "admitRequest");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_on", "updated_on" },
                values: new object[] { new DateTime(2024, 1, 16, 11, 10, 22, 582, DateTimeKind.Local).AddTicks(7862), new DateTime(2024, 1, 16, 5, 40, 22, 101, DateTimeKind.Utc).AddTicks(7364) });
        }
    }
}
