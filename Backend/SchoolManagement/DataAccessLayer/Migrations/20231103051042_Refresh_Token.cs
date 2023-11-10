using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class Refresh_Token : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userRefreshToken",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    refresh_token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRefreshToken", x => x.id);
                    table.ForeignKey(
                        name: "FK_userRefreshToken_user_created_by",
                        column: x => x.created_by,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_userRefreshToken_user_updated_by",
                        column: x => x.updated_by,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_on", "updated_on" },
                values: new object[] { new DateTime(2023, 11, 3, 10, 40, 41, 548, DateTimeKind.Local).AddTicks(3373), new DateTime(2023, 11, 3, 5, 10, 41, 69, DateTimeKind.Utc).AddTicks(1125) });

            migrationBuilder.CreateIndex(
                name: "IX_userRefreshToken_created_by",
                table: "userRefreshToken",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_userRefreshToken_id",
                table: "userRefreshToken",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_userRefreshToken_updated_by",
                table: "userRefreshToken",
                column: "updated_by");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userRefreshToken");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_on", "updated_on" },
                values: new object[] { new DateTime(2023, 11, 2, 11, 34, 16, 602, DateTimeKind.Local).AddTicks(158), new DateTime(2023, 11, 2, 6, 4, 16, 171, DateTimeKind.Utc).AddTicks(8898) });
        }
    }
}
