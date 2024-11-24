using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BevoBnB.Migrations
{
    /// <inheritdoc />
    public partial class CleaningFee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CleaningFee",
                table: "Reservations",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CleaningFee",
                table: "Reservations");
        }
    }
}
