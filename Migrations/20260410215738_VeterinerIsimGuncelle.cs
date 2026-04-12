using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeterinerKlinik.Migrations
{
    /// <inheritdoc />
    public partial class VeterinerIsimGuncelle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Veterinerler",
                keyColumn: "Id",
                keyValue: 1,
                column: "Ad",
                value: "Uzm. Vet .Hek. Selin");

            migrationBuilder.UpdateData(
                table: "Veterinerler",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ad",
                value: "Vet. Hek. Ahmet");

            migrationBuilder.UpdateData(
                table: "Veterinerler",
                keyColumn: "Id",
                keyValue: 3,
                column: "Ad",
                value: "Dr. Med. Vet. Murat");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Veterinerler",
                keyColumn: "Id",
                keyValue: 1,
                column: "Ad",
                value: "Uzm.Vet.Hek. Selin");

            migrationBuilder.UpdateData(
                table: "Veterinerler",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ad",
                value: "Vet.Hek. Ahmet");

            migrationBuilder.UpdateData(
                table: "Veterinerler",
                keyColumn: "Id",
                keyValue: 3,
                column: "Ad",
                value: "Dr.Med.Vet. Murat");
        }
    }
}
