using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseServerTest.Migrations
{
    /// <inheritdoc />
    public partial class CreateClassifiedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassifiedUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRegistered = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassifiedUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassifiedAds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassifiedAds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassifiedAds_ClassifiedUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ClassifiedUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassifiedMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    ClassifiedAdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassifiedMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassifiedMessages_ClassifiedAds_ClassifiedAdId",
                        column: x => x.ClassifiedAdId,
                        principalTable: "ClassifiedAds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassifiedMessages_ClassifiedUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "ClassifiedUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassifiedMessages_ClassifiedUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "ClassifiedUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 27, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 27, 14, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 29, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 29, 11, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 28, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 28, 8, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 27, 1, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 27, 1, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedAds_UserId",
                table: "ClassifiedAds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedMessages_ClassifiedAdId",
                table: "ClassifiedMessages",
                column: "ClassifiedAdId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedMessages_ReceiverId",
                table: "ClassifiedMessages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedMessages_SenderId",
                table: "ClassifiedMessages",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassifiedMessages");

            migrationBuilder.DropTable(
                name: "ClassifiedAds");

            migrationBuilder.DropTable(
                name: "ClassifiedUsers");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 21, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 21, 14, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 23, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 23, 11, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 22, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 22, 8, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 21, 1, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 21, 1, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
