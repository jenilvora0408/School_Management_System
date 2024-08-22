using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addEntityClassSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassIds",
                table: "Subjects");

            migrationBuilder.CreateTable(
                name: "ClassSubject",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "integer", nullable: false),
                    SubjectId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSubject", x => new { x.ClassId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_ClassSubject_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassSubject_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassSubject_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClassSubject_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 55, 34, 307, DateTimeKind.Utc).AddTicks(2068), new DateTime(2024, 8, 21, 5, 55, 34, 307, DateTimeKind.Utc).AddTicks(2068) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 55, 34, 307, DateTimeKind.Utc).AddTicks(2068), new DateTime(2024, 8, 21, 5, 55, 34, 307, DateTimeKind.Utc).AddTicks(2068) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 55, 34, 307, DateTimeKind.Utc).AddTicks(2068), new DateTime(2024, 8, 21, 5, 55, 34, 307, DateTimeKind.Utc).AddTicks(2068) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 55, 34, 307, DateTimeKind.Utc).AddTicks(2068), new DateTime(2024, 8, 21, 5, 55, 34, 307, DateTimeKind.Utc).AddTicks(2068) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 55, 34, 307, DateTimeKind.Utc).AddTicks(2068), new DateTime(2024, 8, 21, 5, 55, 34, 307, DateTimeKind.Utc).AddTicks(2068) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 55, 34, 307, DateTimeKind.Utc).AddTicks(2068), new DateTime(2024, 8, 21, 5, 55, 34, 307, DateTimeKind.Utc).AddTicks(2068) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 55, 34, 307, DateTimeKind.Utc).AddTicks(2068), new DateTime(2024, 8, 21, 5, 55, 34, 307, DateTimeKind.Utc).AddTicks(2068) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 55, 34, 307, DateTimeKind.Utc).AddTicks(2068), new DateTime(2024, 8, 21, 5, 55, 34, 307, DateTimeKind.Utc).AddTicks(2068) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 55, 34, 904, DateTimeKind.Utc).AddTicks(7367), new DateTime(2024, 8, 21, 5, 55, 34, 307, DateTimeKind.Utc).AddTicks(2068) });

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubject_CreatedBy",
                table: "ClassSubject",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubject_SubjectId",
                table: "ClassSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubject_UpdatedBy",
                table: "ClassSubject",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassSubject");

            migrationBuilder.AddColumn<int[]>(
                name: "ClassIds",
                table: "Subjects",
                type: "integer[]",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437), new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437), new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClassIds", "CreatedOn", "UpdatedOn" },
                values: new object[] { null, new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437), new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClassIds", "CreatedOn", "UpdatedOn" },
                values: new object[] { null, new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437), new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClassIds", "CreatedOn", "UpdatedOn" },
                values: new object[] { null, new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437), new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ClassIds", "CreatedOn", "UpdatedOn" },
                values: new object[] { null, new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437), new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ClassIds", "CreatedOn", "UpdatedOn" },
                values: new object[] { null, new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437), new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ClassIds", "CreatedOn", "UpdatedOn" },
                values: new object[] { null, new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437), new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 43, 42, 940, DateTimeKind.Utc).AddTicks(6684), new DateTime(2024, 8, 21, 5, 43, 42, 329, DateTimeKind.Utc).AddTicks(5437) });
        }
    }
}
