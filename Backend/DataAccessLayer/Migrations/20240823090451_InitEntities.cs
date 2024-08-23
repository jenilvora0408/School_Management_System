using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodGroups",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "smallint", nullable: false),
                    Title = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "smallint", nullable: false),
                    Title = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
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
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "smallint", nullable: false),
                    Title = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: false),
                    LastName = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: false),
                    Email = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Password = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Headline = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    Address = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RoleId = table.Column<byte>(type: "smallint", nullable: false),
                    PrincipalId = table.Column<long>(type: "bigint", nullable: true),
                    LabInstructorId = table.Column<long>(type: "bigint", nullable: true),
                    TeacherId = table.Column<long>(type: "bigint", nullable: true),
                    GenderId = table.Column<byte>(type: "smallint", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: false),
                    OTP = table.Column<string>(type: "text", nullable: true),
                    ExpiryTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    BloodGroupId = table.Column<byte>(type: "smallint", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    SuspendedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SuspendedBy = table.Column<long>(type: "bigint", nullable: true),
                    SuspendedDuration = table.Column<int>(type: "integer", nullable: true),
                    IsUserActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsUserDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_BloodGroups_BloodGroupId",
                        column: x => x.BloodGroupId,
                        principalTable: "BloodGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_LabInstructorId",
                        column: x => x.LabInstructorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_PrincipalId",
                        column: x => x.PrincipalId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_SuspendedBy",
                        column: x => x.SuspendedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

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
                name: "Leaves",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ApprovalFromUserId = table.Column<long>(type: "bigint", nullable: false),
                    ReasonForLeave = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ApprovalStatus = table.Column<byte>(type: "smallint", nullable: false, defaultValue: (byte)1),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LeaveDuration = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    LeaveType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
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
                name: "AdmitRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: false),
                    LastName = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: false),
                    Email = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GenderId = table.Column<byte>(type: "smallint", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: true),
                    BloodGroupId = table.Column<byte>(type: "smallint", nullable: false),
                    AdmitRequestRoleId = table.Column<byte>(type: "smallint", nullable: false),
                    ClassId = table.Column<int>(type: "integer", nullable: true),
                    MediumId = table.Column<byte>(type: "smallint", nullable: true),
                    ApprovalStatus = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    Comment = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ApprovedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeclinedBy = table.Column<long>(type: "bigint", nullable: true),
                    BlockedBy = table.Column<long>(type: "bigint", nullable: true),
                    ReasonForBlock = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmitRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdmitRequests_BloodGroups_BloodGroupId",
                        column: x => x.BloodGroupId,
                        principalTable: "BloodGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdmitRequests_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdmitRequests_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdmitRequests_Mediums_MediumId",
                        column: x => x.MediumId,
                        principalTable: "Mediums",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdmitRequests_UserRoles_AdmitRequestRoleId",
                        column: x => x.AdmitRequestRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdmitRequests_Users_ApprovedBy",
                        column: x => x.ApprovedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdmitRequests_Users_BlockedBy",
                        column: x => x.BlockedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdmitRequests_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdmitRequests_Users_DeclinedBy",
                        column: x => x.DeclinedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdmitRequests_Users_UpdatedBy",
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

            migrationBuilder.CreateTable(
                name: "ClassSubject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClassId = table.Column<int>(type: "integer", nullable: false),
                    SubjectId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSubject", x => x.Id);
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

            migrationBuilder.InsertData(
                table: "BloodGroups",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { (byte)1, "A+" },
                    { (byte)2, "A-" },
                    { (byte)3, "B+" },
                    { (byte)4, "B-" },
                    { (byte)5, "O+" },
                    { (byte)6, "O-" },
                    { (byte)7, "AB+" },
                    { (byte)8, "AB-" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "ClassName", "ClassStrength", "ClassTeacherId", "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, "Class-3", 60, null, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 2, "Class-4", 60, null, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 3, "Class-5", 60, null, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 4, "Class-6", 60, null, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 5, "Class-7", 80, null, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 6, "Class-8", 80, null, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 7, "Class-9", 80, null, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 8, "Class-10", 80, null, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 9, "Class-11", 100, null, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 10, "Class-12", 100, null, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { (byte)1, "Male" },
                    { (byte)2, "Female" }
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
                    { 1, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), "Physics", null, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 2, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), "Chemistry", null, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 3, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), "Biology", null, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 4, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), "Maths", null, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 5, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), "Physics Practical", null, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 6, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), "Chemistry Practical", null, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 7, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), "English", null, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 8, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), "English Grammar", null, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 9, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), "Environment", null, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 10, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), "History", null, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 11, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), "Science", null, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 12, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), "Computer", null, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { (byte)1, "Principal" },
                    { (byte)2, "Teacher" },
                    { (byte)3, "Student" },
                    { (byte)4, "Lab Instructor" }
                });

            migrationBuilder.InsertData(
                table: "ClassSubject",
                columns: new[] { "Id", "ClassId", "CreatedBy", "CreatedOn", "SubjectId", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), 7, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 2, 1, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), 8, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 3, 1, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), 4, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 4, 1, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), 11, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 5, 2, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), 7, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 6, 2, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), 8, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 7, 2, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), 4, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 8, 2, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), 11, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) },
                    { 9, 2, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460), 9, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Avatar", "BloodGroupId", "CreatedBy", "CreatedOn", "DateOfBirth", "DeletedBy", "DeletedOn", "Email", "ExpiryTime", "FirstName", "GenderId", "Headline", "LabInstructorId", "LastName", "OTP", "Password", "PhoneNumber", "PrincipalId", "RoleId", "SuspendedBy", "SuspendedDuration", "SuspendedOn", "TeacherId", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 1L, "St. Mary's School Top Floor, Besides Wockhardt Hospital", "/images/Principal-photo.jpg", (byte)5, null, new DateTime(2024, 8, 23, 9, 4, 48, 991, DateTimeKind.Utc).AddTicks(5867), null, null, null, "anurag@gmail.com", null, "Anurag", (byte)1, "Principal since 2010", null, "Patwardhan", null, "$2a$10$KrAm5ughTCf8bUKjZlr.SeKmffzR7tzgwMQ9fdaVxCX5uktNo19D2", "8957486525", null, (byte)1, null, null, null, null, null, new DateTime(2024, 8, 23, 9, 4, 48, 432, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.CreateIndex(
                name: "IX_AdmitRequests_AdmitRequestRoleId",
                table: "AdmitRequests",
                column: "AdmitRequestRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmitRequests_ApprovedBy",
                table: "AdmitRequests",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AdmitRequests_BlockedBy",
                table: "AdmitRequests",
                column: "BlockedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AdmitRequests_BloodGroupId",
                table: "AdmitRequests",
                column: "BloodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmitRequests_ClassId",
                table: "AdmitRequests",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmitRequests_CreatedBy",
                table: "AdmitRequests",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AdmitRequests_DeclinedBy",
                table: "AdmitRequests",
                column: "DeclinedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AdmitRequests_Email",
                table: "AdmitRequests",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdmitRequests_GenderId",
                table: "AdmitRequests",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmitRequests_MediumId",
                table: "AdmitRequests",
                column: "MediumId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmitRequests_UpdatedBy",
                table: "AdmitRequests",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubject_ClassId",
                table: "ClassSubject",
                column: "ClassId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_BloodGroupId",
                table: "Users",
                column: "BloodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedBy",
                table: "Users",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeletedBy",
                table: "Users",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderId",
                table: "Users",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LabInstructorId",
                table: "Users",
                column: "LabInstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PrincipalId",
                table: "Users",
                column: "PrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SuspendedBy",
                table: "Users",
                column: "SuspendedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeacherId",
                table: "Users",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UpdatedBy",
                table: "Users",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdmitRequests");

            migrationBuilder.DropTable(
                name: "ClassSubject");

            migrationBuilder.DropTable(
                name: "Leaves");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Mediums");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BloodGroups");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
