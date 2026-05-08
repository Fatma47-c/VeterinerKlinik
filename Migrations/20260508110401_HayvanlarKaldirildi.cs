using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeterinerKlinik.Migrations
{
    /// <inheritdoc />
    public partial class HayvanlarKaldirildi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hayvanlar");

            migrationBuilder.CreateTable(
                name: "Hastaliklar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tedavi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ucret = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastaliklar", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hastaliklar");

            migrationBuilder.CreateTable(
                name: "Hayvanlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cins = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HayvanTipi = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Kategori = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MusteriAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yas = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hayvanlar", x => x.Id);
                });
        }
    }
}
