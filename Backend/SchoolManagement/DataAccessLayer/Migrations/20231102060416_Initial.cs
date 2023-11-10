using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bloodGroup",
                columns: table => new
                {
                    id = table.Column<byte>(type: "tinyint", nullable: false),
                    blood_group = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bloodGroup", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "gender",
                columns: table => new
                {
                    id = table.Column<byte>(type: "tinyint", nullable: false),
                    gender = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gender", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "userRole",
                columns: table => new
                {
                    id = table.Column<byte>(type: "tinyint", nullable: false),
                    role = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRole", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "varchar(18)", maxLength: 18, nullable: false),
                    last_name = table.Column<string>(type: "varchar(18)", maxLength: 18, nullable: false),
                    email = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    password = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    headline = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    phone_number = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    address = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    role = table.Column<byte>(type: "tinyint", nullable: false),
                    principal_id = table.Column<long>(type: "bigint", nullable: true),
                    lab_instructor_id = table.Column<long>(type: "bigint", nullable: true),
                    teacher_id = table.Column<long>(type: "bigint", nullable: true),
                    gender = table.Column<byte>(type: "tinyint", nullable: false),
                    avatar = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false),
                    otp = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: true),
                    expiry_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    blood_group = table.Column<byte>(type: "tinyint", nullable: false),
                    deleted_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    suspended_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    suspended_by = table.Column<long>(type: "bigint", nullable: true),
                    suspended_duration = table.Column<int>(type: "int", nullable: true),
                    is_user_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_user_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_bloodGroup_blood_group",
                        column: x => x.blood_group,
                        principalTable: "bloodGroup",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_gender_gender",
                        column: x => x.gender,
                        principalTable: "gender",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_user_created_by",
                        column: x => x.created_by,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_user_user_deleted_by",
                        column: x => x.deleted_by,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_user_user_lab_instructor_id",
                        column: x => x.lab_instructor_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_user_principal_id",
                        column: x => x.principal_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_user_suspended_by",
                        column: x => x.suspended_by,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_user_user_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_user_updated_by",
                        column: x => x.updated_by,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_user_userRole_role",
                        column: x => x.role,
                        principalTable: "userRole",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "admitRequest",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "varchar(18)", maxLength: 18, nullable: false),
                    last_name = table.Column<string>(type: "varchar(18)", maxLength: 18, nullable: false),
                    email = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    phone_number = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    address = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<byte>(type: "tinyint", nullable: false),
                    avatar = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false),
                    blood_group = table.Column<byte>(type: "tinyint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admitRequest", x => x.id);
                    table.ForeignKey(
                        name: "FK_admitRequest_user_created_by",
                        column: x => x.created_by,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_admitRequest_user_updated_by",
                        column: x => x.updated_by,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "admitRequestApproval",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    admit_request_id = table.Column<long>(type: "bigint", nullable: false),
                    approval_status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)3),
                    column = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true),
                    approved_by = table.Column<long>(type: "bigint", nullable: false),
                    declined_by = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admitRequestApproval", x => x.id);
                    table.ForeignKey(
                        name: "FK_admitRequestApproval_admitRequest_admit_request_id",
                        column: x => x.admit_request_id,
                        principalTable: "admitRequest",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_admitRequestApproval_user_approved_by",
                        column: x => x.approved_by,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_admitRequestApproval_user_declined_by",
                        column: x => x.declined_by,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "bloodGroup",
                columns: new[] { "id", "blood_group" },
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
                table: "gender",
                columns: new[] { "id", "gender" },
                values: new object[,]
                {
                    { (byte)1, "Male" },
                    { (byte)2, "Female" },
                    { (byte)3, "Other" }
                });

            migrationBuilder.InsertData(
                table: "userRole",
                columns: new[] { "id", "role" },
                values: new object[,]
                {
                    { (byte)1, "Principal" },
                    { (byte)2, "Teacher" },
                    { (byte)3, "Student" },
                    { (byte)4, "LabInstructor" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "address", "avatar", "blood_group", "created_by", "created_on", "dob", "deleted_by", "deleted_on", "email", "expiry_time", "first_name", "gender", "headline", "lab_instructor_id", "last_name", "otp", "password", "phone_number", "principal_id", "role", "suspended_by", "suspended_duration", "suspended_on", "teacher_id", "updated_by", "updated_on" },
                values: new object[] { 1L, "St. Mary's School Top Floor, Besides Wockhardt Hospital", "/images/Principal-photo.jpg", (byte)5, null, new DateTime(2023, 11, 2, 11, 34, 16, 602, DateTimeKind.Local).AddTicks(158), new DateTime(1976, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "anurag@gmail.com", null, "Anurag", (byte)1, "Principal since 2010", null, "Patwardhan", null, "$2a$10$KrAm5ughTCf8bUKjZlr.SeKmffzR7tzgwMQ9fdaVxCX5uktNo19D2", "8957486525", null, (byte)1, null, null, null, null, null, new DateTime(2023, 11, 2, 6, 4, 16, 171, DateTimeKind.Utc).AddTicks(8898) });

            migrationBuilder.CreateIndex(
                name: "IX_admitRequest_created_by",
                table: "admitRequest",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_admitRequest_email",
                table: "admitRequest",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_admitRequest_updated_by",
                table: "admitRequest",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "IX_admitRequestApproval_admit_request_id",
                table: "admitRequestApproval",
                column: "admit_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_admitRequestApproval_approved_by",
                table: "admitRequestApproval",
                column: "approved_by");

            migrationBuilder.CreateIndex(
                name: "IX_admitRequestApproval_declined_by",
                table: "admitRequestApproval",
                column: "declined_by");

            migrationBuilder.CreateIndex(
                name: "IX_user_blood_group",
                table: "user",
                column: "blood_group");

            migrationBuilder.CreateIndex(
                name: "IX_user_created_by",
                table: "user",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_user_deleted_by",
                table: "user",
                column: "deleted_by");

            migrationBuilder.CreateIndex(
                name: "IX_user_email",
                table: "user",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_gender",
                table: "user",
                column: "gender");

            migrationBuilder.CreateIndex(
                name: "IX_user_lab_instructor_id",
                table: "user",
                column: "lab_instructor_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_principal_id",
                table: "user",
                column: "principal_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_role",
                table: "user",
                column: "role");

            migrationBuilder.CreateIndex(
                name: "IX_user_suspended_by",
                table: "user",
                column: "suspended_by");

            migrationBuilder.CreateIndex(
                name: "IX_user_teacher_id",
                table: "user",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_updated_by",
                table: "user",
                column: "updated_by");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admitRequestApproval");

            migrationBuilder.DropTable(
                name: "admitRequest");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "bloodGroup");

            migrationBuilder.DropTable(
                name: "gender");

            migrationBuilder.DropTable(
                name: "userRole");
        }
    }
}
