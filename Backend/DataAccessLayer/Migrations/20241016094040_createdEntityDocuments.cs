using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class createdEntityDocuments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestDate",
                table: "ContactPrincipal",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 16, 9, 40, 38, 331, DateTimeKind.Utc).AddTicks(2051),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 10, 16, 4, 51, 22, 227, DateTimeKind.Utc).AddTicks(8458));

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocumentContent = table.Column<string>(type: "text", nullable: false),
                    UseDocumentFor = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    ContactPrincipalId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_ContactPrincipal_ContactPrincipalId",
                        column: x => x.ContactPrincipalId,
                        principalTable: "ContactPrincipal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 9, 40, 38, 333, DateTimeKind.Utc).AddTicks(431), new DateTime(2024, 10, 16, 9, 40, 37, 588, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ContactPrincipalId",
                table: "Documents",
                column: "ContactPrincipalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestDate",
                table: "ContactPrincipal",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 16, 4, 51, 22, 227, DateTimeKind.Utc).AddTicks(8458),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 10, 16, 9, 40, 38, 331, DateTimeKind.Utc).AddTicks(2051));

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 16, 4, 51, 22, 229, DateTimeKind.Utc).AddTicks(553), new DateTime(2024, 10, 16, 4, 51, 21, 616, DateTimeKind.Utc).AddTicks(1700) });
        }
    }
}
