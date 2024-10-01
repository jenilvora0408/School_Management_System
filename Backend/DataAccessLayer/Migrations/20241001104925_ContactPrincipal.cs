using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class ContactPrincipal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "smallint", nullable: false),
                    ContactTitle = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactPrincipal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Subject = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    RequestDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 10, 1, 10, 49, 22, 959, DateTimeKind.Utc).AddTicks(1182)),
                    Type = table.Column<byte>(type: "smallint", nullable: false),
                    IsResolved = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    ResponseMessage = table.Column<string>(type: "character varying(2500)", maxLength: 2500, nullable: false),
                    RelatableEvidence = table.Column<string>(type: "text", nullable: true),
                    ContactTypeId = table.Column<byte>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPrincipal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactPrincipal_ContactTypes_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalTable: "ContactTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContactPrincipal_ContactTypes_Type",
                        column: x => x.Type,
                        principalTable: "ContactTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Id", "ContactTitle" },
                values: new object[,]
                {
                    { (byte)1, "Harassment" },
                    { (byte)2, "Awareness" },
                    { (byte)3, "Notice" },
                    { (byte)4, "ExternalHelp" },
                    { (byte)5, "Other" }
                });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 49, 22, 960, DateTimeKind.Utc).AddTicks(593), new DateTime(2024, 10, 1, 10, 49, 22, 349, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.CreateIndex(
                name: "IX_ContactPrincipal_ContactTypeId",
                table: "ContactPrincipal",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPrincipal_Type",
                table: "ContactPrincipal",
                column: "Type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactPrincipal");

            migrationBuilder.DropTable(
                name: "ContactTypes");

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 9, 6, 9, 33, 47, 579, DateTimeKind.Utc).AddTicks(4142), new DateTime(2024, 9, 6, 9, 33, 47, 5, DateTimeKind.Utc).AddTicks(3148) });
        }
    }
}
