using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddLeaveEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ApprovalFromUserId = table.Column<long>(type: "bigint", nullable: false),
                    ReasonForLeave = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LeaveStartType = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    LeaveEndType = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    LeaveDuration = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    LeaveType = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    AvailabilityOnPhone = table.Column<bool>(type: "boolean", nullable: true),
                    AlternatePhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leaves_Users_ApprovalFromUserId",
                        column: x => x.ApprovalFromUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Leaves_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Leaves_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Leaves_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170), new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170), new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170), new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170), new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170), new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170), new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170), new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170), new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 29, 9, 41, 42, 22, DateTimeKind.Utc).AddTicks(4256), new DateTime(2024, 7, 29, 9, 41, 41, 369, DateTimeKind.Utc).AddTicks(2170) });

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_ApprovalFromUserId",
                table: "Leaves",
                column: "ApprovalFromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_CreatedBy",
                table: "Leaves",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_UpdatedBy",
                table: "Leaves",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_UserId",
                table: "Leaves",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leaves");

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
        }
    }
}
