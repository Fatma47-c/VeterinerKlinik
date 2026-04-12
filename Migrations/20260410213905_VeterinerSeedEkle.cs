using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VeterinerKlinik.Migrations
{
    /// <inheritdoc />
    public partial class VeterinerSeedEkle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hayvanlar_Musteriler_MusteriId",
                table: "Hayvanlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Muayeneler_Veterinerler_VeterinerId",
                table: "Muayeneler");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Hayvanlar_HayvanId",
                table: "Randevular");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Veterinerler_VeterinerId",
                table: "Randevular");

            migrationBuilder.DropTable(
                name: "Musteriler");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_HayvanId",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Muayeneler_VeterinerId",
                table: "Muayeneler");

            migrationBuilder.DropIndex(
                name: "IX_Hayvanlar_MusteriId",
                table: "Hayvanlar");

            migrationBuilder.DropColumn(
                name: "VeterinerId",
                table: "Muayeneler");

            migrationBuilder.DropColumn(
                name: "MusteriId",
                table: "Hayvanlar");

            migrationBuilder.RenameColumn(
                name: "HayvanId",
                table: "Randevular",
                newName: "VeterinerNd");

            migrationBuilder.AlterColumn<int>(
                name: "VeterinerId",
                table: "Randevular",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "HayvanCinsi",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HayvanTuru",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MusteriAdi",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Veterinerler",
                columns: new[] { "Id", "Ad", "Soyad", "UzmanlikAlani" },
                values: new object[,]
                {
                    { 1, "Uzm.Vet.Hek. Selin", "Yılmaz", "Küçük Hayvanları" },
                    { 2, "Vet.Hek. Ahmet", "Demir", "Çiftlik Hayvanları" },
                    { 3, "Dr.Med.Vet. Murat", "Aydın", "Egzotik Hayvanları" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Veterinerler_VeterinerId",
                table: "Randevular",
                column: "VeterinerId",
                principalTable: "Veterinerler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Veterinerler_VeterinerId",
                table: "Randevular");

            migrationBuilder.DeleteData(
                table: "Veterinerler",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Veterinerler",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Veterinerler",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "HayvanCinsi",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "HayvanTuru",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "MusteriAdi",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "Randevular");

            migrationBuilder.RenameColumn(
                name: "VeterinerNd",
                table: "Randevular",
                newName: "HayvanId");

            migrationBuilder.AlterColumn<int>(
                name: "VeterinerId",
                table: "Randevular",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VeterinerId",
                table: "Muayeneler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MusteriId",
                table: "Hayvanlar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_HayvanId",
                table: "Randevular",
                column: "HayvanId");

            migrationBuilder.CreateIndex(
                name: "IX_Muayeneler_VeterinerId",
                table: "Muayeneler",
                column: "VeterinerId");

            migrationBuilder.CreateIndex(
                name: "IX_Hayvanlar_MusteriId",
                table: "Hayvanlar",
                column: "MusteriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hayvanlar_Musteriler_MusteriId",
                table: "Hayvanlar",
                column: "MusteriId",
                principalTable: "Musteriler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Muayeneler_Veterinerler_VeterinerId",
                table: "Muayeneler",
                column: "VeterinerId",
                principalTable: "Veterinerler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Hayvanlar_HayvanId",
                table: "Randevular",
                column: "HayvanId",
                principalTable: "Hayvanlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Veterinerler_VeterinerId",
                table: "Randevular",
                column: "VeterinerId",
                principalTable: "Veterinerler",
                principalColumn: "Id");
        }
    }
}
