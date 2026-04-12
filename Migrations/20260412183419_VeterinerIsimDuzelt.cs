using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeterinerKlinik.Migrations
{
    /// <inheritdoc />
    public partial class VeterinerIsimDuzelt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Veterinerler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Ad", "UzmanlikAlani" },
                values: new object[] { "Uzm. Vet. Hek. Selin", "Evcil Hayvanlar" });

            migrationBuilder.UpdateData(
                table: "Veterinerler",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ad",
                value: "Vet .Hek. Ahmet");

            migrationBuilder.UpdateData(
                table: "Veterinerler",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Ad", "UzmanlikAlani" },
                values: new object[] { "Dr. Med. Vet. Murat", "Egzotik Hayvanlar" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Veterinerler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Ad", "UzmanlikAlani" },
                values: new object[] { "Uzm.Vet.Hek. Selin", "Küçük Hayvanları" });

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
                columns: new[] { "Ad", "UzmanlikAlani" },
                values: new object[] { "Dr.Med.Vet. Murat", "Egzotik Hayvanları" });
        }
    }
}
