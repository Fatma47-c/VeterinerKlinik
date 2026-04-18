using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeterinerKlinik.Migrations
{
    /// <inheritdoc />
    public partial class VeterinerGuncellendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cinsiyet",
                table: "Veterinerler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeneyimYili",
                table: "Veterinerler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Universite",
                table: "Veterinerler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unvan",
                table: "Veterinerler",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cinsiyet",
                table: "Veterinerler");

            migrationBuilder.DropColumn(
                name: "DeneyimYili",
                table: "Veterinerler");

            migrationBuilder.DropColumn(
                name: "Universite",
                table: "Veterinerler");

            migrationBuilder.DropColumn(
                name: "Unvan",
                table: "Veterinerler");
        }
    }
}
