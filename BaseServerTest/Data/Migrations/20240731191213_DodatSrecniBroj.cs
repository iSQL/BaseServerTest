using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseServerTest.Migrations
{
    /// <inheritdoc />
    public partial class DodatSrecniBroj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LuckyNumber",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LuckyNumber",
                table: "AspNetUsers");
        }
    }
}
