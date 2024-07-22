using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AdmitRequestAddColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdmitRequestApprovals");

            migrationBuilder.AddColumn<byte>(
                name: "ApprovalStatus",
                table: "AdmitRequests",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ApprovedBy",
                table: "AdmitRequests",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "AdmitRequests",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeclinedBy",
                table: "AdmitRequests",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207), new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207), new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207), new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207), new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207), new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207), new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207), new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207), new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 19, 12, 37, 51, 983, DateTimeKind.Utc).AddTicks(9305), new DateTime(2024, 7, 19, 12, 37, 51, 517, DateTimeKind.Utc).AddTicks(8207) });

            migrationBuilder.CreateIndex(
                name: "IX_AdmitRequests_ApprovedBy",
                table: "AdmitRequests",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AdmitRequests_DeclinedBy",
                table: "AdmitRequests",
                column: "DeclinedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmitRequests_Users_ApprovedBy",
                table: "AdmitRequests",
                column: "ApprovedBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmitRequests_Users_DeclinedBy",
                table: "AdmitRequests",
                column: "DeclinedBy",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdmitRequests_Users_ApprovedBy",
                table: "AdmitRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmitRequests_Users_DeclinedBy",
                table: "AdmitRequests");

            migrationBuilder.DropIndex(
                name: "IX_AdmitRequests_ApprovedBy",
                table: "AdmitRequests");

            migrationBuilder.DropIndex(
                name: "IX_AdmitRequests_DeclinedBy",
                table: "AdmitRequests");

            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "AdmitRequests");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "AdmitRequests");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "AdmitRequests");

            migrationBuilder.DropColumn(
                name: "DeclinedBy",
                table: "AdmitRequests");

            migrationBuilder.CreateTable(
                name: "AdmitRequestApprovals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdmitRequestId = table.Column<long>(type: "bigint", nullable: false),
                    ApprovedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeclinedBy = table.Column<long>(type: "bigint", nullable: true),
                    ApprovalStatus = table.Column<byte>(type: "smallint", nullable: false, defaultValue: (byte)1),
                    Comment = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
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

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998), new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998), new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998), new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998), new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998), new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998), new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998), new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998), new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 10, 6, 12, 22, 955, DateTimeKind.Utc).AddTicks(1286), new DateTime(2024, 7, 10, 6, 12, 22, 497, DateTimeKind.Utc).AddTicks(3998) });

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
        }
    }
}
