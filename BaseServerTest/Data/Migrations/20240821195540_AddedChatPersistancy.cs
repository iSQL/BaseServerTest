using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseServerTest.Migrations
{
    /// <inheritdoc />
    public partial class AddedChatPersistancy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 31, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 31, 14, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 2, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 2, 11, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 1, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 1, 8, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 31, 1, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 31, 1, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
