using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeterinerKlinik.Migrations
{
    /// <inheritdoc />
    public partial class VeterinerIsimDuzelt2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Veterinerler",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ad",
                value: "Vet. Hek. Ahmet");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Veterinerler",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ad",
                value: "Vet .Hek. Ahmet");
        }
    }
}
