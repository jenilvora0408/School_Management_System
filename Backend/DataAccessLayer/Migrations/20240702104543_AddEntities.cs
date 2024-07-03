using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "AdmitRequests",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "MediumId",
                table: "AdmitRequests",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClassName = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    ClassStrength = table.Column<int>(type: "integer", nullable: true),
                    ClassTeacherId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Users_ClassTeacherId",
                        column: x => x.ClassTeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Classes_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Classes_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mediums",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "smallint", nullable: false),
                    Title = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mediums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubjectName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    SubjectTeacherId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subjects_Users_SubjectTeacherId",
                        column: x => x.SubjectTeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subjects_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentName = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: false),
                    ClassId = table.Column<int>(type: "integer", nullable: false),
                    MediumId = table.Column<byte>(type: "smallint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Mediums_MediumId",
                        column: x => x.MediumId,
                        principalTable: "Mediums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "ClassName", "ClassStrength", "ClassTeacherId", "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, "Class-11", 60, null, null, new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041), null, new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041) },
                    { 2, "Class-12", 120, null, null, new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041), null, new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041) }
                });

            migrationBuilder.InsertData(
                table: "Mediums",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { (byte)1, "English" },
                    { (byte)2, "Hindi" },
                    { (byte)3, "Gujarati" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "SubjectName", "SubjectTeacherId", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041), "Physics", null, null, new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041) },
                    { 2, null, new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041), "Chemistry", null, null, new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041) },
                    { 3, null, new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041), "Biology", null, null, new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041) },
                    { 4, null, new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041), "Maths", null, null, new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041) },
                    { 5, null, new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041), "Physics Practical", null, null, new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041) },
                    { 6, null, new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041), "Chemistry Practical", null, null, new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041) }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 2, 10, 45, 41, 295, DateTimeKind.Utc).AddTicks(1224), new DateTime(2024, 7, 2, 10, 45, 40, 811, DateTimeKind.Utc).AddTicks(3041) });

            migrationBuilder.CreateIndex(
                name: "IX_AdmitRequests_ClassId",
                table: "AdmitRequests",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmitRequests_MediumId",
                table: "AdmitRequests",
                column: "MediumId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ClassTeacherId",
                table: "Classes",
                column: "ClassTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CreatedBy",
                table: "Classes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_UpdatedBy",
                table: "Classes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CreatedBy",
                table: "Students",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Students_MediumId",
                table: "Students",
                column: "MediumId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UpdatedBy",
                table: "Students",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_CreatedBy",
                table: "Subjects",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SubjectTeacherId",
                table: "Subjects",
                column: "SubjectTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_UpdatedBy",
                table: "Subjects",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmitRequests_Classes_ClassId",
                table: "AdmitRequests",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmitRequests_Mediums_MediumId",
                table: "AdmitRequests",
                column: "MediumId",
                principalTable: "Mediums",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdmitRequests_Classes_ClassId",
                table: "AdmitRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmitRequests_Mediums_MediumId",
                table: "AdmitRequests");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Mediums");

            migrationBuilder.DropIndex(
                name: "IX_AdmitRequests_ClassId",
                table: "AdmitRequests");

            migrationBuilder.DropIndex(
                name: "IX_AdmitRequests_MediumId",
                table: "AdmitRequests");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "AdmitRequests");

            migrationBuilder.DropColumn(
                name: "MediumId",
                table: "AdmitRequests");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 6, 27, 10, 2, 24, 41, DateTimeKind.Utc).AddTicks(6091), new DateTime(2024, 6, 27, 10, 2, 23, 670, DateTimeKind.Utc).AddTicks(6400) });
        }
    }
}
