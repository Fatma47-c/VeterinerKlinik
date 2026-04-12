using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeterinerKlinik.Migrations
{
    /// <inheritdoc />
    public partial class HastalıkUcretEkle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hastalik",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Ucret",
                table: "Randevular",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Veterinerler",
                keyColumn: "Id",
                keyValue: 1,
                column: "UzmanlikAlani",
                value: "Küçük Hayvanlar");

            migrationBuilder.UpdateData(
                table: "Veterinerler",
                keyColumn: "Id",
                keyValue: 3,
                column: "UzmanlikAlani",
                value: "Egzotik Hayvanlar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hastalik",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "Ucret",
                table: "Randevular");

            migrationBuilder.UpdateData(
                table: "Veterinerler",
                keyColumn: "Id",
                keyValue: 1,
                column: "UzmanlikAlani",
                value: "Küçük Hayvanları");

            migrationBuilder.UpdateData(
                table: "Veterinerler",
                keyColumn: "Id",
                keyValue: 3,
                column: "UzmanlikAlani",
                value: "Egzotik Hayvanları");
        }
    }
}
