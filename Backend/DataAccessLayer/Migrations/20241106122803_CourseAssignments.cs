using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class CourseAssignments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Documents",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestDate",
                table: "ContactPrincipal",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 6, 12, 28, 0, 513, DateTimeKind.Utc).AddTicks(5848),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 10, 25, 5, 51, 8, 927, DateTimeKind.Utc).AddTicks(8502));

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssignmentPublisherId = table.Column<long>(type: "bigint", nullable: false),
                    AssignmentTitle = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    AssignmentInstructions = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Deadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ClassSubjectId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_ClassSubject_ClassSubjectId",
                        column: x => x.ClassSubjectId,
                        principalTable: "ClassSubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignments_Users_AssignmentPublisherId",
                        column: x => x.AssignmentPublisherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignments_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Assignments_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChapterSerialNumber = table.Column<int>(type: "integer", nullable: false),
                    ChapterName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ClassSubjectId = table.Column<int>(type: "integer", nullable: false),
                    ProbableWeightageInExam = table.Column<int>(type: "integer", nullable: true),
                    ProbableDurationToTeach = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    IsOptionalToTeach = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    LearningObjectives = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_ClassSubject_ClassSubjectId",
                        column: x => x.ClassSubjectId,
                        principalTable: "ClassSubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courses_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AssignmentQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssignmentId = table.Column<int>(type: "integer", nullable: false),
                    Question = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TypeOfQuestion = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    MarksOfQuestion = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignmentQuestions_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 28, 0, 515, DateTimeKind.Utc).AddTicks(7385), new DateTime(2024, 11, 6, 12, 27, 59, 910, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CourseId",
                table: "Documents",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentQuestions_AssignmentId",
                table: "AssignmentQuestions",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssignmentPublisherId",
                table: "Assignments",
                column: "AssignmentPublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_ClassSubjectId",
                table: "Assignments",
                column: "ClassSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CreatedBy",
                table: "Assignments",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_UpdatedBy",
                table: "Assignments",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ClassSubjectId",
                table: "Courses",
                column: "ClassSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CreatedBy",
                table: "Courses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UpdatedBy",
                table: "Courses",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Courses_CourseId",
                table: "Documents",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Courses_CourseId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "AssignmentQuestions");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Documents_CourseId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Documents");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestDate",
                table: "ContactPrincipal",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 25, 5, 51, 8, 927, DateTimeKind.Utc).AddTicks(8502),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 11, 6, 12, 28, 0, 513, DateTimeKind.Utc).AddTicks(5848));

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "ClassSubject",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 25, 5, 51, 8, 929, DateTimeKind.Utc).AddTicks(3400), new DateTime(2024, 10, 25, 5, 51, 8, 313, DateTimeKind.Utc).AddTicks(4716) });
        }
    }
}
