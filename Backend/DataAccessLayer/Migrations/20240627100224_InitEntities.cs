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
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GenderId = table.Column<byte>(type: "smallint", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: false),
                    BloodGroupId = table.Column<byte>(type: "smallint", nullable: false),
                    AdmitRequestRoleId = table.Column<byte>(type: "smallint", nullable: false),
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
                        name: "FK_AdmitRequests_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdmitRequests_UserRoles_AdmitRequestRoleId",
                        column: x => x.AdmitRequestRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdmitRequests_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdmitRequests_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdmitRequestApprovals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdmitRequestId = table.Column<long>(type: "bigint", nullable: false),
                    ApprovalStatus = table.Column<byte>(type: "smallint", nullable: false, defaultValue: (byte)1),
                    Comment = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    ApprovedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeclinedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmitRequestApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdmitRequestApprovals_AdmitRequests_AdmitRequestId",
                        column: x => x.AdmitRequestId,
                        principalTable: "AdmitRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdmitRequestApprovals_Users_ApprovedBy",
                        column: x => x.ApprovedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdmitRequestApprovals_Users_DeclinedBy",
                        column: x => x.DeclinedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                table: "Genders",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { (byte)1, "Male" },
                    { (byte)2, "Female" }
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
                table: "Users",
                columns: new[] { "Id", "Address", "Avatar", "BloodGroupId", "CreatedBy", "CreatedOn", "DateOfBirth", "DeletedBy", "DeletedOn", "Email", "ExpiryTime", "FirstName", "GenderId", "Headline", "LabInstructorId", "LastName", "OTP", "Password", "PhoneNumber", "PrincipalId", "RoleId", "SuspendedBy", "SuspendedDuration", "SuspendedOn", "TeacherId", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 1L, "St. Mary's School Top Floor, Besides Wockhardt Hospital", "/images/Principal-photo.jpg", (byte)5, null, new DateTime(2024, 6, 27, 10, 2, 24, 41, DateTimeKind.Utc).AddTicks(6091), null, null, null, "anurag@gmail.com", null, "Anurag", (byte)1, "Principal since 2010", null, "Patwardhan", null, "$2a$10$KrAm5ughTCf8bUKjZlr.SeKmffzR7tzgwMQ9fdaVxCX5uktNo19D2", "8957486525", null, (byte)1, null, null, null, null, null, new DateTime(2024, 6, 27, 10, 2, 23, 670, DateTimeKind.Utc).AddTicks(6400) });

            migrationBuilder.CreateIndex(
                name: "IX_AdmitRequestApprovals_AdmitRequestId",
                table: "AdmitRequestApprovals",
                column: "AdmitRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmitRequestApprovals_ApprovedBy",
                table: "AdmitRequestApprovals",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AdmitRequestApprovals_DeclinedBy",
                table: "AdmitRequestApprovals",
                column: "DeclinedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AdmitRequests_AdmitRequestRoleId",
                table: "AdmitRequests",
                column: "AdmitRequestRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmitRequests_BloodGroupId",
                table: "AdmitRequests",
                column: "BloodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmitRequests_CreatedBy",
                table: "AdmitRequests",
                column: "CreatedBy");

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
                name: "IX_AdmitRequests_UpdatedBy",
                table: "AdmitRequests",
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
                name: "AdmitRequestApprovals");

            migrationBuilder.DropTable(
                name: "AdmitRequests");

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
