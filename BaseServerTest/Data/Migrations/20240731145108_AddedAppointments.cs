using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BaseServerTest.Migrations
{
    /// <inheritdoc />
    public partial class AddedAppointments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AllDay = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "AllDay", "Caption", "EndDate", "Label", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, false, "Šišanje", new DateTime(2024, 7, 31, 16, 30, 0, 0, DateTimeKind.Local), 1, new DateTime(2024, 7, 31, 14, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 2, false, "Kod mehaničara", new DateTime(2024, 8, 2, 13, 30, 0, 0, DateTimeKind.Local), 6, new DateTime(2024, 8, 2, 11, 30, 0, 0, DateTimeKind.Local), 1 },
                    { 3, false, "Šetnja sa patikama", new DateTime(2024, 8, 1, 8, 30, 0, 0, DateTimeKind.Local), 2, new DateTime(2024, 8, 1, 8, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 4, false, "Gledanje u Mesec", new DateTime(2024, 7, 31, 1, 30, 0, 0, DateTimeKind.Local), 3, new DateTime(2024, 7, 31, 1, 0, 0, 0, DateTimeKind.Local), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");
        }
    }
}
