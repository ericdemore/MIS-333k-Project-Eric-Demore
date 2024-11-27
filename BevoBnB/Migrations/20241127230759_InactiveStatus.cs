using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BevoBnB.Migrations
{
    /// <inheritdoc />
    public partial class InactiveStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Categories_CategoryID",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Properties",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_CategoryID",
                table: "Properties",
                newName: "IX_Properties_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Categories_CategoryId",
                table: "Properties",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Categories_CategoryId",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Properties",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_CategoryId",
                table: "Properties",
                newName: "IX_Properties_CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Categories_CategoryID",
                table: "Properties",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
