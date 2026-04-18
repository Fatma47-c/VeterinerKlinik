using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeterinerKlinik.Migrations
{
    /// <inheritdoc />
    public partial class VeterinerAlanlariEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Muayeneler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Muayeneler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HayvanId = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Teshis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ucret = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muayeneler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Muayeneler_Hayvanlar_HayvanId",
                        column: x => x.HayvanId,
                        principalTable: "Hayvanlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Muayeneler_HayvanId",
                table: "Muayeneler",
                column: "HayvanId");
        }
    }
}
