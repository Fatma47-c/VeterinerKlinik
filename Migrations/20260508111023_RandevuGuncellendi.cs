using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeterinerKlinik.Migrations
{
    /// <inheritdoc />
    public partial class RandevuGuncellendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HayvanCinsi",
                table: "Randevular",
                newName: "HayvanKategorisi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HayvanKategorisi",
                table: "Randevular",
                newName: "HayvanCinsi");
        }
    }
}
