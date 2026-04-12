using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeterinerKlinik.Migrations
{
    /// <inheritdoc />
    public partial class KalitimEkle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HayvanTipi",
                table: "Hayvanlar",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HayvanTipi",
                table: "Hayvanlar");

            migrationBuilder.UpdateData(
                table: "Veterinerler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Ad", "UzmanlikAlani" },
                values: new object[] { "Uzm. Vet .Hek. Selin", "Küçük Hayvanlar" });

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
                columns: new[] { "Ad", "UzmanlikAlani" },
                values: new object[] { "Dr. Med. Vet. Murat", "Egzotik Hayvanlar" });
        }
    }
}
